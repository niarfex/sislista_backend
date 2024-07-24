using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class CodigoExistException : Exception
    {
        public CodigoExistException(string message) : base(message)
        {
        }
        public CodigoExistException(string message, Exception cause) : base(message, cause)
        {
        }
    }
}
