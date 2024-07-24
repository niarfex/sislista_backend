using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class RelatedDataFoundException:Exception
    {
        public RelatedDataFoundException(string message) : base(message)
        {
        }
        public RelatedDataFoundException(string message, Exception cause) : base(message, cause)
        {
        }
    }
}
