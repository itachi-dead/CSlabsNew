using _053502_Volodkov_Lab5.Collections;
using _053502_Volodkov_Lab5.Entities;
using _053502_Volodkov_Lab5.Interfaces;
using System;

namespace _053502_Volodkov_Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomCollection<object> collection = new MyCustomCollection<object>();

            ICustomCollection<Client> clients = new MyCustomCollection<Client>() { 
                    new Client{FirstName = "Savely", SecondName ="Volodkov", Age = 18 , Money = 12312, BankName = "BestBank"},
                    new Client{FirstName = "Kakaqwe", SecondName ="Galosha", Age = 26 , Money = 12, BankName = "BestBank"},
                    new Client{FirstName = "Masha", SecondName ="KASD:ASD", Age = 40 , Money = 100, BankName = "Alphabank"},
                    new Client{FirstName = "Dima", SecondName ="Seberyak", Age = 20 , Money = 3000, BankName = "Alphabank"},
                    new Client{FirstName = "Anton", SecondName ="Shklov", Age = 28 , Money = 400, BankName = "MTBank"},
            };
            ICustomCollection<Income> bank = new MyCustomCollection<Income>()
            {
                new Income{Name = "BestBank" , Percentage = 20},
                new Income{Name = "Alphabank" , Percentage = 15},
                new Income{Name = "MTBank" , Percentage = 12},
            };
            while (true)
            {
                Console.WriteLine("1 - Информация о процентах по вкладам");
                Console.WriteLine("2 - Информация о клиентах");
                Console.WriteLine("3 - Пополнить клиенту велечину вклада");
                Console.WriteLine("4 - Общая сумма выплат по процентам для всех вкладов");
                Console.WriteLine("0 - Выход");

                ConsoleKey consoleKey = Console.ReadKey().Key;
                switch (consoleKey)
                {
                    case ConsoleKey.D1:
                        for (int i = 0; i < bank.Count; i++)
                        {
                            bank[i].Show();
                        }
                        break;
                    case ConsoleKey.D2:
                        for (int i = 0; i < clients.Count; i++)
                        {
                            clients[i].Show();
                        }
                        break;
                    case ConsoleKey.D3:
                        for (int i = 0; i < clients.Count; i++)
                        {
                            clients[i].Show(1);
                        }

                        Console.WriteLine("Выберите человека, чей вклад хотите пополнить");
                        int q = Int32.Parse(Console.ReadLine());

                        Console.WriteLine("На сколько:");
                        int w = Int32.Parse(Console.ReadLine());
                        clients[q - 1].Money += w;
                        break;
                    case ConsoleKey.D4:
                        for(int i = 0; i < clients.Count; i++)
                        {
                            for(int j = 0; j < bank.Count; j++)
                            {
                                if(bank[j].Name == clients[i].BankName)
                                {
                                    Console.WriteLine($"{clients[i].FirstName} {clients[i].SecondName} - {clients[i].Money * bank[j].Percentage / 100} per year");
                                }
                            }
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
