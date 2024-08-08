using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class TrazabilidadCreateUpdateDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("Cuestionario")]
        public long? Cuestionario { get; set; }
        [JsonPropertyName("Observacion")]
        public string? Observacion { get; set; }
        [JsonPropertyName("EstadoResultado")]
        public long? EstadoResultado { get; set; }
        [JsonPropertyName("IdSeccion")]
        public long? IdSeccion { get; set; }
        [JsonPropertyName("Seccion")]
        public string? Seccion { get; set; }
        [JsonPropertyName("Perfil")]
        public string? Perfil { get; set; }
    }
}
