using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class MarcoListaGetDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("IdTipoExplotacion")]
        public long? IdTipoExplotacion { get; set; }
        [JsonPropertyName("Direccion")]
        public string? Direccion { get; set; }
        [JsonPropertyName("IdDepartamento")]
        public string? IdDepartamento { get; set; }

        [JsonPropertyName("IdTipoDocumento")]
        public long? IdTipoDocumento { get; set; }
        [JsonPropertyName("IdCondicionJuridica")]
        public long? IdCondicionJuridica { get; set; }
        [JsonPropertyName("IdCondicionJuridicaOtros")]
        public long? IdCondicionJuridicaOtros { get; set; }
        [JsonPropertyName("IdAnio")]
        public long? IdAnio { get; set; }
        [JsonPropertyName("IdUbigeo")]
        public string? IdUbigeo { get; set; }
        [JsonPropertyName("CodigoUUIDPersona")]
        public string? CodigoUUIDPersona { get; set; }
        [JsonPropertyName("NumeroDocumento")]
        public string? NumeroDocumento { get; set; }
        [JsonPropertyName("Nombre")]
        public string? Nombre { get; set; }
        [JsonPropertyName("ApellidoPaterno")]
        public string? ApellidoPaterno { get; set; }
        [JsonPropertyName("ApellidoMaterno")]
        public string? ApellidoMaterno { get; set; }
        [JsonPropertyName("RazonSocial")]
        public string? RazonSocial { get; set; }
        [JsonPropertyName("Celular")]
        public string? Celular { get; set; }
        [JsonPropertyName("Telefono")]
        public string? Telefono { get; set; }
        [JsonPropertyName("CorreoElectronico")]
        public string? CorreoElectronico { get; set; }
        [JsonPropertyName("PaginaWeb")]
        public string? PaginaWeb { get; set; }
        [JsonPropertyName("DireccionFiscalDomicilio")]
        public string? DireccionFiscalDomicilio { get; set; }
        [JsonPropertyName("NombreRepLegal")]
        public string? NombreRepLegal { get; set; }
        [JsonPropertyName("CorreoRepLegal")]
        public string? CorreoRepLegal { get; set; }
        [JsonPropertyName("CelularRepLegal")]
        public string? CelularRepLegal { get; set; }
        [JsonPropertyName("TieneRuc")]
        public string? TieneRuc { get; set; }

        [JsonPropertyName("ListCondicionJuridica")]
        public List<SelectTipoDto> ListCondicionJuridica { get; set; }
        [JsonPropertyName("ListCondicionJuridicaOtros")]
        public List<SelectTipoDto> ListCondicionJuridicaOtros { get; set; }
        [JsonPropertyName("ListTipoDocumento")]
        public List<SelectTipoDto> ListTipoDocumento { get; set; }
        [JsonPropertyName("ListDepartamento")]
        public List<SelectTipoDto> ListDepartamento { get; set; }
        [JsonPropertyName("ListProvincia")]
        public List<SelectTipoDto> ListProvincia { get; set; }
        [JsonPropertyName("ListDistrito")]
        public List<SelectTipoDto> ListDistrito { get; set; }
        [JsonPropertyName("ListTipoExplotacion")]
        public List<SelectTipoDto> ListTipoExplotacion { get; set; }
        [JsonPropertyName("ListPeriodos")]
        public List<SelectTipoDto> ListPeriodos { get; set; }
    }
}
