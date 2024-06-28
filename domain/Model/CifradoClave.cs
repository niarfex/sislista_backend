using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class CifradoClave
    {
        [Description("P_TXT_CLAVE")]
        public string? Clave { get; set; }

        [Description("P_TXT_CLAVE_ENCRIPTADA")]
        public string ClaveEncriptada { get; set; }
    }
}
