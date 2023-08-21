#include <xsensdeviceapi.h> // The Xsens device API header
#include "conio.h"			// For non ANSI _kbhit() and _getch()
#include <cstdlib> // 包含 <cstdlib> 標頭檔案以使用環境變數相關函式
#include <string>
#include <stdexcept>
#include <iostream>
#include <iomanip>
#include <sstream>
#include <set>
#include <list>
#include <utility>
#include <vector>
#include <fstream>
#include <ctime>
#include <xsens/xsmutex.h>
#include <chrono>
#include <thread>
#include <cmath>
#include "conio.h"
#include <windows.h>
#include <winsock.h>
#pragma comment(lib,"ws2_32.lib")


/*! \brief Stream insertion operator overload for XsPortInfo */
std::ostream& operator << (std::ostream& out, XsPortInfo const& p)
{
	out << "Port: " << std::setw(2) << std::right << p.portNumber() << " (" << p.portName().toStdString() << ") @ "
		<< std::setw(7) << p.baudrate() << " Bd"
		<< ", " << "ID: " << p.deviceId().toString().toStdString()
		;
	return out;
}

/*! \brief Stream insertion operator overload for XsDevice */
std::ostream& operator << (std::ostream& out, XsDevice const& d)
{
	out << "ID: " << d.deviceId().toString().toStdString() << " (" << d.productCode().toStdString() << ")";
	return out;
}

/*! \brief Given a list of update rates and a desired update rate, returns the closest update rate to the desired one */
int findClosestUpdateRate(const XsIntArray& supportedUpdateRates, const int desiredUpdateRate)
{
	if (supportedUpdateRates.empty())
	{
		return 0;
	}

	if (supportedUpdateRates.size() == 1)
	{
		return supportedUpdateRates[0];
	}

	int uRateDist = -1;
	int closestUpdateRate = -1;
	for (XsIntArray::const_iterator itUpRate = supportedUpdateRates.begin(); itUpRate != supportedUpdateRates.end(); ++itUpRate)
	{
		const int currDist = std::abs(*itUpRate - desiredUpdateRate);

		if ((uRateDist == -1) || (currDist < uRateDist))
		{
			uRateDist = currDist;
			closestUpdateRate = *itUpRate;
		}
	}
	return closestUpdateRate;
}


//----------------------------------------------------------------------
// Callback handler for wireless master
//----------------------------------------------------------------------
class WirelessMasterCallback : public XsCallback
{
public:
	typedef std::set<XsDevice*> XsDeviceSet;

	XsDeviceSet getWirelessMTWs() const
	{
		XsMutexLocker lock(m_mutex);
		return m_connectedMTWs;
	}

protected:
	virtual void onConnectivityChanged(XsDevice* dev, XsConnectivityState newState)
	{
		XsMutexLocker lock(m_mutex);
		switch (newState)
		{
		case XCS_Disconnected:		/*!< Device has disconnected, only limited informational functionality is available. */
			std::cout << "\nEVENT: MTW Disconnected -> " << *dev << std::endl;
			m_connectedMTWs.erase(dev);
			break;
		case XCS_Rejected:			/*!< Device has been rejected and is disconnected, only limited informational functionality is available. */
			std::cout << "\nEVENT: MTW Rejected -> " << *dev << std::endl;
			m_connectedMTWs.erase(dev);
			break;
		case XCS_PluggedIn:			/*!< Device is connected through a cable. */
			std::cout << "\nEVENT: MTW PluggedIn -> " << *dev << std::endl;
			m_connectedMTWs.erase(dev);
			break;
		case XCS_Wireless:			/*!< Device is connected wirelessly. */
			std::cout << "\nEVENT: MTW Connected -> " << *dev << std::endl;
			m_connectedMTWs.insert(dev);
			break;
		case XCS_File:				/*!< Device is reading from a file. */
			std::cout << "\nEVENT: MTW File -> " << *dev << std::endl;
			m_connectedMTWs.erase(dev);
			break;
		case XCS_Unknown:			/*!< Device is in an unknown state. */
			std::cout << "\nEVENT: MTW Unknown -> " << *dev << std::endl;
			m_connectedMTWs.erase(dev);
			break;
		default:
			std::cout << "\nEVENT: MTW Error -> " << *dev << std::endl;
			m_connectedMTWs.erase(dev);
			break;
		}
	}
private:
	mutable XsMutex m_mutex;
	XsDeviceSet m_connectedMTWs;
};

