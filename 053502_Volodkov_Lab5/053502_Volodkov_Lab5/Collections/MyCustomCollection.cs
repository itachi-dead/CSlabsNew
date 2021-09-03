﻿using _053502_Volodkov_Lab5.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Volodkov_Lab5.Collections
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
                if(index >= count)
                {
                    throw new IndexOutOfRangeException(nameof(index));
                }
                Node<T> current = head;
                int i = index+1;
                while(count - i > 0)
                {
                    i++;
                    current = current.Next;
                }
                return current.Data;
            }
        }
        public void Next()
        {
            if(cursor < count )
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
            int i = cursor+ 1;
            while (count - i > 0)
            {
                i++;
                current = current.Next;
            }
            return current.Data;
        }
        public void Add(T item)
        {
            // увеличиваем стек
            Node<T> node = new Node<T>(item);
            node.Next = head; // переустанавливаем верхушку стека на новый элемент
            head = node;
            count++;
        }

        public void Remove(T item)
        {
            Node<T> newHead = default;
            foreach(var i in this)
            {
                if (i.Equals(item))
                {
                    continue;
                }
                Node<T> node = new Node<T>(i);
                node.Next = newHead; // переустанавливаем верхушку стека на новый элемент
                newHead = node;
            }
            head = newHead;
           
        }

        public T RemoveCurrent()
        {
            T item = Current();
            Remove(Current());
             return item;
        }
        //public T Pop()
        //{
        //    // если стек пуст, выбрасываем исключение
        //    if (IsEmpty)
        //        throw new InvalidOperationException("Стек пуст");
        //    Node<T> temp = head;
        //    head = head.Next; // переустанавливаем верхушку стека на следующий элемент
        //    count--;
        //    return temp.Data;
        //}
        //public T PopCurrent()
        //{
        //    if (IsEmpty)
        //        throw new InvalidOperationException("Стек пуст");

        //    int j = 0;
        //    Node<T> temp;
        //    foreach (var i in this)
        //    {
        //        if (j == cursor)
        //        {
        //            continue;
        //        }
        //        j++;
        //    }
        //}
        //public T Peek()
        //{
        //    if (IsEmpty)
        //        throw new InvalidOperationException("Стек пуст");
        //    return head.Data;
        //}

        //public T Current()
        //{
        //    int j = 0;
        //    foreach(var i in this)
        //    {
        //        if(j == cursor)
        //        {
        //            return i;
        //        }
        //        j++;
        //    }
        //    return default;
        //}
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