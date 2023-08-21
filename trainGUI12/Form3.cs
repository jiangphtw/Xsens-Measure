using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Reflection;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace trainGUI
{
    public partial class Form3 : Form
    {
        private int targetColumnIndex4 = 4; // 顯示在text1的目標欄位索引
        private int targetColumnIndex5 = 5; // 顯示在text2的目標欄位索引
        private int targetColumnIndex6 = 6; // 顯示在text3的目標欄位索引
        private int targetColumnIndex11 = 11; // 顯示在text4的目標欄位索引
        private int targetColumnIndex12 = 12; // 顯示在text5的目標欄位索引
        private int targetColumnIndex13 = 13; // 顯示在text6的目標欄位索引
        private int targetColumnIndex18 = 18; // 顯示在text7的目標欄位索引
        private int targetColumnIndex19 = 19; // 顯示在text8的目標欄位索引
        private int targetColumnIndex20 = 20; // 顯示在text9的目標欄位索引
        private int targetColumnIndex25 = 25; // 顯示在text10的目標欄位索引
        private int targetColumnIndex26 = 26; // 顯示在text11的目標欄位索引
        private int targetColumnIndex27 = 27; // 顯示在text12的目標欄位索引
        private int targetColumnIndex32 = 32; // 顯示在text13的目標欄位索引
        private int targetColumnIndex33 = 33; // 顯示在text14的目標欄位索引
        private int targetColumnIndex34 = 34; // 顯示在text15的目標欄位索引
        private int targetColumnIndex39 = 39; // 顯示在text16的目標欄位索引
        private int targetColumnIndex40 = 40; // 顯示在text17的目標欄位索引
        private int targetColumnIndex41 = 41; // 顯示在text18的目標欄位索引



        private System.Windows.Forms.Timer updateTimer;
        private string currentFileName;
        private StreamReader reader; // 在這裡聲明 reader 變數

        // 匯入 Windows API 函式
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        // 定義需要的常數
        const uint WM_KEYDOWN = 0x0100;
        const uint WM_KEYUP = 0x0101;
        const int VK_1 = 0x31; // 虛擬鍵碼：1
        const int VK_ENTER = 0x0D; // 虛擬鍵碼：Enter

        public Form3()
        {
            InitializeComponent();
            // 初始化 Timer 控制項
            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 50; // 設定時間間隔為 0.1 秒
            updateTimer.Tick += UpdateTimer_Tick; // 設定觸發事件處理程序
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
            checkBox2.CheckedChanged += CheckBox2_CheckedChanged;
            checkBox3.CheckedChanged += CheckBox3_CheckedChanged;

        }

        private void ReadAndUpdateCSV()
        {
            // 關閉程式之前先讀取CSV檔案
            try
            {
                // 輸入CSV檔案的完整路徑
                string csvFilePath = @"D:\Xsens\trainGUI12\bin\Debug\net6.0-windows\" + currentFileName;

                // 使用 FileStream 以讀取模式開啟檔案，並允許其他程式以讀寫模式開啟該檔案
                using (FileStream fileStream = new FileStream(csvFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    // 逐行讀取CSV檔案，直到結尾
                    string line;
                    string lastLine = null; // 用來存儲最後一行
                    while ((line = reader.ReadLine()) != null)
                    {
                        lastLine = line; // 更新最後一行
                    }

                    if (lastLine != null)
                    {
                        // 將最後一行拆解成欄位
                        string[] columns = lastLine.Split(',');

                        // 檢查目標欄位索引是否在範圍內
                        if (targetColumnIndex4 >= 0 && targetColumnIndex4 < columns.Length)
                        {
                            // 取得目標欄位的數值
                            string targetValue4 = columns[targetColumnIndex4];

                            // 將數值顯示在textBox1上
                            textBox1.Text = targetValue4;
                        }
                        else
                        {
                            // 目標欄位索引超出範圍，顯示錯誤訊息
                            textBox1.Text = "0";
                        }

                        if (targetColumnIndex5 >= 0 && targetColumnIndex5 < columns.Length)
                        {
                            // 取得目標欄位的數值
                            string targetValue5 = columns[targetColumnIndex5];

                            // 將數值顯示在textBox2上
                            textBox2.Text = targetValue5;
                        }
                        else
                        {
                            // 目標欄位索引超出範圍，顯示錯誤訊息
                            textBox2.Text = "0";
                        }

                        if (targetColumnIndex6 >= 0 && targetColumnIndex6 < columns.Length)
                        {
                            // 取得目標欄位的數值
                            string targetValue6 = columns[targetColumnIndex6];

                            // 將數值顯示在textBox3上
                            textBox3.Text = targetValue6;
                        }
                        else
                        {
                            // 目標欄位索引超出範圍，顯示錯誤訊息
                            textBox3.Text = "0";
                        }
                        if (targetColumnIndex11 >= 0 && targetColumnIndex11 < columns.Length)
                        {
                            // 取得目標欄位的數值
                            string targetValue11 = columns[targetColumnIndex11];

                            // 將數值顯示在textBox11上
                            textBox4.Text = targetValue11;
                        }
                        else
                        {
                            // 目標欄位索引超出範圍，顯示錯誤訊息
                            textBox4.Text = "0";
                        }

                        if (targetColumnIndex12 >= 0 && targetColumnIndex12 < columns.Length)
                        {
                            // 取得目標欄位的數值
                            string targetValue12 = columns[targetColumnIndex12];

                            // 將數值顯示在textBox5上
                            textBox5.Text = targetValue12;
                        }
                        else
                        {
                            // 目標欄位索引超出範圍，顯示錯誤訊息
                            textBox5.Text = "0";
                        }

                        if (targetColumnIndex13 >= 0 && targetColumnIndex13 < columns.Length)
                        {
                            // 取得目標欄位的數值
                            string targetValue13 = columns[targetColumnIndex13];

                            // 將數值顯示在textBox6上
                            textBox6.Text = targetValue13;
                        }
                        else
                        {
                            // 目標欄位索引超出範圍，顯示錯誤訊息
                            textBox6.Text = "0";
                        }
                        if (targetColumnIndex18 >= 0 && targetColumnIndex18 < columns.Length)
                        {
                            // 取得目標欄位的數值
                            string targetValue18 = columns[targetColumnIndex18];

                            // 將數值顯示在textBox7上
                            textBox7.Text = targetValue18;
                        }
                        else
                        {
                            // 目標欄位索引超出範圍，顯示錯誤訊息
                            textBox7.Text = "0";
                        }

                        if (targetColumnIndex19 >= 0 && targetColumnIndex19 < columns.Length)
                        {
                            // 取得目標欄位的數值
                            string targetValue19 = columns[targetColumnIndex19];

                            // 將數值顯示在textBox8上
                            textBox8.Text = targetValue19;
                        }
                        else
                        {
                            // 目標欄位索引超出範圍，顯示錯誤訊息
                            textBox8.Text = "0";
                        }

                        if (targetColumnIndex20 >= 0 && targetColumnIndex20 < columns.Length)
                        {
                            // 取得目標欄位的數值
                            string targetValue20 = columns[targetColumnIndex20];

                            // 將數值顯示在textBox9上
                            textBox9.Text = targetValue20;
                        }
                        else
                        {
                            // 目標欄位索引超出範圍，顯示錯誤訊息
                            textBox9.Text = "0";
                        }
                        if (targetColumnIndex25 >= 0 && targetColumnIndex25 < columns.Length)
                        {
                            // 取得目標欄位的數值
                            string targetValue25 = columns[targetColumnIndex25];

                            // 將數值顯示在textBox10上
                            textBox10.Text = targetValue25;
                        }
                        else
                        {
                            // 目標欄位索引超出範圍，顯示錯誤訊息
                            textBox10.Text = "0";
                        }

                        if (targetColumnIndex26 >= 0 && targetColumnIndex26 < columns.Length)
                        {
                            // 取得目標欄位的數值
                            string targetValue26 = columns[targetColumnIndex26];

                            // 將數值顯示在textBox11上
                            textBox11.Text = targetValue26;
                        }
                        else
                        {
                            // 目標欄位索引超出範圍，顯示錯誤訊息
                            textBox11.Text = "0";
                        }

                        if (targetColumnIndex27 >= 0 && targetColumnIndex27 < columns.Length)
                        {
                            // 取得目標欄位的數值
                            string targetValue27 = columns[targetColumnIndex27];

                            // 將數值顯示在textBox12上
                            textBox12.Text = targetValue27;
                        }
                        else
                        {
                            // 目標欄位索引超出範圍，顯示錯誤訊息
                            textBox12.Text = "0";
                        }
                        if (targetColumnIndex32 >= 0 && targetColumnIndex32 < columns.Length)
                        {
                            // 取得目標欄位的數值
                            string targetValue32 = columns[targetColumnIndex32];

                            // 將數值顯示在textBox13上
                            textBox13.Text = targetValue32;
                        }
                        else
                        {
                            // 目標欄位索引超出範圍，顯示錯誤訊息
                            textBox13.Text = "0";
                        }

                        if (targetColumnIndex33 >= 0 && targetColumnIndex33 < columns.Length)
                        {
                            // 取得目標欄位的數值
                            string targetValue33 = columns[targetColumnIndex33];

                            // 將數值顯示在textBox14上
                            textBox14.Text = targetValue33;
                        }
                        else
                        {
                            // 目標欄位索引超出範圍，顯示錯誤訊息
                            textBox14.Text = "0";
                        }

                        if (targetColumnIndex34 >= 0 && targetColumnIndex34 < columns.Length)
                        {
                            // 取得目標欄位的數值
                            string targetValue34 = columns[targetColumnIndex34];

                            // 將數值顯示在textBox15上
                            textBox15.Text = targetValue34;
                        }
                        else
                        {
                            // 目標欄位索引超出範圍，顯示錯誤訊息
                            textBox15.Text = "0";
                        }
                        if (targetColumnIndex39 >= 0 && targetColumnIndex39 < columns.Length)
                        {
                            // 取得目標欄位的數值
                            string targetValue39 = columns[targetColumnIndex39];

                            // 將數值顯示在textBox16上
                            textBox16.Text = targetValue39;
                        }
                        else
                        {
                            // 目標欄位索引超出範圍，顯示錯誤訊息
                            textBox16.Text = "0";
                        }

                        if (targetColumnIndex40 >= 0 && targetColumnIndex40 < columns.Length)
                        {
                            // 取得目標欄位的數值
                            string targetValue40 = columns[targetColumnIndex40];

                            // 將數值顯示在textBox17上
                            textBox17.Text = targetValue40;
                        }
                        else
                        {
                            // 目標欄位索引超出範圍，顯示錯誤訊息
                            textBox17.Text = "0";
                        }

                        if (targetColumnIndex41 >= 0 && targetColumnIndex41 < columns.Length)
                        {
                            // 取得目標欄位的數值
                            string targetValue41 = columns[targetColumnIndex41];

                            // 將數值顯示在textBox18上
                            textBox18.Text = targetValue41;
                        }
                        else
                        {
                            // 目標欄位索引超出範圍，顯示錯誤訊息
                            textBox18.Text = "0";
                        }

                    }
                    else
                    {
                        // CSV檔案為空，顯示錯誤訊息
                        textBox1.Text = "CSV檔案為空。";
                    }
                }
            }
            catch (Exception ex)
            {
                // 讀取CSV檔案時發生錯誤，顯示錯誤訊息
                textBox1.Text = "讀取CSV檔案時發生錯誤: " + ex.Message;
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            // 每隔 0.1 秒執行一次 CSV 檔案讀取並更新數值的程式碼
            ReadAndUpdateCSV();
            UpdateLabelVisibility();

        }




        private void pitch1_Click(object sender, EventArgs e)
        {

        }

        private void btnload_Click(object sender, EventArgs e)
        {
            // 記錄當下的電腦時間
            DateTime currentTime = DateTime.Now;

            // 格式化檔案名稱，例如："data202307272228.csv"
            currentFileName = String.Format("data{0}.csv", currentTime.ToString("yyyyMMddHHmm"));

            // 檢查檔案是否存在
            string csvFilePath = @"D:\Xsens\trainGUI12\bin\Debug\net6.0-windows\" + currentFileName;
            if (File.Exists(csvFilePath))
            {
                try
                {
                    // 檢查檔案是否具有讀取權限
                    FileAttributes attributes = File.GetAttributes(csvFilePath);
                    if ((attributes & FileAttributes.ReadOnly) == 0)
                    {
                        // 檔案是可讀取的，執行 CSV 檔案讀取的程式碼
                        ReadAndUpdateCSV();

                        // 啟動 Timer
                        updateTimer.Start();
                    }
                    else
                    {
                        // 檔案是唯讀的，顯示錯誤訊息
                        textBox1.Text = "你的程式沒有足夠的存取權限來讀取該 CSV 檔案。";
                    }
                }
                catch (Exception ex)
                {
                    // 無法檢查檔案存取權限，顯示錯誤訊息
                    textBox1.Text = "無法檢查檔案存取權限: " + ex.Message;
                }
            }
            else
            {
                // 指定的檔案不存在，顯示錯誤訊息
                textBox1.Text = "指定的檔案不存在。";
            }
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            try
            {
                // 輸入要開啟的檔案路徑 
                string filePath = @"D:\Xsens\xda_c_cpp\Win32\Debug\Out\XsensDeviceAPI Command Line MTw C++ Example.exe";

                // 使用 Process.Start 開啟該檔案
                Process.Start(filePath);
            }
            catch (Exception ex)
            {
                // 若發生錯誤，可以在這裡處理，例如顯示錯誤訊息
                MessageBox.Show("無法開啟檔案: " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btngo_Click(object sender, EventArgs e)
        {
            // 在這裡加入原本「使用者輸入 '1' 以開始」事件處理程式碼
            // 這裡使用 SendMessage 來模擬按下虛擬鍵 '1'
            IntPtr hWnd = FindWindow(null, "1");
            if (hWnd != IntPtr.Zero)
            {
                IntPtr childWnd = FindWindowEx(hWnd, IntPtr.Zero, null, null);
                if (childWnd != IntPtr.Zero)
                {
                    SendMessage(childWnd, WM_KEYDOWN, (IntPtr)VK_1, IntPtr.Zero);
                    SendMessage(childWnd, WM_KEYUP, (IntPtr)VK_1, IntPtr.Zero);
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(); // 創建 Form1 的實例
            form1.Show(); // 顯示 homepagr
            this.Hide(); // 隱藏當前的 Form3
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            // 檢查 CheckBox 的選中狀態
            if (checkBox1.Checked)
            {
                // 如果 CheckBox 被勾選，顯示 roll2
                pitch1.Visible = true;
                pitch2.Visible = true;
                pitch3.Visible = true;
                pitch4.Visible = true;
                pitch5.Visible = true;
                pitch6.Visible = true;
                textBox1.Visible = true;
                textBox4.Visible = true;
                textBox7.Visible = true;
                textBox10.Visible = true;
                textBox13.Visible = true;
                textBox16.Visible = true;

            }
            else
            {
                // 如果 CheckBox 沒有被勾選，隱藏 roll2
                pitch1.Visible = false;
                pitch2.Visible = false;
                pitch3.Visible = false;
                pitch4.Visible = false;
                pitch5.Visible = false;
                pitch6.Visible = false;
                textBox1.Visible = false;
                textBox4.Visible = false;
                textBox7.Visible = false;
                textBox10.Visible = false;
                textBox13.Visible = false;
                textBox16.Visible = false;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            // 檢查 CheckBox 的選中狀態
            if (checkBox2.Checked)
            {
                // 如果 CheckBox 被勾選，顯示 roll2
                roll1.Visible = true;
                roll2.Visible = true;
                roll3.Visible = true;
                roll4.Visible = true;
                roll5.Visible = true;
                roll6.Visible = true;
                textBox2.Visible = true;
                textBox5.Visible = true;
                textBox8.Visible = true;
                textBox11.Visible = true;
                textBox14.Visible = true;
                textBox17.Visible = true;
            }
            else
            {
                // 如果 CheckBox 沒有被勾選，隱藏 roll2
                roll1.Visible = false;
                roll2.Visible = false;
                roll3.Visible = false;
                roll4.Visible = false;
                roll5.Visible = false;
                roll6.Visible = false;
                textBox2.Visible = false;
                textBox5.Visible = false;
                textBox8.Visible = false;
                textBox11.Visible = false;
                textBox14.Visible = false;
                textBox17.Visible = false;
            }
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            // 檢查 CheckBox 的選中狀態
            if (checkBox3.Checked)
            {
                // 如果 CheckBox 被勾選，顯示 roll2..
                yaw1.Visible = true;
                yaw2.Visible = true;
                yaw3.Visible = true;
                yaw4.Visible = true;
                yaw5.Visible = true;
                yaw6.Visible = true;
                textBox3.Visible = true;
                textBox6.Visible = true;
                textBox9.Visible = true;
                textBox12.Visible = true;
                textBox15.Visible = true;
                textBox18.Visible = true;
            }
            else
            {
                // 如果 CheckBox 沒有被勾選，隱藏 roll2
                yaw1.Visible = false;
                yaw2.Visible = false;
                yaw3.Visible = false;
                yaw4.Visible = false;
                yaw5.Visible = false;
                yaw6.Visible = false;
                textBox3.Visible = false;
                textBox6.Visible = false;
                textBox9.Visible = false;
                textBox12.Visible = false;
                textBox15.Visible = false;
                textBox18.Visible = false;
            }
        }

        private void UpdateLabelVisibility()
        {
            // 確保 textBox1.Text 和 TextBox13.Text 都是合法的數值
            if (double.TryParse(textBox1.Text, out double textBox1Value) &&
                double.TryParse(textBox19.Text, out double textBox19Value) &&
                double.TryParse(textBox20.Text, out double textBox20Value) &&
                double.TryParse(textBox4.Text, out double textBox4Value) &&
                double.TryParse(textBox7.Text, out double textBox7Value) &&
                double.TryParse(textBox10.Text, out double textBox10Value) &&
                double.TryParse(textBox13.Text, out double textBox13Value) &&
                double.TryParse(textBox16.Text, out double textBox16Value))

            {
                if (textBox1Value > textBox19Value)
                {
                    label1.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox1Value < textBox20Value)
                {
                    label1.Visible = true;
                }
                else
                {
                    label1.Visible = false; // 否則隱藏 label1
                }

                if (textBox4Value > textBox19Value)
                {
                    label4.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox4Value < textBox20Value)
                {
                    label4.Visible = true;
                }
                else
                {
                    label4.Visible = false; // 否則隱藏 label1
                }

                if (textBox7Value > textBox19Value)
                {
                    label7.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox7Value < textBox20Value)
                {
                    label7.Visible = true;
                }
                else
                {
                    label7.Visible = false; // 否則隱藏 label1
                }

                if (textBox10Value > textBox19Value)
                {
                    label10.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox10Value < textBox20Value)
                {
                    label10.Visible = true;
                }
                else
                {
                    label10.Visible = false; // 否則隱藏 label1
                }

                if (textBox13Value > textBox19Value)
                {
                    label19.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox13Value < textBox20Value)
                {
                    label19.Visible = true;
                }
                else
                {
                    label19.Visible = false; // 否則隱藏 label1
                }

                if (textBox16Value > textBox19Value)
                {
                    label22.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox16Value < textBox20Value)
                {
                    label22.Visible = true;
                }
                else
                {
                    label22.Visible = false; // 否則隱藏 label1
                }
            }

            if (double.TryParse(textBox2.Text, out double textBox2Value) &&
                double.TryParse(textBox21.Text, out double textBox21Value) &&
                double.TryParse(textBox22.Text, out double textBox22Value) &&
                double.TryParse(textBox5.Text, out double textBox5Value) &&
                double.TryParse(textBox8.Text, out double textBox8Value) &&
                double.TryParse(textBox11.Text, out double textBox11Value) &&
                double.TryParse(textBox14.Text, out double textBox14Value) &&
                double.TryParse(textBox17.Text, out double textBox17Value))
            {
                if (textBox2Value > textBox21Value)
                {
                    label2.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox2Value < textBox22Value)
                {
                    label2.Visible = true;
                }
                else
                {
                    label2.Visible = false; // 否則隱藏 label1
                }

                if (textBox5Value > textBox21Value)
                {
                    label5.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox5Value < textBox22Value)
                {
                    label5.Visible = true;
                }
                else
                {
                    label5.Visible = false; // 否則隱藏 label1
                }

                if (textBox8Value > textBox21Value)
                {
                    label8.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox8Value < textBox22Value)
                {
                    label8.Visible = true;
                }
                else
                {
                    label8.Visible = false; // 否則隱藏 label1
                }

                if (textBox11Value > textBox21Value)
                {
                    label11.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox11Value < textBox22Value)
                {
                    label11.Visible = true;
                }
                else
                {
                    label11.Visible = false; // 否則隱藏 label1
                }

                if (textBox14Value > textBox21Value)
                {
                    label20.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox14Value < textBox22Value)
                {
                    label20.Visible = true;
                }
                else
                {
                    label20.Visible = false; // 否則隱藏 label1
                }

                if (textBox17Value > textBox21Value)
                {
                    label23.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox17Value < textBox22Value)
                {
                    label23.Visible = true;
                }
                else
                {
                    label23.Visible = false; // 否則隱藏 label1
                }

            }

            if (double.TryParse(textBox3.Text, out double textBox3Value) &&
               double.TryParse(textBox23.Text, out double textBox23Value) &&
               double.TryParse(textBox24.Text, out double textBox24Value) &&
               double.TryParse(textBox6.Text, out double textBox6Value) &&
               double.TryParse(textBox9.Text, out double textBox9Value) &&
               double.TryParse(textBox12.Text, out double textBox12Value) &&
                double.TryParse(textBox15.Text, out double textBox15Value) &&
                double.TryParse(textBox18.Text, out double textBox18Value))
            {
                if (textBox3Value > textBox23Value)
                {
                    label3.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox3Value < textBox24Value)
                {
                    label3.Visible = true;
                }
                else
                {
                    label3.Visible = false; // 否則隱藏 label1
                }

                if (textBox6Value > textBox23Value)
                {
                    label6.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox6Value < textBox24Value)
                {
                    label6.Visible = true;
                }
                else
                {
                    label6.Visible = false; // 否則隱藏 label1
                }

                if (textBox9Value > textBox23Value)
                {
                    label9.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox9Value < textBox24Value)
                {
                    label9.Visible = true;
                }
                else
                {
                    label9.Visible = false; // 否則隱藏 label1
                }

                if (textBox12Value > textBox23Value)
                {
                    label12.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox12Value < textBox24Value)
                {
                    label12.Visible = true;
                }
                else
                {
                    label12.Visible = false; // 否則隱藏 label1
                }

                if (textBox15Value > textBox23Value)
                {
                    label21.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox15Value < textBox24Value)
                {
                    label21.Visible = true;
                }
                else
                {
                    label21.Visible = false; // 否則隱藏 label1
                }

                if (textBox18Value > textBox23Value)
                {
                    label24.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox18Value < textBox24Value)
                {
                    label24.Visible = true;
                }
                else
                {
                    label24.Visible = false; // 否則隱藏 label1
                }


            }

        }



    }
}

