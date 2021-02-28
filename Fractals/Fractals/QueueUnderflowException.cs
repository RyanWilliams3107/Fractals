using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fractals
{
    class QueueUnderflowException : Exception
    {
        public QueueUnderflowException()
        { 
        }

        public QueueUnderflowException(string message)
            : base(message)
        { 
        
        }

        public QueueUnderflowException(string message, Exception inner)
            : base(message, inner)
        { 
        
        }
    }
}
