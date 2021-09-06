using _053502_Volodkov_Lab5.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Volodkov_Lab6.Collections
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    public class MyCustomCollection<T> : IEnumerable<T>, ICustomCollection<T>
    {
        Node<T> head;
        int count;
        public int cursor = 0;
        public bool IsEmpty
        {
            get { return count == 0; }
        }
        public int Count
        {
            get { return count; }
        }
        public T this[int index]
        {
            get
            {
                if (index >= count)
                {
                    throw new IndexOutOfRangeException(nameof(index));
                }
                Node<T> current = head;
                int i = index + 1;
                while (count - i > 0)
                {
                    i++;
                    current = current.Next;
                }
                return current.Data;
            }
        }
        public void Next()
        {
            if (cursor < count)
            {
                cursor++;
            }
        }

        public void Reset()
        {
            cursor = 0;
        }
        public T Current()
        {
            Node<T> current = head;
            int i = cursor + 1;
            while (count - i > 0)
            {
                i++;
                current = current.Next;
            }
            return current.Data;
        }
        public void Add(T item)
        {
            Node<T> node = new Node<T>(item);
            node.Next = head;
            head = node;
            count++;
        }

        public void Remove(T item)
        {
            bool isExist = false;
            foreach (var i in this)
            {
                if (i.Equals(item))
                {
                    isExist = true;
                    continue;
                }
            }
            Node<T> newHead = default;
            foreach (var i in this)
            {
                if (i.Equals(item))
                {
                    continue;
                }
                Node<T> node = new Node<T>(i);
                node.Next = newHead;
                newHead = node;
            }
            head = newHead;
            count--;
        }

        public T RemoveCurrent()
        {
            T item = Current();
            Remove(Current());
            return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
