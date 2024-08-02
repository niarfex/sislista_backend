using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Model
{
    public class TrazabilidadModel
    {
        public long Id { get; set; }
        public long? Cuestionario { get; set; }
        public string? Observacion { get; set; }   
        public long? EstadoResultado { get; set; }
        public long? IdSeccion { get; set; }
        public string? Seccion { get; set; }
        public string? Perfil { get; set; }
    }
}
