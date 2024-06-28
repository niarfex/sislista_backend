using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class UsuarioGetDto
    {
        [JsonPropertyName("CodigoUUIDUsuario")]
        public string CodigoUUIDUsuario { get; set; }
        [JsonPropertyName("IdPerfil")]
        public long IdPerfil { get; set; }
        [JsonPropertyName("IdTipoDocumento")]
        public long? IdTipoDocumento { get; set; }
        [JsonPropertyName("CodigoUUIDPersona")]
        public string CodigoUUIDPersona { get; set; }
        [JsonPropertyName("NumeroDocumento")]
        public string? NumeroDocumento { get; set; }
        [JsonPropertyName("Nombre")]
        public string? Nombre { get; set; }
        [JsonPropertyName("ApellidoPaterno")]
        public string? ApellidoPaterno { get; set; }
        [JsonPropertyName("ApellidoMaterno")]
        public string? ApellidoMaterno { get; set; }
        [JsonPropertyName("Celular")]
        public string? Celular { get; set; }
        [JsonPropertyName("CorreoElectronico")]
        public string? CorreoElectronico { get; set; }
        [JsonPropertyName("IdOrganizacion")]
        public long? IdOrganizacion { get; set; }
        [JsonPropertyName("Cargo")]
        public string? Cargo { get; set; }
        [JsonPropertyName("OficinaArea")]
        public string? OficinaArea { get; set; }
        [JsonPropertyName("ListTipoDocumento")]
        public List<SelectTipoDto> ListTipoDocumento { get; set; }
        [JsonPropertyName("ListPerfil")]
        public List<SelectTipoDto> ListPerfil { get; set; }
        [JsonPropertyName("ListOrganizacion")]
        public List<SelectTipoDto> ListOrganizacion { get; set; }
        [JsonPropertyName("ListDepartamento")]
        public List<SelectTipoDto> ListDepartamento { get; set; }
        [JsonPropertyName("ListMarcoListaAsignados")]
        public List<MarcoListaListDto> ListMarcoListaAsignados { get; set; }
    }
}
