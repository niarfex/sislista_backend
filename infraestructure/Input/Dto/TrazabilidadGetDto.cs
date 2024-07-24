using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class TrazabilidadGetDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("Cuestionario")]
        public long? Cuestionario { get; set; }
        [JsonPropertyName("Observacion")]
        public string? Observacion { get; set; }
        [JsonPropertyName("EstadoResultado")]
        public long? EstadoResultado { get; set; }
        [JsonPropertyName("Seccion")]
        public long? Seccion { get; set; }
        [JsonPropertyName("TipoSeccion")]
        public string? TipoSeccion { get; set; }
        [JsonPropertyName("Perfil")]
        public string? Perfil { get; set; }
    }
}
