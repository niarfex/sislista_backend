using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ExportExcel
{
    public class LineaProduccionExcel
    {
        [Description("Código")]
        public string? CodigoLineaProduccion { get; set; }
        [Description("Nombre")]
        public string? LineaProduccion { get; set; }
        [Description("Descripción")]
        public string? DescripcionLineaProduccion { get; set; }
        [Description("Estado")]
        public int Estado { get; set; }
    }
}
