namespace RPBD_LAB_1_WINFORM
{
    partial class WorkForm
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
            label5 = new Label();
            textBox1 = new TextBox();
            label6 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
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
            label1.Location = new Point(83, 52);
            label1.Name = "label1";
            label1.Size = new Size(143, 20);
            label1.TabIndex = 2;
            label1.Text = "Название объекта*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 117);
            label2.Name = "label2";
            label2.Size = new Size(139, 20);
            label2.TabIndex = 3;
            label2.Text = "Название работы*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(83, 195);
            label3.Name = "label3";
            label3.Size = new Size(126, 20);
            label3.TabIndex = 4;
            label3.Text = "ФИО работника*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(83, 264);
            label4.Name = "label4";
            label4.Size = new Size(150, 20);
            label4.TabIndex = 5;
            label4.Text = "Дата начала работы";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(83, 333);
            label5.Name = "label5";
            label5.Size = new Size(177, 20);
            label5.TabIndex = 10;
            label5.Text = "Дата окончания работы";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(299, 404);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(222, 27);
            textBox1.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(83, 404);
            label6.Name = "label6";
            label6.Size = new Size(124, 20);
            label6.TabIndex = 12;
            label6.Text = "Описание работ";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(299, 49);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(222, 28);
            comboBox1.TabIndex = 14;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(299, 114);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(222, 28);
            comboBox2.TabIndex = 14;
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(299, 192);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(222, 28);
            comboBox3.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(299, 259);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(222, 27);
            dateTimePicker1.TabIndex = 15;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(299, 328);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(222, 27);
            dateTimePicker2.TabIndex = 16;
            // 
            // WorkForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 553);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(OkButton);
            Controls.Add(CancelButton);
            Name = "WorkForm";
            Text = "WorkForm";
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
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox6;
        private Label label6;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
    }
}