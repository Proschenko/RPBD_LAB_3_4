namespace RPBD_LAB_1_WINFORM
{
    partial class ReportForm
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
            this.ReportDataGrid = new System.Windows.Forms.DataGridView();
            this.ExcelReportButton = new System.Windows.Forms.Button();
            this.WordReportButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportDataGrid
            // 
            this.ReportDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReportDataGrid.AllowUserToAddRows = false;
            this.ReportDataGrid.ReadOnly=true;
            this.ReportDataGrid.Location = new System.Drawing.Point(75, 102);
            this.ReportDataGrid.Margin = new System.Windows.Forms.Padding(4);
            this.ReportDataGrid.Name = "ReportDataGrid";
            this.ReportDataGrid.RowHeadersWidth = 51;
            this.ReportDataGrid.RowTemplate.Height = 29;
            this.ReportDataGrid.Size = new System.Drawing.Size(726, 368);
            this.ReportDataGrid.TabIndex = 0;
            // 
            // ExcelReportButton
            // 
            this.ExcelReportButton.Location = new System.Drawing.Point(75, 483);
            this.ExcelReportButton.Margin = new System.Windows.Forms.Padding(4);
            this.ExcelReportButton.Name = "ExcelReportButton";
            this.ExcelReportButton.Size = new System.Drawing.Size(284, 66);
            this.ExcelReportButton.TabIndex = 1;
            this.ExcelReportButton.Text = "Отчет в Excel";
            this.ExcelReportButton.UseVisualStyleBackColor = true;
            this.ExcelReportButton.Click += new System.EventHandler(this.ExcelReportButton_Click);
            // 
            // WordReportButton
            // 
            this.WordReportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WordReportButton.Location = new System.Drawing.Point(517, 483);
            this.WordReportButton.Margin = new System.Windows.Forms.Padding(4);
            this.WordReportButton.Name = "WordReportButton";
            this.WordReportButton.Size = new System.Drawing.Size(284, 66);
            this.WordReportButton.TabIndex = 2;
            this.WordReportButton.Text = "Отчет в Word";
            this.WordReportButton.UseVisualStyleBackColor = true;
            this.WordReportButton.Click += new System.EventHandler(this.WordReportButton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(75, 36);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(300, 31);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(501, 36);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(300, 31);
            this.dateTimePicker2.TabIndex = 4;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "От:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(636, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "До:";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 562);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.WordReportButton);
            this.Controls.Add(this.ExcelReportButton);
            this.Controls.Add(this.ReportDataGrid);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView ReportDataGrid;
        private Button ExcelReportButton;
        private Button WordReportButton;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private Label label2;
    }
}