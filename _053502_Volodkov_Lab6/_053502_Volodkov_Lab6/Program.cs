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

            Bank a = new Bank(new MyCustomCollection<Client>() {
                new Client(),
                new Client(),
                new Client(),
                new Client(),
                new Client()},
                new MyCustomCollection<Income>() {new Income()});
        }
    }
}
