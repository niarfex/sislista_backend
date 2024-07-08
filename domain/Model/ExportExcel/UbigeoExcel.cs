using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ExportExcel
{
    public class UbigeoExcel
    {
        [Description("Código Ubigeo")]
        public string Id { get; set; }
        [Description("Departamento")]
        public string Departamento { get; set; }
        [Description("Provincia")]
        public string Provincia { get; set; }
        [Description("Distrito")]
        public string Distrito { get; set; }
    }
}
