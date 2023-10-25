using System.Data;
using System.Windows.Forms;
using Xceed.Document.NET;
using static OfficeOpenXml.ExcelErrorValue;

namespace RPBD_LAB_1_WINFORM
{
    public partial class Form1 : Form
    {
        private bool IsCascadeDelete = false;
        public Form1()
        {
            MyDataBase.DownloadData();
            InitializeComponent();

            DialogResult result = MessageBox.Show("Вы хотите использовать каскадное удаление?", "Об удалении", MessageBoxButtons.YesNo);
            IsCascadeDelete = result == DialogResult.Yes;
            DeleteButton.Text = IsCascadeDelete ? "Удалить каскадно" : "Удалить НЕ каскадно";

            foreach (DataRelation relation in MyDataBase.dataSet.Relations)
            {
                
                relation.ChildKeyConstraint.DeleteRule = IsCascadeDelete ? Rule.Cascade : Rule.SetNull;
                
            }

            List<string>? entity = MyDataBase.GetTableNames();
            MainComboBox.DataSource = entity;

        }

        private void Helper_Add_Edit_Mode(string selectedValueInner, bool IsEditMode)
        {
            switch (selectedValueInner)
            {
                case "Divisions":
                    DivisionsForm df1 = new DivisionsForm(IsEditMode, dataGridView);
                    df1.ShowDialog();
                    break;

                case "Employees":
                    EmployeesForm ef1 = new EmployeesForm(IsEditMode, dataGridView);
                    ef1.ShowDialog();
                    break;

                case "Work":
                    WorkForm wf1 = new WorkForm(IsEditMode, dataGridView);
                    wf1.ShowDialog();
                    break;

                case "JobList":
                    JobListForm jlf1 = new JobListForm(IsEditMode, dataGridView);
                    jlf1.ShowDialog();
                    break;

                case "Orders":
                    OrdersForm of1 = new OrdersForm(IsEditMode, dataGridView);
                    of1.ShowDialog();
                    break;

                case "Clients":
                    ClientsForm cf1 = new ClientsForm(IsEditMode, dataGridView);
                    cf1.ShowDialog();
                    break;

                default:
                    MessageBox.Show($"Error WARNING PLS GO HOME");
                    break;

            }
            MyDataBase.SaveDataSetToXmlFile(MyDataBase.dataSet, "GIgaData.xml");


        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (MainComboBox.SelectedItem != null)
            {
                string selectedValue = (string)MainComboBox.SelectedItem;
                bool flagEdit = false;

                Helper_Add_Edit_Mode(selectedValue, flagEdit);
                RefreshDataGrid(MainComboBox);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (MainComboBox.SelectedItem != null)
            {
                string selectedValue = (string)MainComboBox.SelectedItem;
                bool flagEdit = true;

                Helper_Add_Edit_Mode(selectedValue, flagEdit);
                RefreshDataGrid(MainComboBox);
            }
        }



        private void MainComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            RefreshDataGrid(comboBox);
        }

        private void RefreshDataGrid(ComboBox comboBox)
        {
            // Проверка на наличие выбранного элемента
            if (comboBox.SelectedItem != null)
            {
                // Получение выбранного элемента
                var selectedValue = comboBox.SelectedItem;

                switch (selectedValue)
                {
                    case "Divisions":
                        DataTable divisions = MyDataBase.ViewDivisions(MyDataBase.dataSet);
                        dataGridView.DataSource = new DataView(divisions);
                        break;

                    case "Employees":
                        DataTable employees = MyDataBase.ViewEmployees(MyDataBase.dataSet);
                        dataGridView.DataSource = new DataView(employees);
                        break;

                    case "Work":
                        DataTable work = MyDataBase.ViewWork(MyDataBase.dataSet);
                        dataGridView.DataSource = new DataView(work);
                        break;

                    case "JobList":
                        DataTable jobList = MyDataBase.ViewJobList(MyDataBase.dataSet);
                        dataGridView.DataSource = new DataView(jobList);
                        break;

                    case "Orders":
                        DataTable orders = MyDataBase.ViewOrders(MyDataBase.dataSet);
                        dataGridView.DataSource = new DataView(orders);
                        break;

                    case "Clients":
                        DataTable clients = MyDataBase.ViewClients(MyDataBase.dataSet);
                        dataGridView.DataSource = new DataView(clients);
                        break;

                    default:
                        MessageBox.Show($"Error WARNING PLS GO HOME");
                        break;

                }
                dataGridView.Columns[0].Visible = false;
                dataGridView.DataBindingComplete += DataGridView_DataBindingComplete;
            }
        }
        private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Удаляем обработчик события, чтобы избежать повторного вызова AutoResizeColumns
            dataGridView.DataBindingComplete -= DataGridView_DataBindingComplete;

            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        public Tuple<DateTime, DateTime> FindMinMaxDates()
        {
            DataTable workTable = MyDataBase.worksTable;
            if (workTable == null || workTable.Rows.Count == 0)
            {
                // Если таблица пуста, вернуть значения по умолчанию
                return Tuple.Create(DateTime.MinValue, DateTime.MinValue);
            }

            DateTime minDate = workTable.AsEnumerable().Min(row => row.Field<DateTime>("start_date_work"));
            DateTime maxDate = workTable.AsEnumerable().Max(row => row.Field<DateTime>("end_date_work"));

            return Tuple.Create(minDate, maxDate);
        }


