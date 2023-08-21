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
    public partial class Form2 : Form
    {
        private int targetColumnIndex4 = 4; // 顯示在text4的目標欄位索引
        private int targetColumnIndex5 = 5; // 顯示在text5的目標欄位索引
        private int targetColumnIndex6 = 6; // 顯示在text6的目標欄位索引
        private int targetColumnIndex11 = 11; // 顯示在text4的目標欄位索引
        private int targetColumnIndex12 = 12; // 顯示在text5的目標欄位索引
        private int targetColumnIndex13 = 13; // 顯示在text6的目標欄位索引
        private int targetColumnIndex18 = 18; // 顯示在text4的目標欄位索引
        private int targetColumnIndex19 = 19; // 顯示在text5的目標欄位索引
        private int targetColumnIndex20 = 20; // 顯示在text6的目標欄位索引
        private int targetColumnIndex25 = 25; // 顯示在text4的目標欄位索引
        private int targetColumnIndex26 = 26; // 顯示在text5的目標欄位索引
        private int targetColumnIndex27 = 27; // 顯示在text6的目標欄位索引


        private System.Windows.Forms.Timer updateTimer;
        private string currentFileName;
        private StreamReader reader; // 在這裡聲明 reader 變數


        public Form2()
        {
            InitializeComponent();
            // 初始化 Timer 控制項
            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 100; // 設定時間間隔為 0.1 秒
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

        }

        private void btn_stopms_Click(object sender, EventArgs e)
        {
            try
            {
                // 輸入要關閉的檔案名稱（不含路徑和檔案副檔名）
                string fileNameWithoutExtension = "XsensDeviceAPI Command Line MTw C++ Example";

                // 取得所有符合檔案名稱的進程
                Process[] processes = Process.GetProcessesByName(fileNameWithoutExtension);

                // 若找到符合檔案名稱的進程，則關閉它們
                if (processes.Length > 0)
                {
                    foreach (Process process in processes)
                    {
                        // 關閉進程
                        process.CloseMainWindow();
                        process.WaitForExit(); // 等待進程正常結束
                        process.Dispose();
                    }

                    MessageBox.Show("已成功關閉程式。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("找不到要關閉的程式。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // 若發生錯誤，可以在這裡處理，例如顯示錯誤訊息
                MessageBox.Show("關閉程式時發生錯誤: " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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
                textBox1.Visible = true;
                textBox4.Visible = true;
                textBox7.Visible = true;
                textBox10.Visible = true;

            }
            else
            {
                // 如果 CheckBox 沒有被勾選，隱藏 roll2
                pitch1.Visible = false;
                pitch2.Visible = false;
                pitch3.Visible = false;
                pitch4.Visible = false;
                textBox1.Visible = false;
                textBox4.Visible = false;
                textBox7.Visible = false;
                textBox10.Visible = false;
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
                textBox2.Visible = true;
                textBox5.Visible = true;
                textBox8.Visible = true;
                textBox11.Visible = true;
            }
            else
            {
                // 如果 CheckBox 沒有被勾選，隱藏 roll2
                roll1.Visible = false;
                roll2.Visible = false;
                roll3.Visible = false;
                roll4.Visible = false;
                textBox2.Visible = false;
                textBox5.Visible = false;
                textBox8.Visible = false;
                textBox11.Visible = false;
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
                textBox3.Visible = true;
                textBox6.Visible = true;
                textBox9.Visible = true;
                textBox12.Visible = true;
            }
            else
            {
                // 如果 CheckBox 沒有被勾選，隱藏 roll2
                yaw1.Visible = false;
                yaw2.Visible = false;
                yaw3.Visible = false;
                yaw4.Visible = false;
                textBox3.Visible = false;
                textBox6.Visible = false;
                textBox9.Visible = false;
                textBox12.Visible = false;
            }
        }


        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(); // 創建 Form1 的實例
            form1.Show(); // 顯示 homepagr
            this.Hide(); // 隱藏當前的 Form2
        }

        private void TextBox13_TextChanged(object sender, EventArgs e)
        {
            //UpdateLabelVisibility();
        }



        private void UpdateLabelVisibility()
        {
            // 確保 textBox1.Text 和 TextBox13.Text 都是合法的數值
            if (double.TryParse(textBox1.Text, out double textBox1Value) &&
                double.TryParse(textBox13.Text, out double textBox13Value) &&
                double.TryParse(textBox14.Text, out double textBox14Value) &&
                double.TryParse(textBox4.Text, out double textBox4Value) &&
                double.TryParse(textBox7.Text, out double textBox7Value) &&
                double.TryParse(textBox10.Text, out double textBox10Value))

            {
                if (textBox1Value > textBox13Value)
                {
                    label1.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox1Value < textBox14Value)
                {
                    label1.Visible = true;
                }
                else
                {
                    label1.Visible = false; // 否則隱藏 label1
                }

                if (textBox4Value > textBox13Value)
                {
                    label4.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox4Value < textBox14Value)
                {
                    label4.Visible = true;
                }
                else
                {
                    label4.Visible = false; // 否則隱藏 label1
                }

                if (textBox7Value > textBox13Value)
                {
                    label7.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox7Value < textBox14Value)
                {
                    label7.Visible = true;
                }
                else
                {
                    label7.Visible = false; // 否則隱藏 label1
                }

                if (textBox10Value > textBox13Value)
                {
                    label10.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox10Value < textBox14Value)
                {
                    label10.Visible = true;
                }
                else
                {
                    label10.Visible = false; // 否則隱藏 label1
                }
            }

            if (double.TryParse(textBox2.Text, out double textBox2Value) &&
                double.TryParse(textBox15.Text, out double textBox15Value) &&
                double.TryParse(textBox16.Text, out double textBox16Value) &&
                double.TryParse(textBox5.Text, out double textBox5Value) &&
                double.TryParse(textBox8.Text, out double textBox8Value) &&
                double.TryParse(textBox11.Text, out double textBox11Value))
            {
                if (textBox2Value > textBox15Value)
                {
                    label2.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox2Value < textBox16Value)
                {
                    label2.Visible = true;
                }
                else
                {
                    label2.Visible = false; // 否則隱藏 label1
                }

                if (textBox5Value > textBox15Value)
                {
                    label5.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox5Value < textBox16Value)
                {
                    label5.Visible = true;
                }
                else
                {
                    label5.Visible = false; // 否則隱藏 label1
                }

                if (textBox8Value > textBox15Value)
                {
                    label8.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox8Value < textBox16Value)
                {
                    label8.Visible = true;
                }
                else
                {
                    label8.Visible = false; // 否則隱藏 label1
                }

                if (textBox11Value > textBox15Value)
                {
                    label11.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox11Value < textBox16Value)
                {
                    label11.Visible = true;
                }
                else
                {
                    label11.Visible = false; // 否則隱藏 label1
                }
            }

            if (double.TryParse(textBox3.Text, out double textBox3Value) &&
               double.TryParse(textBox17.Text, out double textBox17Value) &&
               double.TryParse(textBox18.Text, out double textBox18Value) &&
               double.TryParse(textBox6.Text, out double textBox6Value) &&
               double.TryParse(textBox9.Text, out double textBox9Value) &&
               double.TryParse(textBox12.Text, out double textBox12Value))
            {
                if (textBox3Value > textBox17Value)
                {
                    label3.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox3Value < textBox18Value)
                {
                    label3.Visible = true;
                }
                else
                {
                    label3.Visible = false; // 否則隱藏 label1
                }

                if (textBox6Value > textBox17Value)
                {
                    label6.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox6Value < textBox18Value)
                {
                    label6.Visible = true;
                }
                else
                {
                    label6.Visible = false; // 否則隱藏 label1
                }

                if (textBox9Value > textBox17Value)
                {
                    label9.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox9Value < textBox18Value)
                {
                    label9.Visible = true;
                }
                else
                {
                    label9.Visible = false; // 否則隱藏 label1
                }

                if (textBox12Value > textBox17Value)
                {
                    label12.Visible = true; // 如果 textBox1 的數值大於 textBox13 的數值，顯示 label1
                }
                else if (textBox12Value < textBox18Value)
                {
                    label12.Visible = true;
                }
                else
                {
                    label12.Visible = false; // 否則隱藏 label1
                }



            }

        }


    }

}