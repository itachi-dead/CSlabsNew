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
        public MyCustomCollection<Client> Clients { get; set; }
        public MyCustomCollection<Income> Income { get; set; }

        public Bank()
        {
            this.Clients = new MyCustomCollection<Client>();
            this.Income = new MyCustomCollection<Income>();
        }


    }
}
