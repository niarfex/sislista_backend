using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class OrganizacionCreateUpdateDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("IdTipoOrganizacion")]
        public long? IdTipoOrganizacion { get; set; }
        [JsonPropertyName("IdDepartamento")]
        public string? IdDepartamento { get; set; }
        [JsonPropertyName("NumeroDocumento")]
        public string? NumeroDocumento { get; set; }
        [JsonPropertyName("Organizacion")]
        public string? Organizacion { get; set; }
        [JsonPropertyName("DireccionFiscal")]
        public string? DireccionFiscal { get; set; }
        [JsonPropertyName("Telefono")]
        public string? Telefono { get; set; }
        [JsonPropertyName("PaginaWeb")]
        public string? PaginaWeb { get; set; }
        [JsonPropertyName("CorreoElectronico")]
        public string? CorreoElectronico { get; set; }

    }
}
