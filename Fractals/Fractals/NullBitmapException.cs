using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fractals
{
    class NullBitmapException : Exception
    {
        public NullBitmapException()
        { 
        }

        public NullBitmapException(string message)
            : base(message)
        { 
        
        }

        public NullBitmapException(string message, Exception inner)
            : base(message, inner)
        { 
        
        }
    }
}
