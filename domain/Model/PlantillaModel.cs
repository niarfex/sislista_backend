using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class PlantillaModel
    {
        public long Id { get; set; }
        public string? Plantilla { get; set; }
        public string? Descripcion { get; set; }
        public long NumCuestionario { get; set; }
        public int Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? UsuarioCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string? UsuarioActualizacion { get; set; }
    }
}
