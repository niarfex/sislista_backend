using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotDataFoundException : Exception
    {
        public NotDataFoundException(string message) : base(message)
        {
        }
        public NotDataFoundException(string message, Exception cause) : base(message, cause)
        {
        }
    }
}
