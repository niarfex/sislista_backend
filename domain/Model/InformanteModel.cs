using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class InformanteModel
    {
        public long Id { get; set; }
        public long? IdCuestionario { get; set; }
        public long? IdPersona { get; set; }
        public string? CodigoUUIDPersona { get; set; }        
        public long IdEstado { get; set; }
        public string? Observacion { get; set; }
        public string? Direccion { get; set; }
        public string? CoordenadaEste { get; set; }
        public string? CoordenadaNorte { get; set; }
        public string? SistemaCoordenada { get; set; }
        // para listado
        public string? NombreCompleto { get; set; }
        public long? IdTipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Cargo { get; set; }
        public string? Correo { get; set; }
        public string? Celular { get; set; }
        public string? Telefono { get; set; }
        public string? EstadoEntrevista { get; set; }
    }
}
