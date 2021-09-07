using _053502_Volodkov_Lab6.Collections;
using _053502_Volodkov_Lab6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Volodkov_Lab6.Entities
{
    class Bank
    {

        public delegate void AccountHandler(string message);
        public event AccountHandler Notify;

        private MyCustomCollection<Client> Clients { get; set; }
        private MyCustomCollection<Income> Income { get; set; }
        public Journal journal;

        public Bank()
        {
            this.Clients = new MyCustomCollection<Client>() {
                    new Client{FirstName = "Savely", SecondName ="Volodkov", Age = 18 , Money = 12312, BankName = "BestBank" , Percentage = 20},
                    new Client{FirstName = "Kakaqwe", SecondName ="Galosha", Age = 26 , Money = 12, BankName = "BestBank", Percentage = 30},
                    new Client{FirstName = "Masha", SecondName ="KASD:ASD", Age = 40 , Money = 100, BankName = "Alphabank", Percentage = 10},
                    new Client{FirstName = "Dima", SecondName ="Seberyak", Age = 20 , Money = 3000, BankName = "Alphabank", Percentage = 15},
                    new Client{FirstName = "Anton", SecondName ="Shklov", Age = 28 , Money = 400, BankName = "MTBank", Percentage = 9}
            };

            this.Income = new MyCustomCollection<Income>() {
                new Income{Name = "BestBank" , Percentage = new List<int>{20, 15, 30, 40} },
                new Income{Name = "Alphabank" , Percentage = new List<int>{15, 10 } },
                new Income{Name = "MTBank" , Percentage = new List<int>{12,9} }
            };

            this.journal = new Journal();
            Notify += journal.DisplayMessage;
        }

        public void StartUp()
        {
            while (true)
            {
                Console.WriteLine("1 - Информация о процентах по вкладам");
                Console.WriteLine("2 - Информация о клиентах");
                Console.WriteLine("3 - Изменить информацию о клиентах");
                Console.WriteLine("4 - Изменить информацию о вкладах у банков");
                Console.WriteLine("5 - Пополнить клиенту велечину вклада");
                Console.WriteLine("6 - Общая сумма выплат по процентам для всех вкладов");
                Console.WriteLine("0 - Выход");
                ConsoleKey consoleKey = Console.ReadKey().Key;
                switch (consoleKey)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine();
                        for (int i = 0; i < Income.Count; i++)
                        {
                            Income[i].Show();
                        }

                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine();
                        for (int i = 0; i < Clients.Count; i++)
                        {
                            Clients[i].Show();
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine();
                        Console.WriteLine("1 - Изменить вклад клиента");
                        Console.WriteLine("2 - Добавить клиента");
                        ConsoleKey temp = Console.ReadKey().Key;
                        switch (temp)
                        {
                            case ConsoleKey.D1:
                                Console.WriteLine();
                                for (int i = 0; i < Clients.Count; i++)
                                {
                                    Clients[i].Show();
                                }
                                Console.WriteLine("Выберите клиента");
                                int index = Int32.Parse(Console.ReadLine());

                                Console.WriteLine();
                                for (int i = 0; i < Income.Count; i++)
                                {
                                    Income[i].Show();
                                }
                                Console.WriteLine("Выберите банк");
                                int bankIndex = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Выберите вклад");
                                int incomeIndex = Int32.Parse(Console.ReadLine());

                                Clients[index - 1].BankName = Income[bankIndex - 1].Name;
                                Clients[index - 1].Percentage = Income[bankIndex - 1].Percentage[incomeIndex - 1];

                                Notify?.Invoke("User changed");
                                break;
                            case ConsoleKey.D2:
                                Client client = new Client();
                                Console.WriteLine("Введите Имя Фамилию Возраст и кол-во денег у данного клиента");
                                client.FirstName = Console.ReadLine();
                                client.SecondName = Console.ReadLine();
                                client.Age = Int32.Parse(Console.ReadLine());
                                client.Money = Int32.Parse(Console.ReadLine());

                                Console.WriteLine();
                                for (int i = 0; i < Income.Count; i++)
                                {
                                    Income[i].Show();
                                }
                                Console.WriteLine("Выберите банк");
                                int newBankIndex = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Выберите вклад");
                                int newIncomeIndex = Int32.Parse(Console.ReadLine());

                                client.BankName = Income[newBankIndex - 1].Name;
                                client.Percentage = Income[newBankIndex - 1].Percentage[newIncomeIndex - 1];

                                Clients.Add(client);
                                Notify?.Invoke("User added");

                                break;
                        }
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine();
                        for (int i = 0; i < Income.Count; i++)
                        {
                            Income[i].Show();
                        }
                        Console.WriteLine("Выберите банк");
                        int t = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("На сколько процентов вы хотите добавить вклад?");
                        int percentage = Int32.Parse(Console.ReadLine());
                        Income[t - 1].Percentage.Add(percentage);
                        Notify?.Invoke("Income Added");

                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine();
                        for (int i = 0; i < Clients.Count; i++)
                        {
                            Clients[i].ShowMoney();
                        }

                        Console.WriteLine("Выберите человека, чей вклад хотите пополнить");
                        int q = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("На сколько:");
                        int w = Int32.Parse(Console.ReadLine());
                        Clients[q - 1].Money += w;
                        break;
                    case ConsoleKey.D6:
                        for (int i = 0; i < Clients.Count; i++)
                        {
                            for (int j = 0; j < Income.Count; j++)
                            {
                                if (Income[j].Name == Clients[i].BankName)
                                {
                                    Console.WriteLine($"{Clients[i].FirstName} {Clients[i].SecondName} - {Clients[i].Money * Clients[i].Percentage / 100} per year");
                                }
                            }
                        }
                        break;
                    case ConsoleKey.D7:
                        Console.Clear();
                        for(int i = 0; i < journal.changeList.Count; i++)
                        {
                            Console.WriteLine(journal.changeList[i]);
                        }
                        break;
                    default:
                        return;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

    }
}