//----------------------------------------------------------------------
// Callback handler for MTw
// Handles onDataAvailable callbacks for MTW devices
//----------------------------------------------------------------------
class MtwCallback : public XsCallback
{
public:
	MtwCallback(int mtwIndex, XsDevice* device)
		:m_mtwIndex(mtwIndex)
		, m_device(device)
	{}

	bool dataAvailable() const
	{
		XsMutexLocker lock(m_mutex);
		return !m_packetBuffer.empty();
	}

	XsDataPacket const* getOldestPacket() const
	{
		XsMutexLocker lock(m_mutex);
		XsDataPacket const* packet = &m_packetBuffer.front();
		return packet;
	}

	void deleteOldestPacket()
	{
		XsMutexLocker lock(m_mutex);
		m_packetBuffer.pop_front();
	}

	int getMtwIndex() const
	{
		return m_mtwIndex;
	}

	XsDevice const& device() const
	{
		assert(m_device != 0);
		return *m_device;
	}

protected:
	virtual void onLiveDataAvailable(XsDevice*, const XsDataPacket* packet)
	{
		XsMutexLocker lock(m_mutex);
		// NOTE: Processing of packets should not be done in this thread.

		m_packetBuffer.push_back(*packet);
		if (m_packetBuffer.size() > 300)
		{
			std::cout << std::endl;
			deleteOldestPacket();
		}
	}

private:
	mutable XsMutex m_mutex;
	std::list<XsDataPacket> m_packetBuffer;
	int m_mtwIndex;
	XsDevice* m_device;
};

//----------------------------------------------------------------------
// Main
//----------------------------------------------------------------------

