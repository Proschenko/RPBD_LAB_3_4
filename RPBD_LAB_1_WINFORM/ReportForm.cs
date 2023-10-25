using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPBD_LAB_1_WINFORM
{
    public partial class ReportForm : Form
    {
        private DateTime minDate;
        private DateTime maxDate;

        public DateTime MinDate { get { return minDate; } set { minDate = value; } }

        public DateTime MaxDate { get { return maxDate; } set { maxDate = value; } }

        public DataTable ReportDataView
        {
            get { return (DataTable)ReportDataGrid.DataSource; }
            set 
            {
                ReportDataGrid.DataSource = value;
            }
        }

        public ReportForm(DateTime minDat, DateTime maxDat)
        {
            InitializeComponent();
            dateTimePicker1.Value = minDat;
            dateTimePicker2.Value = maxDat;
        }

        private async void ExcelReportButton_Click(object sender, EventArgs e)
        {
            await ExportToExcelAsync();
        }

        private async void WordReportButton_Click(object sender, EventArgs e)
        {
            await ExportToWordAsync();
        }


        private async Task ExportToExcelAsync()
        {
            await Task.Run(() =>
            {
                DataTable dataTable = ReportDataView;
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                // Укажите путь к файлу Excel
                var filePath = @"C:\я у мамы программист\3 курс 1 семестр РПБД\1 лаба\1 лаба но уже на формах\RPBD_LAB_1_WINFORM\Excel_Report_RPBD.xlsx";

                try
                {
                    using (var package = new ExcelPackage())
                    {
                        // Добавляем лист Excel
                        var worksheet = package.Workbook.Worksheets.Add("Отчет");

                        // Создаем шапку таблицы
                        for (int j = 1; j <= dataTable.Columns.Count; j++)
                        {
                            worksheet.Cells[1, j].Value = dataTable.Columns[j - 1].ColumnName;
                        }

                        // Заполняем лист Excel данными из DataTable
                        for (int i = 1; i <= dataTable.Rows.Count; i++)
                        {
                            for (int j = 1; j <= dataTable.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 1, j].Value = dataTable.Rows[i - 1][j - 1].ToString();
                            }
                        }

                        // Сохраняем книгу Excel
                        File.WriteAllBytes(filePath, package.GetAsByteArray());

                        MessageBox.Show("Документ эксель успешно создан и сохранен.");
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла, файл уже открыт");
                }
            });
        }




        private async Task ExportToWordAsync()
        {
            await Task.Run(() =>
            {
                DataTable dataTable = ReportDataView;

                // Укажите путь к файлу Word
                var filePath = @"C:\я у мамы программист\3 курс 1 семестр РПБД\1 лаба\1 лаба но уже на формах\RPBD_LAB_1_WINFORM\Excel_Report_RPBD.docx";

                try
                {
                    // Создаем новый документ Word
                    using (var doc = Xceed.Words.NET.DocX.Create(filePath))
                    {
                        doc.InsertParagraph("Отчет");

                        var table = doc.AddTable(dataTable.Rows.Count + 1, dataTable.Columns.Count);
                        table.Design = Xceed.Document.NET.TableDesign.TableGrid;

                        for (int col = 0; col < dataTable.Columns.Count; col++)
                        {
                            table.Rows[0].Cells[col].InsertParagraph(dataTable.Columns[col].ColumnName);
                        }

                        for (int row = 0; row < dataTable.Rows.Count; row++)
                        {
                            for (int col = 0; col < dataTable.Columns.Count; col++)
                            {
                                table.Rows[row + 1].Cells[col].InsertParagraph(dataTable.Rows[row][col].ToString());
                            }
                        }

                        doc.InsertTable(table);

                        doc.Save();
                    }

                    MessageBox.Show("Документ ворд успешно создан и сохранен.");
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла, файл уже открыт");
                }
            });
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            MinDate = dateTimePicker1.Value;
            ReportDataGrid.DataSource = MyDataBase.JoinDataTables(MinDate, MaxDate);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            MaxDate = dateTimePicker2.Value;
            ReportDataGrid.DataSource = MyDataBase.JoinDataTables(MinDate, MaxDate);
        }
    }
}
