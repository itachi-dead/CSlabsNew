using _053502_Volodkov_Lab6.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Volodkov_Lab6.Entities
{
    class Journal
    {
        public MyCustomCollection<string> changeList;

        public Journal()
        {
            changeList = new MyCustomCollection<string>();
        }


        public void DisplayMessage(string message)
        {
            changeList.Add(message);
        }

    }
}