int main(int argc, char* argv[])
{
	(void)argc;
	(void)argv;
	const int desiredUpdateRate = 60;	// Use 75 Hz update rate for MTWs
	const int desiredRadioChannel = 19;	// Use radio channel 19 for wireless master.
	WirelessMasterCallback wirelessMasterCallback; // Callback for wireless master
	std::vector<MtwCallback*> mtwCallbacks; // Callbacks for mtw devices

	std::cout << "Constructing XsControl..." << std::endl;
	XsControl* control = XsControl::construct();
	if (control == 0)
	{
		std::cout << "Failed to construct XsControl instance." << std::endl;
	}

	try
	{
		std::cout << "Scanning ports..." << std::endl;
		XsPortInfoArray detectedDevices = XsScanner::scanPorts();

		std::cout << "Finding wireless master..." << std::endl;
		XsPortInfoArray::const_iterator wirelessMasterPort = detectedDevices.begin();
		while (wirelessMasterPort != detectedDevices.end() && !wirelessMasterPort->deviceId().isWirelessMaster())
		{
			++wirelessMasterPort;
		}
		if (wirelessMasterPort == detectedDevices.end())
		{
			throw std::runtime_error("No wireless masters found");
		}
		std::cout << "Wireless master found @ " << *wirelessMasterPort << std::endl;

		std::cout << "Opening port..." << std::endl;
		if (!control->openPort(wirelessMasterPort->portName().toStdString(), wirelessMasterPort->baudrate()))
		{
			std::ostringstream error;
			error << "Failed to open port " << *wirelessMasterPort;
			throw std::runtime_error(error.str());
		}

		std::cout << "Getting XsDevice instance for wireless master..." << std::endl;
		XsDevicePtr wirelessMasterDevice = control->device(wirelessMasterPort->deviceId());
		if (wirelessMasterDevice == 0)
		{
			std::ostringstream error;
			error << "Failed to construct XsDevice instance: " << *wirelessMasterPort;
			throw std::runtime_error(error.str());
		}

		std::cout << "XsDevice instance created @ " << *wirelessMasterDevice << std::endl;

		std::cout << "Setting config mode..." << std::endl;
		if (!wirelessMasterDevice->gotoConfig())
		{
			std::ostringstream error;
			error << "Failed to goto config mode: " << *wirelessMasterDevice;
			throw std::runtime_error(error.str());
		}

		std::cout << "Attaching callback handler..." << std::endl;
		wirelessMasterDevice->addCallbackHandler(&wirelessMasterCallback);

		std::cout << "Getting the list of the supported update rates..." << std::endl;
		const XsIntArray supportedUpdateRates = wirelessMasterDevice->supportedUpdateRates();

		std::cout << "Supported update rates: ";
		for (XsIntArray::const_iterator itUpRate = supportedUpdateRates.begin(); itUpRate != supportedUpdateRates.end(); ++itUpRate)
		{
			std::cout << *itUpRate << " ";
		}
		std::cout << std::endl;

		const int newUpdateRate = findClosestUpdateRate(supportedUpdateRates, desiredUpdateRate);

		std::cout << "Setting update rate to " << newUpdateRate << " Hz..." << std::endl;
		if (!wirelessMasterDevice->setUpdateRate(newUpdateRate))
		{
			std::ostringstream error;
			error << "Failed to set update rate: " << *wirelessMasterDevice;
			throw std::runtime_error(error.str());
		}

		std::cout << "Disabling radio channel if previously enabled..." << std::endl;
		if (wirelessMasterDevice->isRadioEnabled())
		{
			if (!wirelessMasterDevice->disableRadio())
			{
				std::ostringstream error;
				error << "Failed to disable radio channel: " << *wirelessMasterDevice;
				throw std::runtime_error(error.str());
			}
		}

		std::cout << "Setting radio channel to " << desiredRadioChannel << " and enabling radio..." << std::endl;
		if (!wirelessMasterDevice->enableRadio(desiredRadioChannel))
		{
			std::ostringstream error;
			error << "Failed to set radio channel: " << *wirelessMasterDevice;
			throw std::runtime_error(error.str());
		}

		std::cout << "Waiting for MTW to wirelessly connect...\n" << std::endl;

		bool waitForConnections = true;
		size_t connectedMTWCount = wirelessMasterCallback.getWirelessMTWs().size();
		do
		{
			XsTime::msleep(100);

			while (true)
			{
				size_t nextCount = wirelessMasterCallback.getWirelessMTWs().size();
				if (nextCount != connectedMTWCount)
				{
					std::cout << "Number of connected MTWs: " << nextCount << ". Press 'Y' to  start." << std::endl;
					connectedMTWCount = nextCount;
				}
				else
				{
					break;
				}
			}
			if (_kbhit())
			{
				waitForConnections = (toupper((char)_getch()) != 'Y');
			}
		} while (waitForConnections);

		std::cout << "Starting measurement..." << std::endl;
		if (!wirelessMasterDevice->gotoMeasurement())
		{
			std::ostringstream error;
			error << "Failed to goto measurement mode: " << *wirelessMasterDevice;
			throw std::runtime_error(error.str());
		}

		std::cout << "Getting XsDevice instances for all MTWs..." << std::endl;
		XsDeviceIdArray allDeviceIds = control->deviceIds();
		XsDeviceIdArray mtwDeviceIds;
		for (XsDeviceIdArray::const_iterator i = allDeviceIds.begin(); i != allDeviceIds.end(); ++i)
		{
			if (i->isMtw())
			{
				mtwDeviceIds.push_back(*i);
			}
		}
		XsDevicePtrArray mtwDevices;
		for (XsDeviceIdArray::const_iterator i = mtwDeviceIds.begin(); i != mtwDeviceIds.end(); ++i)
		{
			XsDevicePtr mtwDevice = control->device(*i);
			if (mtwDevice != 0)
			{
				mtwDevices.push_back(mtwDevice);
			}
			else
			{
				throw std::runtime_error("Failed to create an MTW XsDevice instance");
			}
		}

		std::cout << "Attaching callback handlers to MTWs..." << std::endl;
		mtwCallbacks.resize(mtwDevices.size());
		for (int i = 0; i < (int)mtwDevices.size(); ++i)
		{
			mtwCallbacks[i] = new MtwCallback(i, mtwDevices[i]);
			mtwDevices[i]->addCallbackHandler(mtwCallbacks[i]);
		}

		std::cout << "\nMain loop. Press E to quit\n" << std::endl;
		std::cout << "Waiting for data available..." << std::endl;

		std::vector<XsEuler> eulerData(mtwCallbacks.size()); // Room to store euler data for each mtw
		std::vector<XsVector> GyroscopeData(mtwCallbacks.size()); // Room to store euler data for each mtw
		unsigned int printCounter = 0;

		std::vector<std::vector<XsEuler>> eulerDataBuffer(mtwCallbacks.size(), std::vector<XsEuler>());
		std::vector<XsEuler> initialEulerDataVector(mtwCallbacks.size());
		

		//-----------------------------------------------------------------
		//執行迴圈區段
		//----------------------------------------------------------------
		bool runAgain = true;
		while (runAgain) {
			// 迴圈開始，等待使用者輸入 "start" 來開始量測
			std::string startInput;
			std::cout << "Please enter '1' to begin the measurement: ";
			std::cin >> startInput;
			//Sleep(5000);
			if (startInput == "1") {
				// 使用者輸入 "start"，開始量測
				bool firstDataPrinted = false; // 追蹤是否已經打印了第一組數值
				// 創建一個向量來保存每顆感測器的初始數據
				std::vector<XsEuler> initialEulerDataVector(mtwCallbacks.size());

				// 創建一個向量來追蹤每顆感測器的第一組數據是否已經保存
				std::vector<bool> isFirstDataSaved(mtwCallbacks.size(), false);
				//一些參數設定
				double testtime = 0.0;
				std::time_t currentTimeData = std::time(nullptr);
				std::tm* localTime = std::localtime(&currentTimeData);
				char filename[80]; // 用於存儲檔名的字符陣列
				std::strftime(filename, sizeof(filename), "data%Y%m%d%H%M.csv", localTime);
				std::ofstream outputFile(filename);; // 使用生成的檔名創建 CSV 檔案
				if (outputFile.is_open()) // 檢查 CSV 文件是否已打開
				{
					outputFile << "PC Time,test_time, timeInterval,IMU-1 id,Roll-1,Pitch-1,Yaw-1,Roll-1 Rate,Pitch-1 Rate,Yaw-1 Rate,IMU-2 id,Roll-2,Pitch-2,Yaw-2,Roll-2 Rate,Pitch-2 Rate,Yaw-2 Rate,IMU-3 id,Roll-3,Pitch-3,Yaw-3,Roll-3 Rate,Pitch-3 Rate,Yaw-3 Rate,IMU-4 id,Roll-4,Pitch-4,Yaw-4,Roll-4 Rate,Pitch-4 Rate,Yaw-4 Rate,IMU-5 id,Roll-5,Pitch-5,Yaw-5,Roll-5 Rate,Pitch-5 Rate,Yaw-5 Rate,IMU-6 id,Roll-6,Pitch-6,Yaw-6,Roll-6 Rate,Pitch-6 Rate,Yaw-6 Rate" << std::endl;
				}

				// 在while迴圈外部定義變數
				std::vector<double> prevRoll(mtwCallbacks.size(), 0.0);
				std::vector<double> prevPitch(mtwCallbacks.size(), 0.0);
				std::vector<double> prevYaw(mtwCallbacks.size(), 0.0);
				std::vector<double> rollRate(mtwCallbacks.size(), 0.0);
				std::vector<double> pitchRate(mtwCallbacks.size(), 0.0);
				std::vector<double> yawRate(mtwCallbacks.size(), 0.0);
				std::vector<double> currentRoll(mtwCallbacks.size(), 0.0);
				std::vector<double> currentPitch(mtwCallbacks.size(), 0.0);
				std::vector<double> currentYaw(mtwCallbacks.size(), 0.0);
				std::vector<double> Roll(mtwCallbacks.size(), 0.0);
				std::vector<double> Pitch(mtwCallbacks.size(), 0.0);
				std::vector<double> Yaw(mtwCallbacks.size(), 0.0);
				std::vector<double> judgeRoll(mtwCallbacks.size(), 0.0);
				std::vector<double> judgePitch(mtwCallbacks.size(), 0.0);
				std::vector<double> judgeYaw(mtwCallbacks.size(), 0.0);
				
				std::chrono::high_resolution_clock::time_point prevTime = std::chrono::high_resolution_clock::now();
				bool isFirstIteration = true;
				double timeInterval = 0.0; // 初始化時間間隔變數
				bool firsttime = true;
				//-----------------------------------------------------------------

				while (true) {
					bool newDataAvailable = false;
					bool record = false;
					
					while (true) {
						XsTime::msleep(0);
						bool allDataAvailable = false;

						for (size_t i = 0; i < mtwCallbacks.size(); ++i)
						{
							if (mtwCallbacks[i]->dataAvailable())
							{
								newDataAvailable = true;
								XsDataPacket const* packet = mtwCallbacks[i]->getOldestPacket();
								eulerData[i] = packet->orientationEuler();
								eulerDataBuffer[i].push_back(eulerData[i]);
								mtwCallbacks[i]->deleteOldestPacket();
							}
						}
			
						if (newDataAvailable)
						{
							// 獲取當前時間戳
							std::chrono::high_resolution_clock::time_point currentTime = std::chrono::high_resolution_clock::now();
							// 計算時間間隔（秒）
							timeInterval = std::chrono::duration<double>(currentTime - prevTime).count();
							prevTime = currentTime; // 更新上一次時間戳

							// 等待所有 IMU 的數據都收到後再進行計算
							while (!allDataAvailable) {
								allDataAvailable = true; // 假設所有 IMU 都已經收到數據

								for (size_t i = 0; i < mtwCallbacks.size(); ++i) {
									if (!mtwCallbacks[i]->dataAvailable()) {
										allDataAvailable = false; // 至少有一個 IMU 還沒有收到數據
										break;
									}
								}
								// 增加短暫延遲，避免忙碌等待
								XsTime::msleep(0);
							}

							for (size_t i = 0; i < mtwCallbacks.size(); ++i) {
								if (!isFirstDataSaved[i] && eulerDataBuffer[i].size() >= 50) {
									double sumRoll = 0.0;
									double sumPitch = 0.0;
									double sumYaw = 0.0;

									for (size_t j = 0; j < 50; ++j) {
										sumRoll += eulerDataBuffer[i][j].roll();
										sumPitch += eulerDataBuffer[i][j].pitch();
										sumYaw += eulerDataBuffer[i][j].yaw();
									}

									double avgRoll = sumRoll / 50.0;
									double avgPitch = sumPitch / 50.0;
									double avgYaw = sumYaw / 50.0;

									XsEuler avgEuler(avgRoll, avgPitch, avgYaw);

									// 打印感測器的平均數值
									std::cout << "Sensor " << i << " - Average data of first 90 samples: "
										<< "Roll: " << avgEuler.roll()
										<< ", Pitch: " << avgEuler.pitch()
										<< ", Yaw: " << avgEuler.yaw()
										<< std::endl;

									// 保存平均數值作為參考值
									initialEulerDataVector[i] = avgEuler;
									isFirstDataSaved[i] = true;
									record = true;
								}
							}
							
							
							for (size_t i = 0; i < mtwCallbacks.size(); ++i)
							{
								if (!isFirstIteration) {
									
									
									if (!firsttime) {

										Roll[i] = eulerData[i].roll() ;
										Pitch[i] = eulerData[i].pitch();
										Yaw[i] = eulerData[i].yaw();

										if (std::abs(Roll[i] - judgeRoll[i]) < 0.04) {
											double rollDifference = prevRoll[i] - initialEulerDataVector[i].roll();

											if (rollDifference < -180.0) {
												Roll[i] = rollDifference + 360.0;
											}
											else if (rollDifference > 180.0) {
												Roll[i] = rollDifference - 360.0;
											}
											else {
												Roll[i] = rollDifference;
											}
											rollRate[i] = 0;
											judgeRoll[i] = eulerData[i].roll();
										}
										else {
											double rollDifference = eulerData[i].roll() - initialEulerDataVector[i].roll();

											if (rollDifference < -180.0) {
												Roll[i] = rollDifference + 360.0;
											}
											else if (rollDifference > 180.0) {
												Roll[i] = rollDifference - 360.0;
											}
											else {
												Roll[i] = rollDifference;
											}

											rollRate[i] = (eulerData[i].roll() - prevRoll[i]) / timeInterval;
											prevRoll[i] = eulerData[i].roll();
											judgeRoll[i] = eulerData[i].roll();
										}
										
										if (std::abs(Pitch[i] - judgePitch[i]) < 0.04) {
											double pitchDifference = prevPitch[i] - initialEulerDataVector[i].pitch();

											if (pitchDifference < -180.0) {
												Pitch[i] = pitchDifference + 360.0;
											}
											else if (pitchDifference > 180.0) {
												Pitch[i] = pitchDifference - 360.0;
											}
											else {
												Pitch[i] = pitchDifference;
											}
											pitchRate[i] = 0;
											judgePitch[i] = eulerData[i].pitch();
										}
										else {
											double pitchDifference = eulerData[i].pitch() - initialEulerDataVector[i].pitch();

											if (pitchDifference < -180.0) {
												Pitch[i] = pitchDifference + 360.0;
											}
											else if (pitchDifference > 180.0) {
												Pitch[i] = pitchDifference - 360.0;
											}
											else {
												Pitch[i] = pitchDifference;
											}
											pitchRate[i] = (eulerData[i].pitch() - prevPitch[i]) / timeInterval;
											prevPitch[i] = eulerData[i].pitch();
											judgePitch[i] = eulerData[i].pitch();
										}
										
										if (std::abs(Yaw[i] - judgeYaw[i]) < 0.04) {
											double yawDifference = prevYaw[i] - initialEulerDataVector[i].yaw();

											if (yawDifference < -180.0) {
												Yaw[i] = yawDifference + 360.0;
											}
											else if (yawDifference > 180.0) {
												Yaw[i] = yawDifference - 360.0;
											}
											else {
												Yaw[i] = yawDifference;
											}
											yawRate[i] = 0;
											judgeYaw[i] = eulerData[i].yaw();
										}
										else {
											double yawDifference = eulerData[i].yaw() - initialEulerDataVector[i].yaw();

											if (yawDifference < -180.0) {
												Yaw[i] = yawDifference + 360.0;
											}
											else if (yawDifference > 180.0) {
												Yaw[i] = yawDifference - 360.0;
											}
											else {
												Yaw[i] = yawDifference;
											}
											yawRate[i] = (eulerData[i].yaw() - prevYaw[i]) / timeInterval;
											prevYaw[i] = eulerData[i].yaw();
											judgeYaw[i] = eulerData[i].yaw();
										}
									}
									else {
										
										Roll[i] = eulerData[i].roll() - initialEulerDataVector[i].roll();
										Pitch[i] = eulerData[i].pitch() - initialEulerDataVector[i].pitch();
										Yaw[i] = eulerData[i].yaw() - initialEulerDataVector[i].yaw();
										rollRate[i] = (eulerData[i].roll() - prevRoll[i]) / timeInterval;
										pitchRate[i] = (eulerData[i].pitch() - prevPitch[i]) / timeInterval;
										yawRate[i] = (eulerData[i].yaw() - prevYaw[i]) / timeInterval;
										prevRoll[i] = eulerData[i].roll();
										prevPitch[i] = eulerData[i].pitch();
										prevYaw[i] = eulerData[i].yaw();
										judgeRoll[i] = eulerData[i].roll();
										judgePitch[i] = eulerData[i].pitch();
										judgeYaw[i] = eulerData[i].yaw();
										firsttime = false;
									}

								}
							}

							if (printCounter % 10 == 0)// Don't print too often for performance. Console output is very slow.
							{ 
								for (size_t i = 0; i < mtwCallbacks.size(); ++i)
								{
									std::cout << "time:" << std::setw(7) << std::fixed << std::setprecision(2) << testtime;
									std::cout << "[" << i << "]: ID: " << mtwCallbacks[i]->device().deviceId().toString().toStdString()
										<< ", Roll: " << std::setw(7) << std::fixed << std::setprecision(2) << Roll[i]
										<< ", Pitch: " << std::setw(7) << std::fixed << std::setprecision(2) << Pitch[i]
										<< ", Yaw: " << std::setw(7) << std::fixed << std::setprecision(2) << Yaw[i]
										<< ", Roll rate " << std::setw(7) << std::fixed << std::setprecision(2) << rollRate[i]
										<< ", Pitch rate: " << std::setw(7) << std::fixed << std::setprecision(2) << pitchRate[i]
										<< ", Yaw rate:" << std::setw(7) << std::fixed << std::setprecision(2) << yawRate[i]
										<< "\n";
								}
							}
							++printCounter;


							if (record) {
								if (outputFile.is_open()) // 檢查 CSV 文件是否已打開
								{
									// 獲取當前的時間戳
									std::time_t currentTimeData = std::time(nullptr);
									// 寫入時間戳
									outputFile << std::put_time(std::localtime(&currentTimeData), "%H:%M:%S") << ",";
									outputFile << testtime << ",";
									outputFile << timeInterval << ",";

									if (!isFirstIteration) {
										testtime = testtime + timeInterval;
									}
									isFirstIteration = false;

									// 寫入數據欄位
									for (size_t i = 0; i < mtwCallbacks.size(); ++i)
									{
										

										outputFile << "[" << i << "]: ID: " << mtwCallbacks[i]->device().deviceId().toString().toStdString()
											<< ", " << std::setw(7) << std::fixed << std::setprecision(2) << Roll[i]
											<< ",  " << std::setw(7) << std::fixed << std::setprecision(2) << Pitch[i]
											<< ",  " << std::setw(7) << std::fixed << std::setprecision(2) << Yaw[i]
											<< ", " << std::setw(7) << std::fixed << std::setprecision(2) << rollRate[i]
											<< ", " << std::setw(7) << std::fixed << std::setprecision(2) << pitchRate[i]
											<< ", " << std::setw(7) << std::fixed << std::setprecision(2) << yawRate[i]
											<< ", ";
									}
									outputFile << std::endl;
								}
								else
								{
									// 無法打開文件，處理錯誤
									std::cout << "Unable to open output file." << std::endl;
								}
							}
								if (_kbhit()) {
									char key = toupper((char)_getch());
									if (key == 'E') {
										// 按下 'E' 鍵結束內層的 while 迴圈
										break;
									}
								}
							
						}
					}
					if (outputFile.is_open())
					{
						outputFile.close();
					}					
					break;
				}

				std::string againInput;
				std::cout << "Do you want to measure again? (Enter '2' to restart, or any other key to exit): ";
				std::cin >> againInput;
				if (againInput != "2") {
					// 使用者輸入不是 "2"，跳出主要迴圈
					runAgain = false;
				}
				else {
					std::cout << "Invalid input. Please enter '1' to begin the measurement." << std::endl;
				}
			}
		}


		std::cout << "Setting config mode..." << std::endl;
		if (!wirelessMasterDevice->gotoConfig())
		{
			std::ostringstream error;
			error << "Failed to goto config mode: " << *wirelessMasterDevice;
			throw std::runtime_error(error.str());
		}

		std::cout << "Disabling radio... " << std::endl;
		if (!wirelessMasterDevice->disableRadio())
		{
			std::ostringstream error;
			error << "Failed to disable radio: " << *wirelessMasterDevice;
			throw std::runtime_error(error.str());
		}
	}
	catch (std::exception const& ex)
	{
		std::cout << ex.what() << std::endl;
		std::cout << "****ABORT****" << std::endl;
	}
	catch (...)
	{
		std::cout << "An unknown fatal error has occured. Aborting." << std::endl;
		std::cout << "****ABORT****" << std::endl;
	}
	std::cout << "Closing XsControl..." << std::endl;
	control->close();

	std::cout << "Deleting mtw callbacks..." << std::endl;
	for (std::vector<MtwCallback*>::iterator i = mtwCallbacks.begin(); i != mtwCallbacks.end(); ++i)
	{
		delete (*i);
	}
	std::cout << "Successful exit." << std::endl;
	std::cout << "Press [ENTER] to continue." << std::endl; std::cin.get();
	return 0;
}