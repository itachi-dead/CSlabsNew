using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Volodkov_Lab5.Entities
{
    class Income
    {
        public string Name { get; set; }

        public int Percentage { get; set; }

        public void Show()
        {
            Console.WriteLine($"{Name}, {Percentage}");
        }
    }
}
