using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fractals
{
    public class Queue<T>
    {
        Node<T> QueueFront;
        Node<T> QueueBack;
        int count;

        public Queue()
        {
           
            this.QueueFront = this.QueueBack = null;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (this.QueueBack == null)
            {
                this.QueueFront = this.QueueBack = newNode;
            }
            else
            {
                this.QueueBack.Next = newNode;
                this.QueueBack = newNode;
            }
            count++;
        }
        public T Dequeue()
        {
            if (this.Empty())
            {
                throw new QueueUnderflowException("Queue Underflow Error");
            }
            else 
            {
                count--;
                Node<T> tempNode = this.QueueFront;
                this.QueueFront = this.QueueFront.Next;
                if (this.Empty())
                {
                    this.QueueBack = null;
                }
                return tempNode.Data;
            }
        }
        public bool Empty()
        {
            return this.QueueFront == null;
        }

    }
}
