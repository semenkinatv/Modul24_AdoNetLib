using Modul24_AdoNetLib;
using System;

namespace Modul24_AdoNetModuleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new Manager();
            manager.Connect();

            Console.WriteLine("Список команд для работы консоли:");
            Console.WriteLine(Commands.stop + ": прекращение работы");
            Console.WriteLine(Commands.add + ": добавление данных");
            Console.WriteLine(Commands.delete + ": удаление данных");
            Console.WriteLine(Commands.update + ": обновление данных");
            Console.WriteLine(Commands.show + ": просмотр данных");

            Console.WriteLine();
            Console.WriteLine("Введите команду:");

            string command;
            do
            {
                Console.WriteLine("Введите команду:");
                command = Console.ReadLine();

                switch (command)
                {
                    case nameof(Commands.add):
                        {
                            Add(manager);
                            break;
                        }
                    case nameof(Commands.delete):
                        {
                            Delete(manager);
                            break;
                        }
                    case nameof(Commands.update):
                        {
                            Update(manager);
                            break;
                        }
                    case nameof(Commands.show):
                        {
                            manager.ShowData();
                            break;
                        }
                    case nameof(Commands.stop):
                        {
                            manager.Disconnect();
                            break;
                        }
                }
            }
            while (command != nameof(Commands.stop)) ;
            
            Console.ReadKey();

        }
        static void Add(Manager manager)
        {
            Console.WriteLine("Введите логин для добавления:");
            var login = Console.ReadLine();
            Console.WriteLine("Введите имя для добавления:");
            var name = Console.ReadLine();

            manager.AddUser(login, name);
            manager.ShowData();
        }

        static void Delete(Manager manager)
        {
            Console.WriteLine("Введите логин для удаления:");

            var count = manager.DeleteUserByLogin(Console.ReadLine());
            Console.WriteLine("Количество удаленных строк " + count);
            manager.ShowData();
        }

        static void Update(Manager manager)
        {
            Console.WriteLine("Введите логин, для которого требуется корректировка имени:");
            var login2 = Console.ReadLine();
            Console.WriteLine("Введите новое имя:");
            var name2 = Console.ReadLine();

            manager.UpdateUserByLogin_2(login2, name2);
            manager.ShowData();
        }
        public enum Commands
        {
            stop,
            add,
            delete,
            update,
            show
        }
    }
}
