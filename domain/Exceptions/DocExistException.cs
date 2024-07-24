using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class DocExistException : Exception
    {
        public DocExistException(string message) : base(message)
        {
        }
        public DocExistException(string message, Exception cause) : base(message, cause)
        {
        }
    }
}
