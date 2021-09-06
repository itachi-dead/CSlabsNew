using _053502_Volodkov_Lab5.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Volodkov_Lab5.Entities
{
    class Bank
    {
        public void Show(ICustomCollection<Income> bank)
        {
            for (int i = 0; i < bank.Count; i++)
            {
                bank[i].Show();
            }
        }
        public void Show(ICustomCollection<Client> clients)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Show();
            }
        }

        public void ShowMoney(ICustomCollection<Client> clients)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].ShowMoney();
            }

            Console.WriteLine("Выберите человека, чей вклад хотите пополнить");
            int q = Int32.Parse(Console.ReadLine());

            Console.WriteLine("На сколько:");
            int w = Int32.Parse(Console.ReadLine());
            clients[q - 1].Money += w;
        }
        public void Show(ICustomCollection<Client> clients , ICustomCollection<Income> bank)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                for (int j = 0; j < bank.Count; j++)
                {
                    if (bank[j].Name == clients[i].BankName)
                    {
                        Console.WriteLine($"{clients[i].FirstName} {clients[i].SecondName} - {clients[i].Money * bank[j].Percentage / 100} per year");
                    }
                }
            }
        }
    }
}
