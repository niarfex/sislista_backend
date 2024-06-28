using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class AuthModel
    {
        [Description("P_TXT_USUARIO")]
        public string username { get; set; }
        [Description("P_TXT_CLAVE")]
        public string password { get; set; }
    }
}
