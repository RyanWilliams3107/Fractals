 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fractals
{
    public class Stack<T>
    {

        Node<T> StackTop;
        int count;

        public Stack()
        {
            this.StackTop = null;
            this.count = 0;
        }
        public void Push(T value)
        { 
            Node<T> newNode = new Node<T>(value);
            if (this.StackTop == null)
            {
                newNode.Next = null;
            }
            else
            {
                newNode.Next = this.StackTop;
            }
            this.StackTop = newNode;
            this.count++;
        }
        public T Pop()
        {
            if (this.Empty())
            {
                throw new StackUnderflowException("Stack Underflow Error");
            }
            else
            {
                T tempData = this.StackTop.Data;
                this.StackTop = this.StackTop.Next;
                this.count--;
                return tempData;
            }
        }
        public T Peek()
        {
            if (this.Empty())
            {
                throw new StackUnderflowException("stack underflow error");
      
            }
            else
            {
                return this.StackTop.Data;
            }
        }
        public bool Empty()
        { 
            return this.StackTop == null;
        }
        public bool Find(T item)
        {
            Node<T> current = this.StackTop;
            bool found = false;
            while (current != null && !found)
            {
                if (current.Data.Equals(item))
                {
                    found = true;
                }
                current = current.Next;
            }
            return found;
        }
        public IEnumerable<T> GetStack()
        {
            List<T> StackAsList = new List<T>();
            for (Node<T> current = this.StackTop; current != null; current = current.Next)
            {
                StackAsList.Add(current.Data);
            }

            T[] StackAsArray = StackAsList.ToArray<T>();
            return StackAsArray;
        }
       
    }
}
