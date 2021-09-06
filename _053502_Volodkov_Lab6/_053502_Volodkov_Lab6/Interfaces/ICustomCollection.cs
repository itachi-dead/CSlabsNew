using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Volodkov_Lab6.Interfaces
{
    interface ICustomCollection<T> 
    {

        public T this[int index] { get; }

        public void Reset();

        public void Next();

        public T Current();

        public int Count { get; }

        public void Add(T item);

        public void Remove(T item);

        public T RemoveCurrent();

        
    }
}
