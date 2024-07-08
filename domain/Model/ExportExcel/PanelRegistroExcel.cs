using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ExportExcel
{
    public class PanelRegistroExcel
    {
        [Description("Periodo")]
        public string? Periodo { get; set; }
        [Description("Denominación")]
        public string? ProgramacionRegistro { get; set; }
        [Description("Fecha inicio")]
        public DateTime? FechaInicio { get; set; }
        [Description("Fecha de cierre")]
        public DateTime? FechaFin { get; set; }
        [Description("Estado")]
        public int EstadoProgramacion { get; set; } 

        //
        
    }
}
