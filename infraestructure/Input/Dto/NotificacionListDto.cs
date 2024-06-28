using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class NotificacionListDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("Asunto")]
        public string? Asunto { get; set; }
        [JsonPropertyName("Frecuencia")]
        public string? Frecuencia { get; set; }
        [JsonPropertyName("UsuariosNotificados")]
        public string? UsuariosNotificados { get; set; }
        [JsonPropertyName("FechaRegistro")]
        public DateTime? FechaRegistro { get; set; }
        [JsonPropertyName("FechaNotificacion")]
        public DateTime? FechaNotificacion { get; set; }
        [JsonPropertyName("EstadoNotificacion")]
        public int EstadoNotificacion { get; set; }   
    }
}
