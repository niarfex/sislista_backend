using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class EmailExistException : Exception
    {
        public EmailExistException(string message) : base(message)
        {
        }
        public EmailExistException(string message, Exception cause) : base(message, cause)
        {
        }
    }
}
