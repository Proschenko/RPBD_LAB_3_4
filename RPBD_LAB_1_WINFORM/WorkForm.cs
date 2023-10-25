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
    public partial class WorkForm : Form
    {
        private bool _isEditMode;
        DataRow[] foundRowsWorkTable;
        DataTable additionalDataTableEmployees = MyDataBase.employeesTable;
        DataTable activeDataTableWork = MyDataBase.worksTable;
        DataTable additionalDataTableOrders = MyDataBase.ordersTable;
        DataTable additionalDataTableJobList = MyDataBase.jobListTable;
        public WorkForm(bool isEditMode, DataGridView dataGridView)
        {
            InitializeComponent();
            _isEditMode = isEditMode;
            comboBox1.DataSource = MyDataBase.GetColumnValues(MyDataBase.dataSet.Tables["Orders"], "object_name");
            comboBox2.DataSource = MyDataBase.GetColumnValues(MyDataBase.dataSet.Tables["JobList"], "job_name");
            comboBox3.DataSource = MyDataBase.GetColumnValues(MyDataBase.dataSet.Tables["Employees"], "employee_name");
            if (isEditMode)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                    comboBox1.Text = selectedRow.Cells[1].Value.ToString();
                    comboBox2.Text = selectedRow.Cells[2].Value.ToString();
                    comboBox3.Text = selectedRow.Cells[3].Value.ToString();
                    dateTimePicker1.Text = selectedRow.Cells[4].Value.ToString();
                    dateTimePicker2.Text = selectedRow.Cells[5].Value.ToString();
                    textBox1.Text = selectedRow.Cells[6].Value.ToString();


                    int indexorderCombobox = comboBox1.SelectedIndex;
                    string objectName = comboBox1.Items[indexorderCombobox].ToString();

                    DataRow[] foundRowsOrder = additionalDataTableOrders.Select("object_name = '" + objectName + "'");

                    int orderId = Convert.ToInt32(foundRowsOrder[0]["order_id"]);

                    int indexJobListCombobox = comboBox2.SelectedIndex;
                    string jobName = comboBox2.Items[indexJobListCombobox].ToString();

                    DataRow[] foundRowsJobList = additionalDataTableJobList.Select("job_name = '" + jobName + "'");

                    int joblistId = Convert.ToInt32(foundRowsJobList[0]["joblist_id"]);

                    int indexEployeeCombobox = comboBox3.SelectedIndex;
                    string employeeName = comboBox3.Items[indexEployeeCombobox].ToString();

                    DataRow[] foundRowsEmployee = additionalDataTableEmployees.Select("employee_name = '" + employeeName + "'");

                    int employeeId = Convert.ToInt32(foundRowsEmployee[0]["employee_id"]);

                    DateTime searchValue4 = dateTimePicker1.Value;
                    DateTime searchValue5 = dateTimePicker2.Value;
                    string searchValue6 = textBox1.Text;

                    DataTable workTable = MyDataBase.worksTable; // Замените на фактическую таблицу

                    var foundRows = workTable.AsEnumerable().Where(row =>
                    (row["order_id"] is DBNull || row.Field<int>("order_id") == orderId) &&
                    (row["joblist_id"] is DBNull || row.Field<int>("joblist_id") == joblistId) &&
                    (row["employee_id"] is DBNull || row.Field<int>("employee_id") == employeeId) &&
                    (!row.IsNull("start_date_work") && row.Field<DateTime>("start_date_work") == searchValue4) &&
                    (!row.IsNull("end_date_work") && row.Field<DateTime>("end_date_work") == searchValue5) &&
                    row.Field<string>("job_description") == searchValue6
                    ).ToArray();



                    if (foundRows.Length > 0)
                    {
                        foundRowsWorkTable = foundRows;
                    }
                }
            }

        }


        private void OkButton_Click(object sender, EventArgs e)
        {
            DataRow newRow = activeDataTableWork.NewRow();
            int checkValidationsColumns = 3;
            List<string> crashList = new List<string>();
            string jobDescription = textBox1.Text;
            if (jobDescription != "")
            {
                if (_isEditMode)
                {
                    //Редактирование
                    checkValidationsColumns++;
                }
                else
                {
                    //Добавление
                    newRow["job_description"] = textBox1.Text;
                    checkValidationsColumns++;
                }
            }
            else
                crashList.Add("Поле описание работы пустое");

            DateTime start_date_work = dateTimePicker1.Value.Date;
            DateTime end_date_work = dateTimePicker2.Value.Date;

            if (start_date_work > end_date_work)
            {
                crashList.Add("Дата начала работы больше даты окончания работы.");
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
                    newRow["start_date_work"] = dateTimePicker1.Value.Date;
                    newRow["end_date_work"] = dateTimePicker2.Value.Date;
                    checkValidationsColumns++;
                }
            }

            int indexorderCombobox = comboBox1.SelectedIndex;
            string objectName = comboBox1.Items[indexorderCombobox].ToString();

            DataRow[] foundRowsOrder = additionalDataTableOrders.Select("object_name = '" + objectName + "'");

            int orderId = Convert.ToInt32(foundRowsOrder[0]["order_id"]);

            if (_isEditMode)
            {
                //Редактирование
            }
            else
            {
                //Добавление
                newRow["order_id"] = orderId;
            }

            int indexJobListCombobox = comboBox2.SelectedIndex;
            string jobName = comboBox2.Items[indexJobListCombobox].ToString();

            DataRow[] foundRowsJobList = additionalDataTableJobList.Select("job_name = '" + jobName + "'");

            int joblistId = Convert.ToInt32(foundRowsJobList[0]["joblist_id"]);

            if (_isEditMode)
            {
                //Редактирование
            }
            else
            {
                //Добавление
                newRow["joblist_id"] = joblistId;
            }

            int indexEployeeCombobox = comboBox3.SelectedIndex;
            string employeeName = comboBox3.Items[indexEployeeCombobox].ToString();

            DataRow[] foundRowsEmployee = additionalDataTableEmployees.Select("employee_name = '" + employeeName + "'");

            int employeeId = Convert.ToInt32(foundRowsEmployee[0]["employee_id"]);

            if (_isEditMode)
            {
                //Редактирование
            }
            else
            {
                //Добавление
                newRow["employee_id"] = employeeId;
            }

            var foundRows = activeDataTableWork.AsEnumerable().Where(row =>
                (row["order_id"] is DBNull || (row.Field<int?>("order_id") == orderId)) &&
                (row["joblist_id"] is DBNull || (row.Field<int?>("joblist_id") == joblistId)) &&
                (row["employee_id"] is DBNull || (row.Field<int?>("employee_id") == employeeId)) &&
                (!row.IsNull("start_date_work") && row.Field<DateTime>("start_date_work") == start_date_work) &&
                (!row.IsNull("end_date_work") && row.Field<DateTime>("end_date_work") == end_date_work) &&
                row.Field<string>("job_description") == jobDescription
                ).ToArray();


            //var foundRows = activeDataTableWork.AsEnumerable().Where(row =>   СТАРЬЁ
            //        row.Field<int>("order_id") == orderId &&
            //        row.Field<int>("joblist_id") == joblistId &&
            //        row.Field<int>("employee_id") == employeeId &&
            //        row.Field<DateTime>("start_date_work") == start_date_work &&
            //        row.Field<DateTime>("end_date_work") == end_date_work &&
            //        row.Field<string>("job_description") == jobDescription
            //        ).ToArray();


            if (foundRows.Length > 1)
            {
                crashList.Add("В таблице найдена идентичная строка");
            }
            else
                checkValidationsColumns++;

            if (checkValidationsColumns == 6)
            {
                if (_isEditMode)
                {
                    foundRowsWorkTable[0]["order_id"] = orderId;
                    foundRowsWorkTable[0]["joblist_id"] = joblistId;
                    foundRowsWorkTable[0]["employee_id"] = employeeId;
                    foundRowsWorkTable[0]["start_date_work"] = start_date_work;
                    foundRowsWorkTable[0]["end_date_work"] = end_date_work;
                    foundRowsWorkTable[0]["job_description"] = jobDescription;
                }
                else
                    activeDataTableWork.Rows.Add(newRow);
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
