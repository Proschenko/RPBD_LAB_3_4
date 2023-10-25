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
    public partial class ClientsForm : Form
    {
        Dictionary<string, (long, long, string)> columnValidations = new Dictionary<string, (long, long, string)>
            {
                { "inn", (100000000000, 999999999999, "INN должен содержать 12 цифр.") },
                { "snils", (10000000000, 99999999999, "SNILS должен содержать 11 цифр.") },
                { "passport_data_series", (1000, 9999, "Серия паспорта должна содержать 4 цифры.") },
                { "passport_data_numbers", (100000, 999999, "Номер паспорта должен содержать 6 цифр.") },
                { "phone", (70000000000, 89999999999, "Телефон должен быть в диапазоне [70000000000;89999999999].") },
            };
        private bool _isEditMode;
        private int _indexEditClientsDataTable;
        private DataTable activeDataTable = MyDataBase.clientsTable;
        public ClientsForm(bool isEditMode, DataGridView dataGridView)
        {
            InitializeComponent();
            _isEditMode = isEditMode;

            if (isEditMode)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                    textBox1.Text = selectedRow.Cells[1].Value.ToString();
                    maskedTextBox1.Text = selectedRow.Cells[2].Value.ToString();
                    textBox2.Text = selectedRow.Cells[3].Value.ToString();
                    maskedTextBox2.Text = selectedRow.Cells[4].Value.ToString();
                    DataRow[] foundRows = activeDataTable.Select("client_name = '" + textBox1.Text + "'");

                    if (foundRows.Length > 0)
                    {
                        _indexEditClientsDataTable = Convert.ToInt32(foundRows[0]["client_id"]);
                    }
                }
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DataRow newRow = activeDataTable.NewRow();
            DataRow[] foundRowsClientTable = activeDataTable.Select("client_id = " + _indexEditClientsDataTable);
            int checkValidationsColumns = 0;
            List<string> crashList = new List<string>();
            string newClientName = textBox1.Text;
            // Проверка на дубликаты
            bool isDuplicate = false;
            foreach (DataRow existingRow in activeDataTable.Rows)
            {
                if (newClientName.Equals(existingRow["client_name"].ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    if (existingRow["client_id"].ToString() != _indexEditClientsDataTable.ToString())
                    {
                        isDuplicate = true;
                        break;
                    }
                }
            }

            if (!isDuplicate)
            {
                if (newClientName != "")
                {
                    if (_isEditMode)
                    {
                        //Редактирование
                        checkValidationsColumns++;
                    }
                    else
                    {
                        //Добавление
                        newRow["client_name"] = newClientName;
                        checkValidationsColumns++;
                    }
                }
                else
                    crashList.Add("Поле ФИО клиента не может быть пустым");
            }
            else
            {
                crashList.Add($"Клиент с ФИО {newClientName} уже существует.");
            }

            if (long.TryParse(maskedTextBox1.Text, out long phoneValue))
            {
               
                var phoneRange = columnValidations["phone"];
                if (phoneValue.ToString().Length == phoneRange.Item1.ToString().Length-1) 
                {
                    phoneValue += 70000000000;
                    if (phoneValue >= phoneRange.Item1 && phoneValue <= phoneRange.Item2)
                    {
                        if (_isEditMode)
                        {
                            //Редактирование
                            checkValidationsColumns++;
                        }
                        else
                        {
                            //Добавление
                            newRow["phone"] = phoneValue;
                            checkValidationsColumns++;
                        }
                    }
                    else
                    {
                        crashList.Add("phone");
                    }
                }
                else
                {
                    crashList.Add("phone");
                }

            }
            else
            {
                crashList.Add("phone");
            }

            string innValue = maskedTextBox2.Text;
            var innRange = columnValidations["inn"];
            if (innValue != "")
            {
                if (long.Parse(innValue) >= innRange.Item1 && long.Parse(innValue) <= innRange.Item2
                    && innValue.Length == Convert.ToString(innRange.Item2).Length)
                {
                    if (_isEditMode)
                    {
                        //Редактирование
                        checkValidationsColumns++;
                    }
                    else
                    {
                        //Добавление
                        newRow["inn"] = innValue;
                        checkValidationsColumns++;
                    }
                }
                else
                {
                    crashList.Add("inn");
                }
            }
            else
                crashList.Add("Поле ИНН не может быть пустым");

            string address = textBox2.Text;
            if (address != "")
            {
                if (_isEditMode)
                {
                    //Редактирование
                    checkValidationsColumns++;
                }
                else
                {
                    //Добавление
                    newRow["address"] = address;
                    checkValidationsColumns++;
                }
            }
            else
                crashList.Add("Поле адрес не может быть пустым");

            if (checkValidationsColumns == 4)
            {
                if (_isEditMode)
                {
                    foundRowsClientTable[0]["client_name"] = newClientName;
                    foundRowsClientTable[0]["phone"] = phoneValue;
                    foundRowsClientTable[0]["address"] = address;
                    foundRowsClientTable[0]["inn"] = innValue;
                }
                else
                    activeDataTable.Rows.Add(newRow);
                Close();
            }
            else
            {
                Crash(crashList);
            }
        }

        private void Crash(List<string> crashList)
        {
            string crashReport = "Ошибка!\n";
            foreach (var item in crashList)
            {
                if (columnValidations.ContainsKey(item))
                {
                    crashReport += columnValidations[item].Item3 + "\n";
                }
                else
                    crashReport += item + "\n";
            }
            MessageBox.Show(crashReport);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
