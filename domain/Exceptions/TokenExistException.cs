using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class TokenExistException : Exception
    {
        public TokenExistException(string message) : base(message)
        {
        }
        public TokenExistException(string message, Exception cause) : base(message, cause)
        {
        }
    }
}
