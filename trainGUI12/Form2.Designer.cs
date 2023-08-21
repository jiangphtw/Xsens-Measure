namespace trainGUI
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pitch1 = new PictureBox();
            roll1 = new PictureBox();
            yaw1 = new PictureBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            btnload = new Button();
            btnstart = new Button();
            btngo = new Button();
            pitch2 = new PictureBox();
            textBox4 = new TextBox();
            pitch3 = new PictureBox();
            pitch4 = new PictureBox();
            textBox7 = new TextBox();
            textBox10 = new TextBox();
            roll2 = new PictureBox();
            textBox5 = new TextBox();
            yaw2 = new PictureBox();
            textBox6 = new TextBox();
            roll3 = new PictureBox();
            roll4 = new PictureBox();
            yaw3 = new PictureBox();
            yaw4 = new PictureBox();
            textBox8 = new TextBox();
            textBox11 = new TextBox();
            textBox9 = new TextBox();
            textBox12 = new TextBox();
            btn_stopms = new Button();
            btnclose = new Button();
            btnhome = new Button();
            btnstoprun = new Button();
            btnagain = new Button();
            textBox13 = new TextBox();
            label1 = new Label();
            label4 = new Label();
            label7 = new Label();
            label10 = new Label();
            label3 = new Label();
            label6 = new Label();
            label9 = new Label();
            label12 = new Label();
            label2 = new Label();
            label5 = new Label();
            label8 = new Label();
            label11 = new Label();
            textBox14 = new TextBox();
            textBox15 = new TextBox();
            textBox17 = new TextBox();
            textBox16 = new TextBox();
            textBox18 = new TextBox();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pitch1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roll1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)yaw1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pitch2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pitch3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pitch4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roll2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)yaw2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roll3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roll4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)yaw3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)yaw4).BeginInit();
            SuspendLayout();
            // 
            // pitch1
            // 
            pitch1.Image = Properties.Resources._1;
            pitch1.Location = new Point(28, 31);
            pitch1.Margin = new Padding(5);
            pitch1.Name = "pitch1";
            pitch1.Size = new Size(300, 300);
            pitch1.SizeMode = PictureBoxSizeMode.StretchImage;
            pitch1.TabIndex = 0;
            pitch1.TabStop = false;
            pitch1.Visible = false;
            // 
            // roll1
            // 
            roll1.Image = Properties.Resources._4;
            roll1.Location = new Point(28, 445);
            roll1.Margin = new Padding(5);
            roll1.Name = "roll1";
            roll1.Size = new Size(300, 300);
            roll1.SizeMode = PictureBoxSizeMode.StretchImage;
            roll1.TabIndex = 1;
            roll1.TabStop = false;
            roll1.Visible = false;
            // 
            // yaw1
            // 
            yaw1.Image = Properties.Resources._3;
            yaw1.Location = new Point(28, 819);
            yaw1.Margin = new Padding(5);
            yaw1.Name = "yaw1";
            yaw1.Size = new Size(300, 300);
            yaw1.SizeMode = PictureBoxSizeMode.StretchImage;
            yaw1.TabIndex = 2;
            yaw1.TabStop = false;
            yaw1.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("微軟正黑體", 36F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(49, 233);
            textBox1.Margin = new Padding(5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(265, 103);
            textBox1.TabIndex = 3;
            textBox1.Text = "--------";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("微軟正黑體", 36F, FontStyle.Bold, GraphicsUnit.Point);
            textBox2.Location = new Point(49, 644);
            textBox2.Margin = new Padding(5);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(265, 103);
            textBox2.TabIndex = 3;
            textBox2.Text = "--------";
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.Visible = false;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("微軟正黑體", 36F, FontStyle.Bold, GraphicsUnit.Point);
            textBox3.Location = new Point(49, 1017);
            textBox3.Margin = new Padding(5);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(265, 103);
            textBox3.TabIndex = 3;
            textBox3.Text = "--------";
            textBox3.TextAlign = HorizontalAlignment.Center;
            textBox3.Visible = false;
            // 
            // btnload
            // 
            btnload.Location = new Point(1594, 902);
            btnload.Margin = new Padding(5);
            btnload.Name = "btnload";
            btnload.Size = new Size(156, 52);
            btnload.TabIndex = 4;
            btnload.Text = "載入數據";
            btnload.UseVisualStyleBackColor = true;
            btnload.Click += btnload_Click;
            // 
            // btnstart
            // 
            btnstart.Location = new Point(1594, 495);
            btnstart.Name = "btnstart";
            btnstart.Size = new Size(156, 52);
            btnstart.TabIndex = 5;
            btnstart.Text = "呼叫量測";
            btnstart.UseVisualStyleBackColor = true;
            btnstart.Click += btnstart_Click;
            // 
            // btngo
            // 
            btngo.Location = new Point(1594, 822);
            btngo.Name = "btngo";
            btngo.Size = new Size(156, 52);
            btngo.TabIndex = 6;
            btngo.Text = "開始測量";
            btngo.UseVisualStyleBackColor = true;
            btngo.Click += btngo_Click;
            // 
            // pitch2
            // 
            pitch2.Image = Properties.Resources._1;
            pitch2.Location = new Point(402, 31);
            pitch2.Margin = new Padding(5);
            pitch2.Name = "pitch2";
            pitch2.Size = new Size(300, 300);
            pitch2.SizeMode = PictureBoxSizeMode.StretchImage;
            pitch2.TabIndex = 0;
            pitch2.TabStop = false;
            pitch2.Visible = false;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("微軟正黑體", 36F, FontStyle.Bold, GraphicsUnit.Point);
            textBox4.Location = new Point(424, 233);
            textBox4.Margin = new Padding(5);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(265, 103);
            textBox4.TabIndex = 3;
            textBox4.Text = "--------";
            textBox4.TextAlign = HorizontalAlignment.Center;
            textBox4.Visible = false;
            // 
            // pitch3
            // 
            pitch3.Image = Properties.Resources._1;
            pitch3.Location = new Point(786, 31);
            pitch3.Margin = new Padding(5);
            pitch3.Name = "pitch3";
            pitch3.Size = new Size(300, 300);
            pitch3.SizeMode = PictureBoxSizeMode.StretchImage;
            pitch3.TabIndex = 0;
            pitch3.TabStop = false;
            pitch3.Visible = false;
            // 
            // pitch4
            // 
            pitch4.Image = Properties.Resources._1;
            pitch4.Location = new Point(1188, 31);
            pitch4.Margin = new Padding(5);
            pitch4.Name = "pitch4";
            pitch4.Size = new Size(300, 300);
            pitch4.SizeMode = PictureBoxSizeMode.StretchImage;
            pitch4.TabIndex = 0;
            pitch4.TabStop = false;
            pitch4.Visible = false;
            // 
            // textBox7
            // 
            textBox7.Font = new Font("微軟正黑體", 36F, FontStyle.Bold, GraphicsUnit.Point);
            textBox7.Location = new Point(801, 233);
            textBox7.Margin = new Padding(5);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(265, 103);
            textBox7.TabIndex = 3;
            textBox7.Text = "--------";
            textBox7.TextAlign = HorizontalAlignment.Center;
            textBox7.Visible = false;
            // 
            // textBox10
            // 
            textBox10.Font = new Font("微軟正黑體", 36F, FontStyle.Bold, GraphicsUnit.Point);
            textBox10.Location = new Point(1205, 233);
            textBox10.Margin = new Padding(5);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(265, 103);
            textBox10.TabIndex = 3;
            textBox10.Text = "--------";
            textBox10.TextAlign = HorizontalAlignment.Center;
            textBox10.Visible = false;
            // 
            // roll2
            // 
            roll2.Image = Properties.Resources._4;
            roll2.Location = new Point(402, 447);
            roll2.Margin = new Padding(5);
            roll2.Name = "roll2";
            roll2.Size = new Size(300, 300);
            roll2.SizeMode = PictureBoxSizeMode.StretchImage;
            roll2.TabIndex = 1;
            roll2.TabStop = false;
            roll2.Visible = false;
            // 
            // textBox5
            // 
            textBox5.Font = new Font("微軟正黑體", 36F, FontStyle.Bold, GraphicsUnit.Point);
            textBox5.Location = new Point(424, 644);
            textBox5.Margin = new Padding(5);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(265, 103);
            textBox5.TabIndex = 3;
            textBox5.Text = "--------";
            textBox5.TextAlign = HorizontalAlignment.Center;
            textBox5.Visible = false;
            // 
            // yaw2
            // 
            yaw2.Image = Properties.Resources._3;
            yaw2.Location = new Point(402, 819);
            yaw2.Margin = new Padding(5);
            yaw2.Name = "yaw2";
            yaw2.Size = new Size(300, 300);
            yaw2.SizeMode = PictureBoxSizeMode.StretchImage;
            yaw2.TabIndex = 2;
            yaw2.TabStop = false;
            yaw2.Visible = false;
            // 
            // textBox6
            // 
            textBox6.Font = new Font("微軟正黑體", 36F, FontStyle.Bold, GraphicsUnit.Point);
            textBox6.Location = new Point(424, 1017);
            textBox6.Margin = new Padding(5);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(265, 103);
            textBox6.TabIndex = 3;
            textBox6.Text = "--------";
            textBox6.TextAlign = HorizontalAlignment.Center;
            textBox6.Visible = false;
            // 
            // roll3
            // 
            roll3.Image = Properties.Resources._4;
            roll3.Location = new Point(786, 445);
            roll3.Margin = new Padding(5);
            roll3.Name = "roll3";
            roll3.Size = new Size(300, 300);
            roll3.SizeMode = PictureBoxSizeMode.StretchImage;
            roll3.TabIndex = 1;
            roll3.TabStop = false;
            roll3.Visible = false;
            // 
            // roll4
            // 
            roll4.Image = Properties.Resources._4;
            roll4.Location = new Point(1188, 447);
            roll4.Margin = new Padding(5);
            roll4.Name = "roll4";
            roll4.Size = new Size(300, 300);
            roll4.SizeMode = PictureBoxSizeMode.StretchImage;
            roll4.TabIndex = 1;
            roll4.TabStop = false;
            roll4.Visible = false;
            // 
            // yaw3
            // 
            yaw3.Image = Properties.Resources._3;
            yaw3.Location = new Point(786, 820);
            yaw3.Margin = new Padding(5);
            yaw3.Name = "yaw3";
            yaw3.Size = new Size(300, 300);
            yaw3.SizeMode = PictureBoxSizeMode.StretchImage;
            yaw3.TabIndex = 2;
            yaw3.TabStop = false;
            yaw3.Visible = false;
            // 
            // yaw4
            // 
            yaw4.Image = Properties.Resources._3;
            yaw4.Location = new Point(1188, 820);
            yaw4.Margin = new Padding(5);
            yaw4.Name = "yaw4";
            yaw4.Size = new Size(300, 300);
            yaw4.SizeMode = PictureBoxSizeMode.StretchImage;
            yaw4.TabIndex = 2;
            yaw4.TabStop = false;
            yaw4.Visible = false;
            // 
            // textBox8
            // 
            textBox8.Font = new Font("微軟正黑體", 36F, FontStyle.Bold, GraphicsUnit.Point);
            textBox8.Location = new Point(801, 644);
            textBox8.Margin = new Padding(5);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(265, 103);
            textBox8.TabIndex = 3;
            textBox8.Text = "--------";
            textBox8.TextAlign = HorizontalAlignment.Center;
            textBox8.Visible = false;
            // 
            // textBox11
            // 
            textBox11.Font = new Font("微軟正黑體", 36F, FontStyle.Bold, GraphicsUnit.Point);
            textBox11.Location = new Point(1205, 644);
            textBox11.Margin = new Padding(5);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(265, 103);
            textBox11.TabIndex = 3;
            textBox11.Text = "--------";
            textBox11.TextAlign = HorizontalAlignment.Center;
            textBox11.Visible = false;
            // 
            // textBox9
            // 
            textBox9.Font = new Font("微軟正黑體", 36F, FontStyle.Bold, GraphicsUnit.Point);
            textBox9.Location = new Point(801, 1017);
            textBox9.Margin = new Padding(5);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(265, 103);
            textBox9.TabIndex = 3;
            textBox9.Text = "--------";
            textBox9.TextAlign = HorizontalAlignment.Center;
            textBox9.Visible = false;
            // 
            // textBox12
            // 
            textBox12.Font = new Font("微軟正黑體", 36F, FontStyle.Bold, GraphicsUnit.Point);
            textBox12.Location = new Point(1205, 1017);
            textBox12.Margin = new Padding(5);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(265, 103);
            textBox12.TabIndex = 3;
            textBox12.Text = "--------";
            textBox12.TextAlign = HorizontalAlignment.Center;
            textBox12.Visible = false;
            // 
            // btn_stopms
            // 
            btn_stopms.Location = new Point(1594, 570);
            btn_stopms.Name = "btn_stopms";
            btn_stopms.Size = new Size(156, 52);
            btn_stopms.TabIndex = 7;
            btn_stopms.Text = "關閉量測";
            btn_stopms.UseVisualStyleBackColor = true;
            btn_stopms.Click += btn_stopms_Click;
            // 
            // btnclose
            // 
            btnclose.Location = new Point(1594, 649);
            btnclose.Name = "btnclose";
            btnclose.Size = new Size(156, 52);
            btnclose.TabIndex = 8;
            btnclose.Text = "關閉應用程式";
            btnclose.UseVisualStyleBackColor = true;
            btnclose.Click += btnclose_Click;
            // 
            // btnhome
            // 
            btnhome.Location = new Point(1594, 736);
            btnhome.Name = "btnhome";
            btnhome.Size = new Size(156, 52);
            btnhome.TabIndex = 9;
            btnhome.Text = "主頁面";
            btnhome.UseVisualStyleBackColor = true;
            btnhome.Click += btnhome_Click;
            // 
            // btnstoprun
            // 
            btnstoprun.Location = new Point(1594, 981);
            btnstoprun.Name = "btnstoprun";
            btnstoprun.Size = new Size(156, 52);
            btnstoprun.TabIndex = 10;
            btnstoprun.Text = "停止";
            btnstoprun.UseVisualStyleBackColor = true;
            // 
            // btnagain
            // 
            btnagain.Location = new Point(1594, 1058);
            btnagain.Name = "btnagain";
            btnagain.Size = new Size(156, 52);
            btnagain.TabIndex = 11;
            btnagain.Text = "重新測量";
            btnagain.UseVisualStyleBackColor = true;
            // 
            // textBox13
            // 
            textBox13.Location = new Point(1529, 74);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(125, 30);
            textBox13.TabIndex = 12;
            textBox13.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Yellow;
            label1.Font = new Font("Constantia", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(74, 169);
            label1.Name = "label1";
            label1.Size = new Size(220, 59);
            label1.TabIndex = 14;
            label1.Text = "Warning";
            label1.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Yellow;
            label4.Font = new Font("Constantia", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(452, 169);
            label4.Name = "label4";
            label4.Size = new Size(220, 59);
            label4.TabIndex = 14;
            label4.Text = "Warning";
            label4.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Yellow;
            label7.Font = new Font("Constantia", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(828, 169);
            label7.Name = "label7";
            label7.Size = new Size(220, 59);
            label7.TabIndex = 14;
            label7.Text = "Warning";
            label7.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Yellow;
            label10.Font = new Font("Constantia", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.Red;
            label10.Location = new Point(1234, 169);
            label10.Name = "label10";
            label10.Size = new Size(220, 59);
            label10.TabIndex = 14;
            label10.Text = "Warning";
            label10.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Yellow;
            label3.Font = new Font("Constantia", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(74, 953);
            label3.Name = "label3";
            label3.Size = new Size(220, 59);
            label3.TabIndex = 14;
            label3.Text = "Warning";
            label3.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Yellow;
            label6.Font = new Font("Constantia", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(452, 953);
            label6.Name = "label6";
            label6.Size = new Size(220, 59);
            label6.TabIndex = 14;
            label6.Text = "Warning";
            label6.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Yellow;
            label9.Font = new Font("Constantia", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Red;
            label9.Location = new Point(828, 953);
            label9.Name = "label9";
            label9.Size = new Size(220, 59);
            label9.TabIndex = 14;
            label9.Text = "Warning";
            label9.Visible = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Yellow;
            label12.Font = new Font("Constantia", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.Red;
            label12.Location = new Point(1234, 953);
            label12.Name = "label12";
            label12.Size = new Size(220, 59);
            label12.TabIndex = 14;
            label12.Text = "Warning";
            label12.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Yellow;
            label2.Font = new Font("Constantia", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(74, 580);
            label2.Name = "label2";
            label2.Size = new Size(220, 59);
            label2.TabIndex = 14;
            label2.Text = "Warning";
            label2.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Yellow;
            label5.Font = new Font("Constantia", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(452, 580);
            label5.Name = "label5";
            label5.Size = new Size(220, 59);
            label5.TabIndex = 14;
            label5.Text = "Warning";
            label5.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Yellow;
            label8.Font = new Font("Constantia", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(828, 580);
            label8.Name = "label8";
            label8.Size = new Size(220, 59);
            label8.TabIndex = 14;
            label8.Text = "Warning";
            label8.Visible = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Yellow;
            label11.Font = new Font("Constantia", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.Red;
            label11.Location = new Point(1234, 580);
            label11.Name = "label11";
            label11.Size = new Size(220, 59);
            label11.TabIndex = 14;
            label11.Text = "Warning";
            label11.Visible = false;
            // 
            // textBox14
            // 
            textBox14.Location = new Point(1688, 74);
            textBox14.Name = "textBox14";
            textBox14.Size = new Size(125, 30);
            textBox14.TabIndex = 12;
            textBox14.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox15
            // 
            textBox15.Location = new Point(1529, 141);
            textBox15.Name = "textBox15";
            textBox15.Size = new Size(125, 30);
            textBox15.TabIndex = 12;
            textBox15.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox17
            // 
            textBox17.Location = new Point(1529, 208);
            textBox17.Name = "textBox17";
            textBox17.Size = new Size(125, 30);
            textBox17.TabIndex = 12;
            textBox17.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox16
            // 
            textBox16.Location = new Point(1688, 141);
            textBox16.Name = "textBox16";
            textBox16.Size = new Size(125, 30);
            textBox16.TabIndex = 12;
            textBox16.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox18
            // 
            textBox18.Location = new Point(1688, 208);
            textBox18.Name = "textBox18";
            textBox18.Size = new Size(125, 30);
            textBox18.TabIndex = 12;
            textBox18.TextAlign = HorizontalAlignment.Center;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(1539, 48);
            label13.Name = "label13";
            label13.Size = new Size(82, 23);
            label13.TabIndex = 15;
            label13.Text = "前後上限";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(1698, 48);
            label14.Name = "label14";
            label14.Size = new Size(82, 23);
            label14.TabIndex = 16;
            label14.Text = "前後下限";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(1539, 115);
            label15.Name = "label15";
            label15.Size = new Size(82, 23);
            label15.TabIndex = 17;
            label15.Text = "左右上限";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(1698, 115);
            label16.Name = "label16";
            label16.Size = new Size(82, 23);
            label16.TabIndex = 18;
            label16.Text = "左右下限";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(1539, 182);
            label17.Name = "label17";
            label17.Size = new Size(82, 23);
            label17.TabIndex = 19;
            label17.Text = "旋轉上限";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(1698, 182);
            label18.Name = "label18";
            label18.Size = new Size(82, 23);
            label18.TabIndex = 20;
            label18.Text = "旋轉下限";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(1625, 286);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(72, 27);
            checkBox1.TabIndex = 21;
            checkBox1.Text = "前後";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(1625, 319);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(72, 27);
            checkBox2.TabIndex = 22;
            checkBox2.Text = "左右";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(1625, 352);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(72, 27);
            checkBox3.TabIndex = 23;
            checkBox3.Text = "旋轉";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2500, 1400);
            Controls.Add(textBox12);
            Controls.Add(textBox6);
            Controls.Add(textBox9);
            Controls.Add(textBox3);
            Controls.Add(textBox11);
            Controls.Add(textBox5);
            Controls.Add(textBox8);
            Controls.Add(textBox2);
            Controls.Add(textBox10);
            Controls.Add(textBox4);
            Controls.Add(textBox7);
            Controls.Add(textBox1);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(label10);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(textBox16);
            Controls.Add(textBox14);
            Controls.Add(textBox18);
            Controls.Add(textBox17);
            Controls.Add(textBox15);
            Controls.Add(textBox13);
            Controls.Add(btnagain);
            Controls.Add(btnstoprun);
            Controls.Add(btnhome);
            Controls.Add(btnclose);
            Controls.Add(btn_stopms);
            Controls.Add(btngo);
            Controls.Add(btnstart);
            Controls.Add(btnload);
            Controls.Add(yaw4);
            Controls.Add(yaw2);
            Controls.Add(yaw3);
            Controls.Add(yaw1);
            Controls.Add(roll4);
            Controls.Add(roll3);
            Controls.Add(roll2);
            Controls.Add(roll1);
            Controls.Add(pitch4);
            Controls.Add(pitch3);
            Controls.Add(pitch2);
            Controls.Add(pitch1);
            Name = "Form2";
            Text = "四人模式";
            ((System.ComponentModel.ISupportInitialize)pitch1).EndInit();
            ((System.ComponentModel.ISupportInitialize)roll1).EndInit();
            ((System.ComponentModel.ISupportInitialize)yaw1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pitch2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pitch3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pitch4).EndInit();
            ((System.ComponentModel.ISupportInitialize)roll2).EndInit();
            ((System.ComponentModel.ISupportInitialize)yaw2).EndInit();
            ((System.ComponentModel.ISupportInitialize)roll3).EndInit();
            ((System.ComponentModel.ISupportInitialize)roll4).EndInit();
            ((System.ComponentModel.ISupportInitialize)yaw3).EndInit();
            ((System.ComponentModel.ISupportInitialize)yaw4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pitch1;
        private PictureBox roll1;
        private PictureBox yaw1;
        private PictureBox pitch2;
        private PictureBox roll2;
        private PictureBox yaw2;
        private PictureBox pitch3;
        private PictureBox roll3;
        private PictureBox yaw3;
        private PictureBox pitch4;
        private PictureBox roll4;
        private PictureBox yaw4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button btnload;
        private Button btnstart;
        private Button btngo;
        private TextBox textBox4;
        private TextBox textBox7;
        private TextBox textBox10;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox8;
        private TextBox textBox11;
        private TextBox textBox9;
        private TextBox textBox12;
        private Button btn_stopms;
        private Button btnclose;
        private Button btnhome;
        private Button btnstoprun;
        private Button btnagain;
        private TextBox textBox13;

        private Label label1;
        private Label label4;
        private Label label7;
        private Label label10;
        private Label label3;
        private Label label6;
        private Label label9;
        private Label label12;
        private Label label2;
        private Label label5;
        private Label label8;
        private Label label11;
        private TextBox textBox14;
        private TextBox textBox15;
        private TextBox textBox17;
        private TextBox textBox16;
        private TextBox textBox18;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
    }
}