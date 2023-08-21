namespace trainGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnclose = new Button();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // btnclose
            // 
            btnclose.Location = new Point(267, 473);
            btnclose.Name = "btnclose";
            btnclose.Size = new Size(112, 34);
            btnclose.TabIndex = 2;
            btnclose.Text = "關閉程式";
            btnclose.UseVisualStyleBackColor = true;
            btnclose.Click += btnclose_Click;
            // 
            // button1
            // 
            button1.Location = new Point(267, 223);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 3;
            button1.Text = "四人模式";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(267, 329);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 4;
            button2.Text = "六人模式";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 519);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnclose);
            Name = "Form1";
            Text = "homepage";
            ResumeLayout(false);
        }

        #endregion
        private Button btnclose;
        private Button button1;
        private Button button2;
    }
}