using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Volodkov_Lab6.Entities
{
    class Client
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public int Age { get; set; }

        public int Money { get; set; }

        public string BankName { get; set; }

        public void Show()
        {
            Console.WriteLine($"{FirstName} {SecondName} {Age} years, Bank : {BankName} ");
        }

        public void ShowMoney()
        {
            Console.WriteLine($"{SecondName} , Bank : {BankName} - {Money}");
        }
    }
}
