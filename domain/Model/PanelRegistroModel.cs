using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class PanelRegistroModel
    {
        public long Id { get; set; } 
        public long? IdPlantilla { get; set; }
        public long? IdUsuario { get; set; }
        public long? IdAnio { get; set; }
        public string? ProgramacionRegistro { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? DecretoNorma { get; set; }
        public string? ArchivoDecretoNorma { get; set; }
        public string? Objetivo { get; set; }
        public string? EnteRector { get; set; }
        public int EstadoProgramacion { get; set; }
        public int Estado { get; set; }
        //
        public string? Periodo { get; set; }
    }
}
