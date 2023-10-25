namespace RPBD_LAB_1_WINFORM
{
    partial class EmployeesForm
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
            CancelButton = new Button();
            OkButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            comboBox1 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            maskedTextBox1 = new MaskedTextBox();
            maskedTextBox2 = new MaskedTextBox();
            maskedTextBox3 = new MaskedTextBox();
            maskedTextBox4 = new MaskedTextBox();
            SuspendLayout();
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(177, 501);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(100, 40);
            CancelButton.TabIndex = 0;
            CancelButton.Text = "Отмена";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // OkButton
            // 
            OkButton.Location = new Point(299, 501);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(100, 40);
            OkButton.TabIndex = 1;
            OkButton.Text = "Ок";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 70);
            label1.Name = "label1";
            label1.Size = new Size(120, 20);
            label1.TabIndex = 2;
            label1.Text = "ФИО работника";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 122);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 3;
            label2.Text = "Дата рождения";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(83, 185);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 4;
            label3.Text = "ИНН";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(83, 241);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 5;
            label4.Text = "СНИЛС";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(299, 67);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(217, 27);
            textBox1.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(83, 306);
            label5.Name = "label5";
            label5.Size = new Size(195, 20);
            label5.TabIndex = 10;
            label5.Text = "Название подразделения*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(83, 364);
            label6.Name = "label6";
            label6.Size = new Size(121, 20);
            label6.TabIndex = 12;
            label6.Text = "Серия паспорта";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(83, 416);
            label7.Name = "label7";
            label7.Size = new Size(126, 20);
            label7.TabIndex = 14;
            label7.Text = "Номер паспорта";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(299, 303);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(217, 28);
            comboBox1.TabIndex = 16;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(299, 117);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(217, 27);
            dateTimePicker1.TabIndex = 17;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(299, 182);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(217, 27);
            maskedTextBox1.TabIndex = 18;
            maskedTextBox1.Mask = "000000000000";

            // 
            // maskedTextBox2
            // 
            maskedTextBox2.Location = new Point(299, 238);
            maskedTextBox2.Name = "maskedTextBox2";
            maskedTextBox2.Size = new Size(217, 27);
            maskedTextBox2.TabIndex = 19;
            maskedTextBox2.Mask = "000-000-000 00";
            maskedTextBox2.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // maskedTextBox3
            // 
            maskedTextBox3.Location = new Point(299, 361);
            maskedTextBox3.Name = "maskedTextBox3";
            maskedTextBox3.Size = new Size(217, 27);
            maskedTextBox3.TabIndex = 20;
            maskedTextBox3.Mask = "00 00";
            maskedTextBox3.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // maskedTextBox4
            // 
            maskedTextBox4.Location = new Point(299, 413);
            maskedTextBox4.Name = "maskedTextBox4";
            maskedTextBox4.Size = new Size(217, 27);
            maskedTextBox4.TabIndex = 21;
            maskedTextBox4.Mask = "000000";
            // 
            // EmployeesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 553);
            Controls.Add(maskedTextBox4);
            Controls.Add(maskedTextBox3);
            Controls.Add(maskedTextBox2);
            Controls.Add(maskedTextBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(OkButton);
            Controls.Add(CancelButton);
            Name = "EmployeesForm";
            Text = "EmployeeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CancelButton;
        private Button OkButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker1;
        private MaskedTextBox maskedTextBox1;
        private MaskedTextBox maskedTextBox2;
        private MaskedTextBox maskedTextBox3;
        private MaskedTextBox maskedTextBox4;
    }
}