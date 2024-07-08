using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ExportExcel
{
    public class EspecieExcel
    {
        [Description("Código")]
        public string? CodigoEspecie { get; set; }
        [Description("Especie")]
        public string? Especie { get; set; }
        [Description("Descripción")]
        public string? DescripcionEspecie { get; set; }
        [Description("Estado")]
        public int Estado { get; set; }
    }
}
