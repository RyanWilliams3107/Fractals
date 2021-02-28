using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fractals
{
    class Node<T>
    {
        private T data;
        private Node<T> next_node;
        public T Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }
        public Node<T> Next
        {
            get
            {
                return this.next_node;
            }
            set
            {
                this.next_node = value;
            }
        }
        public Node(T _data)
        {
            this.data = _data;
            this.next_node = null;
        }
    }
}
