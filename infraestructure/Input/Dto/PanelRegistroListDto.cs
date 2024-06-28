using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class PanelRegistroListDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("Periodo")]
        public string? Periodo { get; set; }
        [JsonPropertyName("ProgramacionRegistro")]
        public string? ProgramacionRegistro { get; set; }
        [JsonPropertyName("FechaInicio")]
        public DateTime? FechaInicio { get; set; }
        [JsonPropertyName("FechaFin")]
        public DateTime? FechaFin { get; set; }
        [JsonPropertyName("EstadoProgramacion")]
        public int EstadoProgramacion { get; set; }  

    }
}
