using _053502_Volodkov_Lab6.Collections;
using _053502_Volodkov_Lab6.Entities;
using _053502_Volodkov_Lab6.Interfaces;
using System;

namespace _053502_Volodkov_Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            bank.Notify += UserChangedPlan;
            bank.StartUp();
        }

        public static void UserChangedPlan(string message)
        {
            Console.WriteLine(message);
        }
    }
}
