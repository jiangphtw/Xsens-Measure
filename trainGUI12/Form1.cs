using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.Reflection;

namespace trainGUI
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void btnclose_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); // 創建 Form2 的實例
            form2.Show(); // 
            this.Hide(); // 隱藏當前的 Form1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(); // 創建 Form3 的實例
            form3.Show(); // 顯示 homepagr
            this.Hide(); // 隱藏當前的 Form2
        }
    }
}






