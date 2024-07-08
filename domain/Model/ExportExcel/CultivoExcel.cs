using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ExportExcel
{
    public class CultivoExcel
    {
        [Description("ID Cultivo")]
        public string Id { get; set; }
        [Description("Cultivo")]
        public string Cultivo { get; set; }
    }
}
