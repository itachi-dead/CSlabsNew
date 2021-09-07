using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Volodkov_Lab6.Entities
{
    class NoItemException : Exception
    {
        public NoItemException(string message)
            : base(message)
        { }
    }
}
