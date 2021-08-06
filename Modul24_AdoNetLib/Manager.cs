using System;
using System.Data;

namespace Modul24_AdoNetLib
{
    
    public class Manager
    {
        private MainConnector connector;
        private Table userTable;
        private DbExecutor dbExecutor;

        public Manager()
        {
            connector = new MainConnector();
            userTable = new Table();
            userTable.Name = "NetworkUser";
            userTable.ImportantField = "Login";
            userTable.Fields.Add("Id");
            userTable.Fields.Add("Login");
            userTable.Fields.Add("Name");
        }

        public void Connect()
        {
            var result = connector.ConnectAsync();

            if (result.Result)
            {
                Console.WriteLine("Подключено успешно!");

                dbExecutor = new DbExecutor(connector);
            }
            else
            {
                Console.WriteLine("Ошибка подключения!");
            }
        }

        public void Disconnect()
        {
            Console.WriteLine("Отключаем БД!");
            connector.DisconnectAsync();
        }

        public void ShowData()
        {
            var tablename = userTable.Name; // "NetworkUser";

            Console.WriteLine("Получаем данные таблицы " + tablename);

            var data = dbExecutor.SelectAll(tablename);

            Console.WriteLine("Количество строк в " + tablename + ": " + data.Rows.Count);

            Console.WriteLine();
            foreach (DataColumn column in data.Columns)
            {
                Console.Write($"{column.ColumnName}\t");
            }

            Console.WriteLine();

            foreach (DataRow row in data.Rows)
            {

                var cells = row.ItemArray;
                foreach (var cell in cells)
                {
                    Console.Write($"{cell}\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public int DeleteUserByLogin(string value)
        {
            return dbExecutor.DeleteByColumn(userTable.Name, userTable.ImportantField, value);
        }

        public void AddUser(string login, string name)
        {
            dbExecutor.ExecProcedureAdding(name, login);
        }

        public int UpdateUserByLogin_1(string value, string newvalue)
        {
            return dbExecutor.UpdateByColumn_1(userTable.Name, userTable.ImportantField, value, userTable.Fields[2], newvalue);
        }

        public int UpdateUserByLogin_2(string login, string newname)
        {
            return dbExecutor.UpdateByColumn_2(login, newname);
        }
        ////================Присоединенная модель===============================================
        //Console.WriteLine("Присоединенная модель");
        //var connector = new MainConnector();
        //var db = new DbExecutor(connector);
        //var tablename = "NetworkUser";

        //var reader = db.SelectAllCommandReader(tablename);
        //    var columnList = new List<string>();

        //    for (int i = 0; i < reader.FieldCount; i++)
        //    {
        //        var name = reader.GetName(i);
        //        columnList.Add(name);
        //    }

        //    for (int i = 0; i < columnList.Count; i++)
        //    {
        //        Console.Write($"{columnList[i]}\t");
        //    }
        //    Console.WriteLine();
        //    while (reader.Read())
        //    {
        //        for (int i = 0; i < columnList.Count; i++)
        //        {
        //            var value = reader[columnList[i]];
        //            Console.Write($"{value}\t");
        //        }

        //        Console.WriteLine();
        //    }
    }

}
