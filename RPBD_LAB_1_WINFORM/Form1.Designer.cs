namespace RPBD_LAB_1_WINFORM
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
            dataGridView = new DataGridView();
            AddButton = new Button();
            EditButton = new Button();
            DeleteButton = new Button();
            MainComboBox = new ComboBox();
            ReportButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.Location = new Point(304, 12);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(866, 429);
            dataGridView.TabIndex = 0;
            
            // 
            // AddButton
            // 
            AddButton.Location = new Point(12, 108);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(240, 60);
            AddButton.TabIndex = 1;
            AddButton.Text = "Добавить";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // EditButton
            // 
            EditButton.Location = new Point(12, 187);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(240, 60);
            EditButton.TabIndex = 2;
            EditButton.Text = "Редактирование";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(12, 264);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(240, 60);
            DeleteButton.TabIndex = 3;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click_1;
            // 
            // MainComboBox
            // 
            MainComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            MainComboBox.FormattingEnabled = true;
            MainComboBox.Location = new Point(12, 12);
            MainComboBox.Name = "MainComboBox";
            MainComboBox.Size = new Size(240, 28);
            MainComboBox.TabIndex = 4;
            MainComboBox.SelectedIndexChanged += MainComboBox_SelectedIndexChanged;
            // 
            // ReportButton
            // 
            ReportButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ReportButton.Location = new Point(12, 381);
            ReportButton.Name = "ReportButton";
            ReportButton.Size = new Size(240, 60);
            ReportButton.TabIndex = 5;
            ReportButton.Text = "Сформировать отчет";
            ReportButton.UseVisualStyleBackColor = true;
            ReportButton.Click += ReportButton_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 453);
            Controls.Add(ReportButton);
            Controls.Add(MainComboBox);
            Controls.Add(DeleteButton);
            Controls.Add(EditButton);
            Controls.Add(AddButton);
            Controls.Add(dataGridView);
            MinimumSize = new Size(1200, 500);
            Name = "Form1";
            Text = "1C beta by ЦЕХ";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private Button AddButton;
        private Button EditButton;
        private Button DeleteButton;
        private ComboBox MainComboBox;
        private Button ReportButton;
    }
}