namespace RPBD_LAB_1_WINFORM
{
    partial class JobListForm
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
            label2 = new Label();
            textBox2 = new TextBox();
            label6 = new Label();
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 245);
            label2.Name = "label2";
            label2.Size = new Size(133, 20);
            label2.TabIndex = 3;
            label2.Text = "Название работы";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(299, 242);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(225, 27);
            textBox2.TabIndex = 7;
            // 
            // label6
            // 
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 0;
            // 
            // JobListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 553);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(OkButton);
            Controls.Add(CancelButton);
            Name = "JobListForm";
            Text = "JobListForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CancelButton;
        private Button OkButton;
        private Label label2;
        private TextBox textBox2;
        private Label label6;
    }
}