        private void ReportButton_Click_1(object sender, EventArgs e)
        {
            Tuple <DateTime, DateTime> minMaxDateWork = FindMinMaxDates();
            ReportForm form = new ReportForm(minMaxDateWork.Item1, minMaxDateWork.Item2);
            //form.ReportDataView = new DataView(MyDataBase.dataSet.Tables["Work"]);
            form.ReportDataView = MyDataBase.JoinDataTables(minMaxDateWork.Item1, minMaxDateWork.Item2);
            form.Show();
        }

        private void DeleteButton_Click_1(object sender, EventArgs e)
        {

            // Проверяем, есть ли выделенные строки
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                string tableName = MainComboBox.SelectedItem.ToString();

                DataTable dataTable = MyDataBase.dataSet.Tables[tableName];

                string columnName = "YourColumnName";
                string primaryKeyValue = String.Empty;
                switch (tableName)
                {
                    case "Divisions":
                        columnName = "division_name";
                        primaryKeyValue = selectedRow.Cells[1].Value.ToString();
                        break;

                    case "Employees":
                        columnName = "employee_name";
                        primaryKeyValue = selectedRow.Cells[1].Value.ToString();

                        break;

                    case "Work":



                        DataRow[] foundRowsOrder = MyDataBase.ordersTable.Select("object_name = '" + selectedRow.Cells[1].Value + "'");
                        int orderId = Convert.ToInt32(foundRowsOrder[0]["order_id"]);


                        DataRow[] foundRowsJobList = MyDataBase.jobListTable.Select("job_name = '" + selectedRow.Cells[2].Value + "'");

                        int joblistId = Convert.ToInt32(foundRowsJobList[0]["joblist_id"]);



                        DataRow[] foundRowsEmployee = MyDataBase.employeesTable.Select("employee_name = '" + selectedRow.Cells[3].Value + "'");

                        int employeeId = Convert.ToInt32(foundRowsEmployee[0]["employee_id"]);

                        DateTime searchValue4 = Convert.ToDateTime(selectedRow.Cells[4].Value);
                        DateTime searchValue5 = Convert.ToDateTime(selectedRow.Cells[5].Value);
                        string searchValue6 = selectedRow.Cells[6].Value.ToString();

                        DataTable workTable = MyDataBase.worksTable; // Замените на фактическую таблицу

                        var foundRows123 = workTable.AsEnumerable().Where(row =>
                            row.Field<int>("order_id") == orderId &&
                            row.Field<int>("joblist_id") == joblistId &&
                            row.Field<int>("employee_id") == employeeId &&
                            row.Field<DateTime>("start_date_work") == searchValue4 &&
                            row.Field<DateTime>("end_date_work") == searchValue5 &&
                            row.Field<string>("job_description") == searchValue6
                        ).ToArray();

                        DataRow rowToDelete = foundRows123[0];


                        // Уточнение перед удалением
                        DialogResult dialogResult2 = MessageBox.Show($"Вы действительно хотите удалить эту строку?", "Уточнение перед удалением", MessageBoxButtons.YesNo);

                        if (dialogResult2 == DialogResult.Yes)
                        {
                            if (IsCascadeDelete)
                            {
                                // Теперь вы можете продолжить удаление этой строки
                                dataTable.Rows.Remove(rowToDelete);

                                MyDataBase.SaveDataSetToXmlFile(MyDataBase.dataSet, "GIgaData.xml");

                                RefreshDataGrid(MainComboBox);

                                MessageBox.Show("Строка успешно удалена.");
                            }
                            else
                            {
                                dataTable.Rows.Remove(rowToDelete);
                            }

                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            MessageBox.Show("Удаление отменено.");
                        }

                        return;


                    case "JobList":
                        columnName = "job_name";
                        primaryKeyValue = selectedRow.Cells[1].Value.ToString();

                        break;

                    case "Orders":
                        columnName = "object_name";
                        primaryKeyValue = selectedRow.Cells[2].Value.ToString();

                        break;

                    case "Clients":
                        columnName = "client_name";
                        primaryKeyValue = selectedRow.Cells[1].Value.ToString();

                        break;

                    default:
                        MessageBox.Show($"Error WARNING PLS GO HOME");
                        break;

                }



                DataRow[] foundRows = dataTable.Select($"{columnName} = '{primaryKeyValue}'");


                DialogResult dialogResult = MessageBox.Show($"Вы действительно хотите удалить эту строку?\n{columnName} = {primaryKeyValue}", "Уточнение перед удалением", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    if (foundRows.Length > 0)
                    {
                        DataRow rowToDelete = foundRows[0];

                        dataTable.Rows.Remove(rowToDelete);


                        MyDataBase.SaveDataSetToXmlFile(MyDataBase.dataSet, "GIgaData.xml");
                        RefreshDataGrid(MainComboBox);

                    }
                    MessageBox.Show("Строка успешно удалена.");
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Удаление отменено.");
                }


            }





        }
    }
}