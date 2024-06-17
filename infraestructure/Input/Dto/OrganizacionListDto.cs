using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class OrganizacionListDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("TipoOrganizacion")]
        public string? TipoOrganizacion { get; set; }
        [JsonPropertyName("NumeroDocumento")]
        public string? NumeroDocumento { get; set; }
        [JsonPropertyName("Organizacion")]
        public string? Organizacion { get; set; }
        [JsonPropertyName("Departamento")]
        public string? Departamento { get; set; }
        [JsonPropertyName("Usuarios")]
        public int Usuarios { get; set; }
        [JsonPropertyName("Estado")]
        public int Estado { get; set; }
    }
}
