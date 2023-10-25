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
    public partial class EmployeesForm : Form
    {
        private bool _isEditMode;
        private int _indexEditEmployeeDataTable;
        Dictionary<string, (long, long, string)> columnValidations = new Dictionary<string, (long, long, string)>
            {
                { "inn", (000000000000, 999999999999, "INN должен содержать 12 цифр.") },
                { "snils", (00000000000, 99999999999, "SNILS должен содержать 11 цифр.") },
                { "passport_data_series", (0000, 9999, "Серия паспорта должна содержать 4 цифры.") },
                { "passport_data_numbers", (000000, 999999, "Номер паспорта должен содержать 6 цифр.") },
                { "phone", (70000000000, 89999999999, "Телефон должен быть в диапазоне [70000000000;89999999999].") },       
            };
        public EmployeesForm(bool isEditMode, DataGridView dataGridView)
        {
            InitializeComponent();
            _isEditMode = isEditMode;
            comboBox1.DataSource = MyDataBase.GetColumnValues(MyDataBase.dataSet.Tables["Divisions"], "division_name");
            if (isEditMode)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                    textBox1.Text = selectedRow.Cells[1].Value.ToString();
                    dateTimePicker1.Text = selectedRow.Cells[2].Value.ToString();
                    maskedTextBox1.Text = selectedRow.Cells[3].Value.ToString();
                    maskedTextBox2.Text = selectedRow.Cells[4].Value.ToString();
                    comboBox1.Text = selectedRow.Cells[5].Value.ToString();
                    maskedTextBox3.Text = selectedRow.Cells[6].Value.ToString();
                    maskedTextBox4.Text = selectedRow.Cells[7].Value.ToString();
                    DataRow[] foundRows = MyDataBase.employeesTable.Select("employee_name = '" + textBox1.Text + "'");

                    if (foundRows.Length > 0)
                    {
                        _indexEditEmployeeDataTable = Convert.ToInt32(foundRows[0]["employee_id"]);
                    }
                }
            }
        }
        private void OkButton_Click(object sender, EventArgs e)
        {
            DataTable activeDataTable = MyDataBase.employeesTable;
            DataTable additionalTable = MyDataBase.divisionsTable;
            DataRow newRow = activeDataTable.NewRow();
            DataRow[] foundRowsEmployeeTable = activeDataTable.Select("employee_id = " + _indexEditEmployeeDataTable);
            int checkValidationsColumns = 2;
            List<string> crashList = new List<string>();

            string newEmployeeName = textBox1.Text;
            // Проверка на дубликаты
            bool isDuplicate = false;
            foreach (DataRow existingRow in activeDataTable.Rows)
            {
                if (newEmployeeName.Equals(existingRow["employee_name"].ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    if (existingRow["employee_id"].ToString() != _indexEditEmployeeDataTable.ToString())
                    {
                        isDuplicate = true;
                        break;
                    }
                }
            }

            if (newEmployeeName != "")
            {
                if (!isDuplicate)
                {
                    if (_isEditMode)
                    {
                        //Редактирование
                        checkValidationsColumns++;
                    }
                    else
                    {
                        //Добавление
                        newRow["employee_name"] = newEmployeeName;
                        checkValidationsColumns++;
                    }
                }
                else
                {
                    crashList.Add($"Работник {newEmployeeName} уже существует.");
                }
            }
            else
                crashList.Add("Поле ФИО работника не может быть пустым");

            newRow["birthday_date"] = dateTimePicker1.Value;

            string innValue = maskedTextBox1.Text;
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

            string snilsValue = maskedTextBox2.Text;
            var snilsRange = columnValidations["snils"];
            if (snilsValue != "")
            {
                if (long.Parse(snilsValue) >= snilsRange.Item1 && long.Parse(snilsValue) <= snilsRange.Item2
                    && snilsValue.Length == Convert.ToString(snilsRange.Item2).Length)
                {

                    if (_isEditMode)
                    {
                        //Редактирование
                        checkValidationsColumns++;
                    }
                    else
                    {
                        //Добавление
                        newRow["snils"] = snilsValue;
                        checkValidationsColumns++;
                    }
                }
                else
                {
                    crashList.Add("snils");
                }
            }
            else
                crashList.Add("Поле СНИЛС не может быть пустым");

            string passportSeriesValue = maskedTextBox3.Text;
            var passportSeriesRange = columnValidations["passport_data_series"];

            if (passportSeriesValue != "")
            {
                if (int.Parse(passportSeriesValue) >= passportSeriesRange.Item1 && int.Parse(passportSeriesValue) <= passportSeriesRange.Item2
                    && passportSeriesValue.Length == Convert.ToString(passportSeriesRange.Item2).Length)
                {

                    if (_isEditMode)
                    {
                        //Редактирование
                        checkValidationsColumns++;
                    }
                    else
                    {
                        //Добавление
                        newRow["passport_data_series"] = passportSeriesValue;
                        checkValidationsColumns++;
                    }
                }
                else
                {
                    crashList.Add("passport_data_series");
                }
            }
            else
                crashList.Add("Поле серия паспорта не может быть пустым");

            string passportNumbersValue = maskedTextBox4.Text;
            var passportNumbersRange = columnValidations["passport_data_numbers"];
            if (passportNumbersValue != "")
            {
                if (int.Parse(passportNumbersValue) >= passportNumbersRange.Item1 && int.Parse(passportNumbersValue) <= passportNumbersRange.Item2
                && passportNumbersValue.Length == Convert.ToString(passportNumbersRange.Item2).Length)
                {

                    if (_isEditMode)
                    {
                        //Редактирование
                        checkValidationsColumns++;
                    }
                    else
                    {
                        //Добавление
                        newRow["passport_data_numbers"] = passportNumbersValue;
                        checkValidationsColumns++;
                    }
                }
                else
                {
                    crashList.Add("passport_data_numbers");
                }
            }
            else
                crashList.Add("Поле номер паспорта не может быть пустым");

            int indexCombobox = comboBox1.SelectedIndex;
            string divisionName = comboBox1.Items[indexCombobox].ToString();

            DataRow[] foundRows = additionalTable.Select("division_name = '" + divisionName + "'");

            int divisionId = Convert.ToInt32(foundRows[0]["division_id"]);
            if (_isEditMode)
            {
                //Редактирование
            }
            else
            {
                //Добавление
                newRow["division_id"] = divisionId;
            }

            if (checkValidationsColumns == 7)
            {
                if (!_isEditMode)
                {
                    activeDataTable.Rows.Add(newRow);
                }
                else 
                {
                    foundRowsEmployeeTable[0]["employee_name"] = newEmployeeName;
                    foundRowsEmployeeTable[0]["birthday_date"] = dateTimePicker1.Value;
                    foundRowsEmployeeTable[0]["inn"] = innValue;
                    foundRowsEmployeeTable[0]["snils"] = snilsValue;
                    foundRowsEmployeeTable[0]["passport_data_series"] = passportSeriesValue;
                    foundRowsEmployeeTable[0]["passport_data_numbers"] = passportNumbersValue;
                    foundRowsEmployeeTable[0]["division_id"] = divisionId;
                }

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
