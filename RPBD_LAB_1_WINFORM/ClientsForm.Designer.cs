namespace RPBD_LAB_1_WINFORM
{
    partial class ClientsForm
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
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            label5 = new Label();
            maskedTextBox1 = new MaskedTextBox();
            maskedTextBox2 = new MaskedTextBox();
            textBox1 = new TextBox();
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
            label1.Size = new Size(101, 20);
            label1.TabIndex = 2;
            label1.Text = "ФИО клиента";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(83, 144);
            label3.Name = "label3";
            label3.Size = new Size(127, 20);
            label3.TabIndex = 4;
            label3.Text = "Номер телефона";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(83, 222);
            label4.Name = "label4";
            label4.Size = new Size(51, 20);
            label4.TabIndex = 5;
            label4.Text = "Адрес";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(299, 222);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(217, 27);
            textBox2.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(83, 288);
            label5.Name = "label5";
            label5.Size = new Size(42, 20);
            label5.TabIndex = 10;
            label5.Text = "ИНН";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(299, 142);
            maskedTextBox1.Mask = "+7-(000)-000-00-00";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(217, 27);
            maskedTextBox1.TabIndex = 13;
            maskedTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // maskedTextBox2
            // 
            maskedTextBox2.Location = new Point(299, 286);
            maskedTextBox2.Mask = "000000000000";
            maskedTextBox2.Name = "maskedTextBox2";
            maskedTextBox2.Size = new Size(217, 27);
            maskedTextBox2.TabIndex = 14;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(299, 66);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(217, 27);
            textBox1.TabIndex = 15;
            // 
            // ClientsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 553);
            Controls.Add(textBox1);
            Controls.Add(maskedTextBox2);
            Controls.Add(maskedTextBox1);
            Controls.Add(label5);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(OkButton);
            Controls.Add(CancelButton);
            Name = "ClientsForm";
            Text = "ClientsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CancelButton;
        private Button OkButton;
        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private Label label5;
        private MaskedTextBox maskedTextBox1;
        private MaskedTextBox maskedTextBox2;
        private TextBox textBox1;
    }
}