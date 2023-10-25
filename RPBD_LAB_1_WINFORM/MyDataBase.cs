using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RPBD_LAB_1_WINFORM
{
    internal class MyDataBase
    {
        internal static DataSet? dataSet;

        internal static DataTable? jobListTable;
        internal static DataTable? divisionsTable;
        internal static DataTable? employeesTable;
        internal static DataTable? clientsTable;
        internal static DataTable? ordersTable;
        internal static DataTable? worksTable;


        #region Все таблицы
        static DataTable CreateTableJobList()
        {
            DataTable jobList = new DataTable("JobList");

            DataColumn jobIdColumn = new DataColumn("joblist_id", typeof(int));
     
            jobIdColumn.AutoIncrement = true; // будет автоинкрементироваться
            jobIdColumn.AutoIncrementSeed = 1; // начальное значение
            jobIdColumn.AutoIncrementStep = 1; // приращение при добавлении новой строки

            DataColumn jobNameColumn = new DataColumn("job_name", typeof(string));
            jobNameColumn.MaxLength = 255;

            jobList.Columns.Add(jobIdColumn);
            jobList.Columns.Add(jobNameColumn);

            return jobList;
        } // ready

        static DataTable CreateTableDivisions()
        {
            // Создаем таблицу "Divisions"
            DataTable divisionsTable = new DataTable("Divisions");
            DataColumn divisionIdColumn = new DataColumn("division_id", typeof(int));

            divisionIdColumn.AutoIncrement = true;
            divisionIdColumn.AutoIncrementSeed = 1;
            divisionIdColumn.AutoIncrementStep = 1;

            var divisionNameColumn = new DataColumn("division_name", typeof(string));
            divisionNameColumn.MaxLength = 255;

            divisionsTable.Columns.Add(divisionIdColumn);
            divisionsTable.Columns.Add(divisionNameColumn);
            return divisionsTable;
        } // ready

        static DataTable CreateTableEmployees()
        {
            // Создаем таблицу "Employees"
            DataTable employeesTable = new DataTable("Employees");
            DataColumn employeeIdColumn = new DataColumn("employee_id", typeof(int));
            employeeIdColumn.AutoIncrement = true;
            employeeIdColumn.AutoIncrementSeed = 1;
            employeeIdColumn.AutoIncrementStep = 1;

            DataColumn employeeNameColumn = new DataColumn("employee_name", typeof(string));
            employeeNameColumn.MaxLength = 255;

            DataColumn employeeBirthdayColumn = new DataColumn("birthday_date", typeof(DateTime));

            DataColumn employeeInnColumn = new DataColumn("inn", typeof(string));

            DataColumn employeeSnilsColumn = new DataColumn("snils", typeof(string));

            DataColumn employeeDepartmentIdColumn = new DataColumn("division_id", typeof(int));
            employeeDepartmentIdColumn.AllowDBNull = true; // Позволяет столбцу принимать null
            DataColumn employeePassportDataSeriesColumn = new DataColumn("passport_data_series", typeof(string));

            DataColumn employeePassportDataNumberColumn = new DataColumn("passport_data_numbers", typeof(string));

            employeesTable.Columns.Add(employeeIdColumn);
            employeesTable.Columns.Add(employeeNameColumn);
            employeesTable.Columns.Add(employeeBirthdayColumn);
            employeesTable.Columns.Add(employeeInnColumn);
            employeesTable.Columns.Add(employeeSnilsColumn);
            employeesTable.Columns.Add(employeeDepartmentIdColumn);
            employeesTable.Columns.Add(employeePassportDataSeriesColumn);
            employeesTable.Columns.Add(employeePassportDataNumberColumn);
            return employeesTable;
        } // ready

        static DataTable CreateTableClients()
        {
            // Создаем таблицу "Clients"
            DataTable clientsTable = new DataTable("Clients");
            DataColumn clientIdColumn = new DataColumn("client_id", typeof(int));
            clientIdColumn.AutoIncrement = true;
            clientIdColumn.AutoIncrementSeed = 1;
            clientIdColumn.AutoIncrementStep = 1;

            DataColumn clientNameColumn = new DataColumn("client_name", typeof(string));
            clientNameColumn.MaxLength = 255;

            DataColumn clientPhoneColumn = new DataColumn("phone", typeof(long));

            DataColumn clientAddressColumn = new DataColumn("address", typeof(string));
            clientAddressColumn.MaxLength = 100;

            DataColumn clientInnColumn = new DataColumn("inn", typeof(string));

            clientsTable.Columns.Add(clientIdColumn);
            clientsTable.Columns.Add(clientNameColumn);
            clientsTable.Columns.Add(clientPhoneColumn);
            clientsTable.Columns.Add(clientAddressColumn);
            clientsTable.Columns.Add(clientInnColumn);
            return clientsTable;

        } // ready

        static DataTable CreateTableOrders()
        {
            // Создаем таблицу "Orders"
            DataTable ordersTable = new DataTable("Orders");
            DataColumn orderIdColumn = new DataColumn("order_id", typeof(int));
            orderIdColumn.AutoIncrement = true;
            orderIdColumn.AutoIncrementSeed = 1;
            orderIdColumn.AutoIncrementStep = 1;

            DataColumn orderClientIdColumn = new DataColumn("client_id", typeof(int));
            orderClientIdColumn.AllowDBNull = true;

            DataColumn orderObjectNameColumn = new DataColumn("object_name", typeof(string));
            orderObjectNameColumn.MaxLength = 255;

            DataColumn orderWorkContentColumn = new DataColumn("work_content", typeof(string));
            orderWorkContentColumn.MaxLength = 255;

            DataColumn orderStartDateColumn = new DataColumn("start_date_order", typeof(DateTime));

            DataColumn orderEndDateColumn = new DataColumn("end_date_order", typeof(DateTime));

            ordersTable.Columns.Add(orderIdColumn);
            ordersTable.Columns.Add(orderClientIdColumn);
            ordersTable.Columns.Add(orderObjectNameColumn);
            ordersTable.Columns.Add(orderWorkContentColumn);
            ordersTable.Columns.Add(orderStartDateColumn);
            ordersTable.Columns.Add(orderEndDateColumn);
            return ordersTable;
        } // ready

        static DataTable CreateTableWorks()
        {
            // Создаем таблицу "Work"
            DataTable completedWorksTable = new DataTable("Work");

            DataColumn workOrderIDColumn = new DataColumn("order_id", typeof(int));
            workOrderIDColumn.AllowDBNull = true;

            DataColumn workJobListIDColumn = new DataColumn("joblist_id", typeof(int));
            workJobListIDColumn.AllowDBNull=true;
            DataColumn workEmployeeIDColumn = new DataColumn("employee_id", typeof(int));
            workEmployeeIDColumn.AllowDBNull = true;


            completedWorksTable.Columns.Add(workOrderIDColumn);
            completedWorksTable.Columns.Add(workJobListIDColumn);
            completedWorksTable.Columns.Add(workEmployeeIDColumn);
            completedWorksTable.Columns.Add(new DataColumn("start_date_work", typeof(DateTime)));
            completedWorksTable.Columns.Add(new DataColumn("end_date_work", typeof(DateTime)));
            DataColumn completedJobsDescriptionColumn = new DataColumn("job_description", typeof(string));
            completedJobsDescriptionColumn.MaxLength = 255;
            completedWorksTable.Columns.Add(completedJobsDescriptionColumn);

            return completedWorksTable;
        } // ready
        #endregion

        #region Чтение и сохранение
        static DataTable ReadDataFromXmlFile(string dataPath, DataTable columnTable, string elementByTagName)
        {
            DataTable dataTable = columnTable;
            if (File.Exists(dataPath))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(dataPath);
                XmlNodeList nodes = xmlDoc.GetElementsByTagName(elementByTagName);

                foreach (XmlElement node in nodes)
                {
                    DataRow row = columnTable.NewRow();
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        string variableName = childNode.Name;

                        DataColumn column = columnTable.Columns[variableName];

                        if (string.Equals(variableName, column.ToString()))
                        {
                            row[variableName] = Convert.ChangeType(childNode.InnerText, column.DataType);
                        }
                        else
                        {
                            row[variableName] = DBNull.Value;
                        }
                    }

                    dataTable.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Файл не найден.");
            }

            return dataTable;
        }


        public static void SaveDataSetToXmlFile(DataSet dataSet, string nameFile)
        {
            foreach (DataTable resultTable in dataSet.Tables)
            {
                foreach (DataRow row in resultTable.Rows)
                {
                    for (int i = 0; i < resultTable.Columns.Count; i++)
                    {
                        DataColumn column = resultTable.Columns[i];
                        if (row[i] == DBNull.Value)
                        {
                            if (column.DataType == typeof(string))
                            {
                                row[i] = DBNull.Value;
                            }
                            else if (column.DataType == typeof(int) || column.DataType == typeof(long))
                            {
                                row[i] = DBNull.Value;
                            }
                            // Другие типы данных также можно обработать по аналогии
                        }
                    }
                }
            }

            string filePath = Path.Combine(@"C:\я у мамы программист\3 курс 1 семестр РПБД\1 лаба\1 лаба но уже на формах\RPBD_LAB_1_WINFORM\", nameFile);

            dataSet.WriteXml(filePath);
        }



        //public static  void SaveDataSetToXmlFile(DataSet dataSet, string nameFile)
        //{
        //    foreach (DataTable resultTable in dataSet.Tables)
        //    {
        //        foreach (DataRow row in resultTable.Rows)
        //        {
        //            for (int i = 0; i < resultTable.Columns.Count; i++)
        //            {
        //                if (row[i] == DBNull.Value)
        //                {
        //                    MessageBox.Show($"{row[i].ToString()}");
        //                    // Заменяем null на значение по умолчанию (пустая строка или 0, в зависимости от типа столбца)
        //                    DataColumn column = resultTable.Columns[i];
        //                    if (column.DataType == typeof(string))
        //                    {
        //                        row[i] = string.Empty;
        //                    }
        //                    else if (column.DataType == typeof(int))
        //                    {
        //                        row[i] = 0;
        //                    }
        //                    else if(column.DataType == typeof(long))
        //                    {
        //                        row[i] = 0l;
        //                    }
        //                    // Другие типы данных также можно обработать по аналогии
        //                }
        //            }
        //        }
        //    }

        //    //string filePath = Path.Combine(GetRightPath(), nameFile);
        //    string filePath = Path.Combine(@"C:\Users\Prosc\OneDrive\Рабочий стол\RPBD_LAB_1_WINFORM\", nameFile);
        //    dataSet.WriteXml(filePath);
        //}

        #endregion

        #region JOIN
        public static DataTable JoinDataTables(DateTime minDateWork, DateTime maxDateWork)
        {
            var query = from emp in employeesTable.AsEnumerable()
                        join work in worksTable.AsEnumerable() on emp.Field<int?>("employee_id") equals work.Field<int?>("employee_id") into workGroup
                        from work in workGroup.DefaultIfEmpty()

                        join order in ordersTable.AsEnumerable() on work?.Field<int?>("order_id") equals order.Field<int?>("order_id") into orderGroup
                        from order in orderGroup.DefaultIfEmpty()

                        join job in jobListTable.AsEnumerable() on work?.Field<int?>("joblist_id") equals job.Field<int?>("joblist_id") into joblistGroup
                        from job in joblistGroup.DefaultIfEmpty()

                        join client in clientsTable.AsEnumerable() on order?.Field<int?>("client_id") equals client.Field<int?>("client_id") into clientGroup
                        from client in clientGroup.DefaultIfEmpty()

                        join division in divisionsTable.AsEnumerable() on emp.Field<int?>("division_id") equals division.Field<int?>("division_id") into divisionGroup
                        from division in divisionGroup.DefaultIfEmpty()

                        select new
                        {
                            DivisionName = division?.Field<string>("division_name") ?? "null",
                            EmployeeName = emp.Field<string>("employee_name"),
                            ObjectName = order?.Field<string>("object_name") ?? "null",
                            JobName = job?.Field<string>("job_name") ?? "null",
                            ClientName = client?.Field<string>("client_name") ?? "null",
                            Phone = client?.Field<long>("phone") ?? 0, // Обработка NULL
                            WorkContent = order?.Field<string>("work_content") ?? "null",
                            StartDateWork = work?.Field<DateTime>("start_date_work") ?? DateTime.MinValue, // Обработка NULL
                            EndDateWork = work?.Field<DateTime>("end_date_work") ?? DateTime.MinValue, // Обработка NULL
                            JobDescription = work?.Field<string>("job_description") ?? "null"
                        };

            // Создание DataTable с колонками
            DataTable resultTable = new DataTable("ViewAllJoin");
            resultTable.Columns.Add("Название подразделения", typeof(string));
            resultTable.Columns.Add("ФИО работника", typeof(string));
            resultTable.Columns.Add("Название объекта", typeof(string));
            resultTable.Columns.Add("Название работы", typeof(string));
            resultTable.Columns.Add("ФИО клиента", typeof(string));
            resultTable.Columns.Add("Телефон", typeof(long));
            resultTable.Columns.Add("Содержание работ", typeof(string));
            resultTable.Columns.Add("Дата начала работы", typeof(DateTime));
            resultTable.Columns.Add("Дата завершения работы", typeof(DateTime));
            resultTable.Columns.Add("Описание работ", typeof(string));

            foreach (var row in query)
            {
                if (row.StartDateWork >= minDateWork && row.EndDateWork <= maxDateWork)
                {
                    resultTable.Rows.Add(
                    row.DivisionName,
                    row.EmployeeName,
                    row.ObjectName,
                    row.JobName,
                    row.ClientName,
                    row.Phone,
                    row.WorkContent,
                    row.StartDateWork,
                    row.EndDateWork,
                    row.JobDescription);
                }
            }

            return resultTable;
        }

        #endregion

        #region JOIN VIEW TABLES
        public static DataTable ViewDivisions(DataSet dataSet)
        {
            DataTable returnDataTable = new DataTable("ViewDivisions");

            // Добавляем столбцы в таблицу
            DataColumn idColumn = new DataColumn("division_id", typeof(int));
            //idColumn.Unique = true;
            //idColumn.AllowDBNull = false;
            //idColumn.AutoIncrement = true;
            //idColumn.AutoIncrementSeed = 1;
            //idColumn.AutoIncrementStep = 1;
            returnDataTable.Columns.Add(idColumn);
            returnDataTable.Columns.Add("Название подразделения", typeof(string));

            // Получаем данные из таблицы Divisions
            DataTable divisionsTable = dataSet.Tables["Divisions"];
            
            // Заполняем таблицу ViewDivisions данными из Divisions
            foreach (DataRow divisionRow in divisionsTable.Rows)
            {
                int divisionID = divisionRow.Field<int>("division_id");
                string divisionName = divisionRow.Field<string>("division_name");
                returnDataTable.Rows.Add(divisionID, divisionName); // Первый столбец (division_view_id) заполняется автоматически
            }

            return returnDataTable;
        }

        public static DataTable ViewEmployees(DataSet dataSet)
        {
            DataTable divisionsTable = dataSet.Tables["Divisions"];

            DataTable employeesTable = dataSet.Tables["Employees"];

            var query = from emp in employeesTable.AsEnumerable()
                        join div in divisionsTable.AsEnumerable() on emp.Field<int?>("division_id") equals div.Field<int?>("division_id") into divGroup from div in divGroup.DefaultIfEmpty()
                        select new
                        {
                            EmployeeName = emp.Field<string>("employee_name"),
                            BirthdayDate = emp.Field<DateTime>("birthday_date"),
                            Inn = emp.Field<string>("inn"),
                            Snils = emp.Field<string>("snils"),
                            DivisionName = div?.Field<string>("division_name") ?? "null",
                            PassportDataSeries = emp.Field<string>("passport_data_series"),
                            PassportDataNumbers = emp.Field<string>("passport_data_numbers")
                        };

            DataTable combinedTable = new DataTable("ViewEmployees");
            DataColumn idColumn = new DataColumn("employee_id", typeof(int));
            //idColumn.Unique = true; // столбец будет иметь уникальное значение
            //idColumn.AllowDBNull = false; // не может принимать null
            //idColumn.AutoIncrement = true; // будет автоинкрементироваться
            //idColumn.AutoIncrementSeed = 1; // начальное значение
            //idColumn.AutoIncrementStep = 1; // приращение при добавлении новой строки
            combinedTable.Columns.Add(idColumn);
            combinedTable.Columns.Add("ФИО работника", typeof(string));
            combinedTable.Columns.Add("Дата рождения", typeof(DateTime));
            combinedTable.Columns.Add("ИНН", typeof(string));
            combinedTable.Columns.Add("СНИЛС", typeof(string));
            combinedTable.Columns.Add("Название подразделения*", typeof(string));
            combinedTable.Columns.Add("Серия паспорта", typeof(string));
            combinedTable.Columns.Add("Номер паспорта", typeof(string));

            int id = 1;
            foreach (var row in query)
            {
                combinedTable.Rows.Add(id, row.EmployeeName, row.BirthdayDate, row.Inn, row.Snils, row.DivisionName, row.PassportDataSeries, row.PassportDataNumbers);
                id++;
            }
            return combinedTable;
        }

        public static DataTable ViewWork(DataSet dataSet)
        {
            DataTable employeesTable = dataSet.Tables["Employees"];

            DataTable ordersTable = dataSet.Tables["Orders"];

            DataTable worksTable = dataSet.Tables["Work"];

            DataTable jobListTable = dataSet.Tables["JobList"];

            var query = from work in worksTable.AsEnumerable()
                        join order in ordersTable.AsEnumerable()
                        on work.Field<int?>("order_id") equals order.Field<int?>("order_id") into orderJoin
                        from order in orderJoin.DefaultIfEmpty()
                        join jobList in jobListTable.AsEnumerable()
                        on work.Field<int?>("joblist_id") equals jobList.Field<int?>("joblist_id") into jobListJoin
                        from jobList in jobListJoin.DefaultIfEmpty()
                        join employee in employeesTable.AsEnumerable()
                        on work.Field<int?>("employee_id") equals employee.Field<int?>("employee_id") into employeeJoin
                        from employee in employeeJoin.DefaultIfEmpty()
                        select new
                        {
                            ObjectName = order?.Field<string>("object_name") ?? "null",
                            JobName = jobList?.Field<string>("job_name") ?? "null",
                            EmployeeName = employee?.Field<string>("employee_name") ?? "null",
                            StartDateWork = work.Field<DateTime>("start_date_work"),
                            EndDateWork = work.Field<DateTime>("end_date_work"),
                            JobDescription = work.Field<string>("job_description")
                        };



            DataTable resultTable = new DataTable("ViewWork");
            DataColumn idColumn = new DataColumn("work_view_id", typeof(int));
            
            resultTable.Columns.Add(idColumn);
            resultTable.Columns.Add("Название объекта*", typeof(string));
            resultTable.Columns.Add("Название работы*", typeof(string));
            resultTable.Columns.Add("Имя работника*", typeof(string));
            resultTable.Columns.Add("Дата начала работы", typeof(DateTime));
            resultTable.Columns.Add("Дата окончания работы", typeof(DateTime));
            resultTable.Columns.Add("Описание работ", typeof(string));

            int id = 0;
            foreach (var row in query)
            {
                id++;
                resultTable.Rows.Add(id, row.ObjectName, row.JobName, row.EmployeeName, row.StartDateWork, row.EndDateWork, row.JobDescription);
            }
            return resultTable;
        }

        public static DataTable ViewJobList(DataSet dataSet)
        {
            DataTable resultTable = new DataTable("ViewJobList");
            DataColumn idColumn = new DataColumn("joblist_view_id", typeof(int));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = false; // не может принимать null
            idColumn.AutoIncrement = true; // будет автоинкрементироваться
            idColumn.AutoIncrementSeed = 1; // начальное значение
            idColumn.AutoIncrementStep = 1; // приращение при добавлении новой строки
            resultTable.Columns.Add(idColumn);
            resultTable.Columns.Add("Название работы", typeof(string));

            DataTable jobListTable = dataSet.Tables["JobList"];

            foreach (DataRow joblistRow in jobListTable.Rows)
            {
                string jobName = joblistRow.Field<string>("job_name");
                resultTable.Rows.Add(null, jobName); 
            }         

            return resultTable;
        }

        public static DataTable ViewClients(DataSet dataSet)
        {
            DataTable resultTable = new DataTable("ViewClients");
            DataColumn idColumn = new DataColumn("client_view_id", typeof(int));
            idColumn.AutoIncrement = true; // будет автоинкрементироваться
            idColumn.AutoIncrementSeed = 1; // начальное значение
            idColumn.AutoIncrementStep = 1; // приращение при добавлении новой строки
            resultTable.Columns.Add(idColumn);
            resultTable.Columns.Add("ФИО клиента", typeof(string));
            resultTable.Columns.Add("Телефон", typeof(long));
            resultTable.Columns.Add("Адресс", typeof(string));
            resultTable.Columns.Add("ИНН", typeof(string));

            DataTable clientTable = dataSet.Tables["Clients"];

            foreach (DataRow clientRow in clientTable.Rows)
            {
                string clientName = clientRow.Field<string>("client_name");
                long clientPhone = clientRow.Field<long>("phone");
                string clientAddress = clientRow.Field<string>("address");
                string clientInn = clientRow.Field<string>("inn");
                resultTable.Rows.Add(null, clientName, clientPhone, clientAddress, clientInn);
            }

            return resultTable;
        }

        public static DataTable ViewOrders(DataSet dataSet)
        {
            DataTable clientsTable = dataSet.Tables["Clients"];

            DataTable ordersTable = dataSet.Tables["Orders"];


            // Выполняем JOIN между таблицами с использованием LINQ
            var query = from order in ordersTable.AsEnumerable()
                        join client in clientsTable.AsEnumerable() on order.Field<int?>("client_id") equals client.Field<int?>("client_id") into clientGroup
                        from client in clientGroup.DefaultIfEmpty()
                        select new
                        {
                            ClientName = client?.Field<string>("client_name") ?? "null",
                            ObjectName = order.Field<string>("object_name"),
                            WorkContent = order.Field<string>("work_content"),
                            StartDateOrder = order.Field<DateTime>("start_date_order"),
                            EndDateOrder = order.Field<DateTime>("end_date_order")
                        };

            DataTable resultTable = new DataTable("ViewOrders");
            resultTable.Columns.Add("order_view_id", typeof(int));
            resultTable.Columns.Add("ФИО клиента*", typeof(string));
            resultTable.Columns.Add("Название объекта", typeof(string));
            resultTable.Columns.Add("Содержание работ", typeof(string));
            resultTable.Columns.Add("Дата заключения сделки", typeof(DateTime));
            resultTable.Columns.Add("Дата завершения сделки", typeof(DateTime));

            int id = 1;
            foreach (var row in query)
            {
                resultTable.Rows.Add(id, row.ClientName, row.ObjectName, row.WorkContent, row.StartDateOrder, row.EndDateOrder);
                id++;
            }
            return resultTable;
        }
        #endregion

        #region GET
        public static List<string> GetTableNames()
        {
            List<string> tableNames = new List<string>();
            foreach (DataTable dataTable in dataSet.Tables)
            {
                tableNames.Add(dataTable.TableName);
            }
            return tableNames;
        }

        public string GetValueAtIndex(DataRowView rowView, int columnIndex)
        {
            if (rowView != null && columnIndex >= 0 && columnIndex < rowView.Row.ItemArray.Length)
            {
                object value = rowView.Row.ItemArray[columnIndex];
                return value != null ? value.ToString() : "";
            }

            return null; // или можно вернуть null, в зависимости от вашей логики
        }

        public static List<string> GetColumnValues(DataTable dataTable, string columnName)
        {
            List<string> columnValues = new List<string>();

            foreach (DataRow row in dataTable.Rows)
            {
                columnValues.Add(row[columnName].ToString());
            }

            return columnValues;
        }

        public static string GetRightPath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            for (int i = 0; i < 4; i++)
            {
                DirectoryInfo parentDirectory = Directory.GetParent(currentDirectory);

                if (parentDirectory != null)
                {
                    currentDirectory = parentDirectory.FullName;
                }
                else
                {
                    // Достигнут корень файловой системы, не удается перейти выше
                    break;
                }
            }
            return currentDirectory;
        }
        #endregion

        public static void DownloadData()
        {
            dataSet = new DataSet("UsersSet");

            jobListTable = CreateTableJobList();
            divisionsTable = CreateTableDivisions();
            employeesTable = CreateTableEmployees();
            clientsTable = CreateTableClients();
            ordersTable = CreateTableOrders();
            worksTable = CreateTableWorks();

            dataSet.Tables.Add(divisionsTable);
            dataSet.Tables.Add(employeesTable);
            dataSet.Tables.Add(worksTable);
            dataSet.Tables.Add(jobListTable);
            dataSet.Tables.Add(ordersTable);
            dataSet.Tables.Add(clientsTable);


            # region Создаем связи между таблицами
            dataSet.Relations.Add(new DataRelation("Employees To Divisions",
                divisionsTable.Columns["division_id"],
                employeesTable.Columns["division_id"]));

            dataSet.Relations.Add(new DataRelation("Work To Employees",
                employeesTable.Columns["employee_id"],
                worksTable.Columns["employee_id"]));

            dataSet.Relations.Add(new DataRelation("Work To Orders",
                ordersTable.Columns["order_id"],
                worksTable.Columns["order_id"]));

            dataSet.Relations.Add(new DataRelation("Work To JobList",
                jobListTable.Columns["joblist_id"],
                worksTable.Columns["joblist_id"]));

            dataSet.Relations.Add(new DataRelation("Orders To Clients",
                clientsTable.Columns["client_id"],
                ordersTable.Columns["client_id"]));
            #endregion



            string fileName = "GIgaData.xml";

           // string pathToreadXmlFile = Path.Combine(GetRightPath(), fileName);

            string pathToreadXmlFile = @"C:\я у мамы программист\3 курс 1 семестр РПБД\1 лаба\1 лаба но уже на формах\RPBD_LAB_1_WINFORM\GIgaData.xml";


            divisionsTable = ReadDataFromXmlFile(pathToreadXmlFile, divisionsTable, "Divisions");

            employeesTable = ReadDataFromXmlFile(pathToreadXmlFile, employeesTable, "Employees");

            jobListTable = ReadDataFromXmlFile(pathToreadXmlFile, jobListTable, "JobList");

            clientsTable = ReadDataFromXmlFile(pathToreadXmlFile, clientsTable, "Clients");

            ordersTable = ReadDataFromXmlFile(pathToreadXmlFile, ordersTable, "Orders");

            worksTable = ReadDataFromXmlFile(pathToreadXmlFile, worksTable, "Work");

            
            //SaveDataSetToXmlFile(dataSet, "GIgaData.xml");
        } 
    }
}
