using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fractals
{
    class StackUnderflowException : Exception
    {
        public StackUnderflowException()
        { 
        }
        public StackUnderflowException(string message)
            : base(message)
        { 
        
        }
        public StackUnderflowException(string message, Exception inner)
            : base(message, inner)
        { 
        
        }
    }
}
