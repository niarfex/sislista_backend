using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class LoginResponse
    {
        public string username { get; set; }
        public string numeroDocumento { get; set; }
        public string accessToken { get; set; }
    }
}
