using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ExportExcel
{
    public class TipoExplotacionExcel
    {
        [Description("Código")]
        public string? CodigoTipoExplotacion { get; set; }
        [Description("Nombre")]
        public string? TipoExplotacion { get; set; }
        [Description("Descripción")]
        public string? DescripcionTipoExplotacion { get; set; }
        [Description("Estado")]
        public int Estado { get; set; }
    }
}
