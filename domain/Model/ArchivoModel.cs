using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ArchivoModel
    {
        public long Id { get; set; }
        public long IdCuestionario { get; set; }
        public string? NombreArchivo { get; set; }
        public string? Archivo { get; set; }
        public string? DescripcionArchivo { get; set; }
        public int? CuestionarioPrincipal { get; set; }
        public int Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? UsuarioCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string? UsuarioActualizacion { get; set; }
        public long? IdTipoInformacion { get; set; }
        public double? Peso { get; set; }
        public string? TipoInformacion { get; set; }
    }
}
