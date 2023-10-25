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
    public partial class DivisionsForm : Form
    {
        private bool _isEditMode;
        private int _indexEditDivisionDataTable = 0;
        public DivisionsForm(bool isEditMode, DataGridView dataGridView)
        {
            InitializeComponent();
            _isEditMode = isEditMode;
            if (isEditMode)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                    object cellValue = selectedRow.Cells[1].Value;
                    textBox1.Text = cellValue.ToString();
                    DataRow[] foundRows = MyDataBase.divisionsTable.Select("division_name = '" + textBox1.Text + "'");

                    if (foundRows.Length > 0)
                    {
                        _indexEditDivisionDataTable = Convert.ToInt32(foundRows[0]["division_id"]);
                    }
                }   
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DataTable activeDataTable = MyDataBase.divisionsTable;
            string newDivisionName = textBox1.Text;
            // Проверка на дубликаты
            bool isDuplicate = false;
            foreach (DataRow existingRow in activeDataTable.Rows)
            {
                if (newDivisionName.Equals(existingRow["division_name"].ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    if (existingRow["division_id"].ToString() != _indexEditDivisionDataTable.ToString())
                    {
                        isDuplicate = true;
                        break;
                    }
                }
            }

            if (newDivisionName != "")
            {
                if (!isDuplicate)
                {
                    if (_isEditMode)
                    {
                        //Редактирование
                        DataRow[] foundRows = activeDataTable.Select("division_id = " + _indexEditDivisionDataTable);
                        foundRows[0]["division_name"] = newDivisionName;
                    }
                    else
                    {
                        DataRow newRow = activeDataTable.NewRow();
                        newRow["division_name"] = newDivisionName;
                        activeDataTable.Rows.Add(newRow);


                    }
                    Close();
                }
                else
                {
                    MessageBox.Show($"Подразделение {newDivisionName} уже существует.");
                }
            }
            else
                MessageBox.Show("Поле подразделение не может быть пустым");
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
