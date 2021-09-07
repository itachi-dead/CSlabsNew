using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Volodkov_Lab6.Entities
{
    class Income
    {
        public string Name { get; set; }

        public List<int> Percentage { get; set; }

        public void Show()
        {
            Console.WriteLine($"{Name},");
            for(int i = 0; i < Percentage.Count; i++)
            {
                Console.WriteLine($"---{Percentage[i]}");
            }
        }
    }
}
