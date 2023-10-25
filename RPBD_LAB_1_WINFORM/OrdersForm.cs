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
    public partial class OrdersForm : Form
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
        private int _indexEditOrdersDataTable;
        DataTable activeDataTableOrders = MyDataBase.ordersTable;
        public OrdersForm(bool isEditMode, DataGridView dataGridView)
        {
            InitializeComponent();
            _isEditMode = isEditMode;
            comboBox1.DataSource = MyDataBase.GetColumnValues(MyDataBase.dataSet.Tables["Clients"], "client_name");
            if (isEditMode)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                    comboBox1.Text = selectedRow.Cells[1].Value.ToString();
                    textBox1.Text = selectedRow.Cells[2].Value.ToString();
                    textBox3.Text = selectedRow.Cells[3].Value.ToString();
                    dateTimePicker1.Text = selectedRow.Cells[4].Value.ToString();
                    dateTimePicker2.Text = selectedRow.Cells[5].Value.ToString();
                    DataRow[] foundRows = activeDataTableOrders.Select("object_name = '" + textBox1.Text + "'");

                    if (foundRows.Length > 0)
                    {
                        _indexEditOrdersDataTable = Convert.ToInt32(foundRows[0]["order_id"]);
                    }
                }
            }
        }



        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DataTable additionalDataTableClients = MyDataBase.clientsTable;
            DataRow newRow = activeDataTableOrders.NewRow();
            DataRow[] foundRowsOrdersTable = activeDataTableOrders.Select("order_id = " + _indexEditOrdersDataTable);
            int checkValidationsColumns = 2;
            List<string> crashList = new List<string>();

            int indexorderCombobox = comboBox1.SelectedIndex;
            string clientName = comboBox1.Items[indexorderCombobox].ToString();

            DataRow[] foundRowsClient = additionalDataTableClients.Select("client_name = '" + clientName + "'");

            int clientId = Convert.ToInt32(foundRowsClient[0]["client_id"]);
            if (_isEditMode)
            {
                //Редактирование
            }
            else
            {
                //Добавление
                newRow["client_id"] = clientId;
            }

            string newObjectName = textBox1.Text;
            // Проверка на дубликаты
            bool isDuplicate = false;
            foreach (DataRow existingRow in activeDataTableOrders.Rows)
            {
                if (newObjectName.Equals(existingRow["object_name"].ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    if (existingRow["order_id"].ToString() != _indexEditOrdersDataTable.ToString())
                    {
                        isDuplicate = true;
                        break;
                    }
                }
            }

            if (!isDuplicate)
            {
                if (newObjectName != "")
                {
                    if (_isEditMode)
                    {
                        //Редактирование
                        checkValidationsColumns++;
                    }
                    else
                    {
                        //Добавление
                        newRow["object_name"] = newObjectName;
                        checkValidationsColumns++;
                    }
                }
                else
                    crashList.Add("Поле код заказа не может быть пустым");
            }
            else
            {
                crashList.Add($"Код заказа {newObjectName} уже существует.");
            }

            string newWorkContent = textBox3.Text;
            if (newWorkContent != "")
            {
                if (_isEditMode)
                {
                    //Редактирование
                    checkValidationsColumns++;
                }
                else
                {
                    //Добавление
                    newRow["work_content"] = newWorkContent;
                    checkValidationsColumns++;
                }
            }
            else
                crashList.Add("Поле описание работ не может быть пустым");

            DateTime start_date_order = dateTimePicker1.Value.Date;
            DateTime end_date_order = dateTimePicker2.Value.Date;

            int dateComparison = DateTime.Compare(start_date_order, end_date_order);

            if (dateComparison > 0)
            {
                crashList.Add("Дата заключения сделки больше даты завершения сделки.");
            }
            else
            {
                if (_isEditMode)
                {
                    //Редактирование
                    checkValidationsColumns++;
                }
                else
                {
                    //Добавление
                    newRow["start_date_order"] = start_date_order;
                    newRow["end_date_order"] = end_date_order;
                    checkValidationsColumns++;
                }
            }


            if (checkValidationsColumns == 5)
            {
                if (_isEditMode)
                {
                    foundRowsOrdersTable[0]["client_id"] = clientId;
                    foundRowsOrdersTable[0]["object_name"] = newObjectName;
                    foundRowsOrdersTable[0]["work_content"] = newWorkContent;
                    foundRowsOrdersTable[0]["start_date_order"] = start_date_order;
                    foundRowsOrdersTable[0]["end_date_order"] = end_date_order;
                }
                else
                    activeDataTableOrders.Rows.Add(newRow);
                Close();
            }
            else
                Crash(crashList);
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
    }
}
