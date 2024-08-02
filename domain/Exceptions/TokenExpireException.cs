using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class TokenExpireException : Exception
    {
        public TokenExpireException(string message) : base(message)
        {
        }
        public TokenExpireException(string message, Exception cause) : base(message, cause)
        {
        }
    }
}
