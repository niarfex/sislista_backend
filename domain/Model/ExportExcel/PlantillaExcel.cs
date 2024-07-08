using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ExportExcel
{
    public class PlantillaExcel
    {
        [Description("Nombre")]
        public string? Plantilla { get; set; }
        [Description("Autor")]
        public string? UsuarioCreacion { get; set; }
        [Description("Fecha de creación")]
        public DateTime? FechaRegistro { get; set; }
        [Description("Último editor")]
        public string? UsuarioActualizacion { get; set; }
        [Description("Fecha de última modificación")]
        public DateTime? FechaActualizacion { get; set; }
        [Description("Estado")]
        public int Estado { get; set; }
        
        
        
        
    }
}
