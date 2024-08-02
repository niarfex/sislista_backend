using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class UsuarioModel
    {
        public long Id { get; set; }
        public long IdPersona { get; set; }
        public string CodigoUUIDUsuario { get; set; }
        public string? Usuario { get; set; }
        public string? Clave { get; set; }
        public string? TokenReseteoClave { get; set; }
        public DateTime? FechaTokenReseteoExpiracion { get; set; }
        public int Estado { get; set; }
        //Perfil y persona
        public long IdPerfil { get; set; }
        public long? IdTipoDocumento { get; set; }
        public string CodigoUUIDPersona { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Celular { get; set; }
        public string? CorreoElectronico { get; set; }
        public long? IdOrganizacion { get; set; }
        public string? Cargo { get; set; }
        public string? OficinaArea { get; set; }
        //Lista
        public string? Perfil{ get; set; }
        public string NombreCompleto { get; set; }
        public List<MarcoListaModel> ListMarcoListaAsignados { get; set; }
    }
}
