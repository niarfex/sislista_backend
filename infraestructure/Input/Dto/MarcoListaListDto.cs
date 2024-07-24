using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class MarcoListaListDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("NumeroDocumento")]
        public string? NumeroDocumento { get; set; }
        [JsonPropertyName("NombreCompleto")]
        public string? NombreCompleto { get; set; }
        [JsonPropertyName("CondicionJuridica")]
        public string? CondicionJuridica { get; set; }
        [JsonPropertyName("NombreRepLegal")]
        public string? NombreRepLegal { get; set; }
        [JsonPropertyName("IdDepartamento")]
        public string? IdDepartamento { get; set; }
        [JsonPropertyName("Departamento")]
        public string? Departamento { get; set; }
        [JsonPropertyName("Estado")]
        public int Estado { get; set; }
        [JsonPropertyName("IdUbigeo")]
        public string? IdUbigeo { get; set; }
    }
}
