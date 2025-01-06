namespace PassMan
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
            panel1 = new Panel();
            dgvPasswords = new DataGridView();
            Btn_Newpass = new Button();
            Btn_newCategory = new Button();
            Btn_Options = new Button();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPasswords).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvPasswords);
            panel1.Location = new Point(12, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(480, 366);
            panel1.TabIndex = 0;
            // 
            // dgvPasswords
            // 
            dgvPasswords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPasswords.Location = new Point(0, 3);
            dgvPasswords.Name = "dgvPasswords";
            dgvPasswords.Size = new Size(477, 360);
            dgvPasswords.TabIndex = 0;
            // 
            // Btn_Newpass
            // 
            Btn_Newpass.Location = new Point(387, 415);
            Btn_Newpass.Name = "Btn_Newpass";
            Btn_Newpass.Size = new Size(102, 23);
            Btn_Newpass.TabIndex = 1;
            Btn_Newpass.Text = "New password";
            Btn_Newpass.UseVisualStyleBackColor = true;
            Btn_Newpass.Click += Btn_Newpass_Click;
            // 
            // Btn_newCategory
            // 
            Btn_newCategory.Location = new Point(292, 11);
            Btn_newCategory.Name = "Btn_newCategory";
            Btn_newCategory.Size = new Size(119, 23);
            Btn_newCategory.TabIndex = 2;
            Btn_newCategory.Text = "New category";
            Btn_newCategory.UseVisualStyleBackColor = true;
            // 
            // Btn_Options
            // 
            Btn_Options.Location = new Point(417, 11);
            Btn_Options.Name = "Btn_Options";
            Btn_Options.Size = new Size(75, 23);
            Btn_Options.TabIndex = 3;
            Btn_Options.Text = "Options";
            Btn_Options.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(12, 415);
            button1.Name = "button1";
            button1.Size = new Size(102, 23);
            button1.TabIndex = 5;
            button1.Text = "Edit password";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(120, 415);
            button2.Name = "button2";
            button2.Size = new Size(102, 23);
            button2.TabIndex = 6;
            button2.Text = "Remove";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(Btn_Newpass);
            Controls.Add(Btn_Options);
            Controls.Add(Btn_newCategory);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPasswords).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button Btn_Newpass;
        private Button Btn_newCategory;
        private Button Btn_Options;
        private DataGridView dgvPasswords;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
    }
}
