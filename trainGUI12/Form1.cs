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
            Form2 form2 = new Form2(); // �Ы� Form2 �����
            form2.Show(); // 
            this.Hide(); // ���÷�e�� Form1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(); // �Ы� Form3 �����
            form3.Show(); // ��� homepagr
            this.Hide(); // ���÷�e�� Form2
        }
    }
}






