using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class PlantillaListDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("Plantilla")]
        public string? Plantilla { get; set; }
        [JsonPropertyName("Estado")]
        public int Estado { get; set; }
        [JsonPropertyName("FechaRegistro")]
        public DateTime? FechaRegistro { get; set; }
        [JsonPropertyName("UsuarioCreacion")]
        public string? UsuarioCreacion { get; set; }
        [JsonPropertyName("FechaActualizacion")]
        public DateTime? FechaActualizacion { get; set; }
        [JsonPropertyName("UsuarioActualizacion")]
        public string? UsuarioActualizacion { get; set; }
    }
}
