using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RPBD_LAB_1_WINFORM
{
    public partial class JobListForm : Form
    {
        private bool _isEditMode;
        private int _indexEditJobListDataTable;
        private DataTable activeDataTable = MyDataBase.jobListTable;
        public JobListForm(bool isEditMode, DataGridView dataGridView)
        {
            InitializeComponent();
            _isEditMode = isEditMode;
            if (_isEditMode)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                    object cellValue = selectedRow.Cells[1].Value;
                    textBox2.Text = cellValue.ToString();
                    DataRow[] foundRows = activeDataTable.Select("job_name = '" + textBox2.Text + "'");

                    if (foundRows.Length > 0)
                    {
                        _indexEditJobListDataTable = Convert.ToInt32(foundRows[0]["joblist_id"]);
                    }
                }
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            string newJobListName = textBox2.Text;

            // Проверка на дубликаты
            bool isDuplicate = false;
            foreach (DataRow existingRow in MyDataBase.jobListTable.Rows)
            {
                if (newJobListName.Equals(existingRow["job_name"].ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    if (existingRow["joblist_id"].ToString() != _indexEditJobListDataTable.ToString())
                    {
                        isDuplicate = true;
                        break;
                    }
                }
            }

            if (newJobListName != "")
            {
                if (!isDuplicate)
                {
                    if (_isEditMode)
                    {
                        //Редактирование
                        DataRow[] foundRows = activeDataTable.Select("joblist_id = " + _indexEditJobListDataTable);
                        foundRows[0]["job_name"] = newJobListName;
                    }
                    else
                    {
                        //Добавление
                        DataRow newRow = MyDataBase.jobListTable.NewRow();
                        newRow["job_name"] = newJobListName;
                        MyDataBase.jobListTable.Rows.Add(newRow);
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show($"Название работы {newJobListName} уже существует.");
                }
            }
            else
                MessageBox.Show("Поле название работы не может быть пустым");
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
