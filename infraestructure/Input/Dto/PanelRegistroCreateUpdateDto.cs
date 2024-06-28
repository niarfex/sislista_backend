using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class PanelRegistroCreateUpdateDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("IdPlantilla")]
        public long? IdPlantilla { get; set; }      
        [JsonPropertyName("IdAnio")]
        public long? IdAnio { get; set; }
        [JsonPropertyName("ProgramacionRegistro")]
        public string? ProgramacionRegistro { get; set; }
        [JsonPropertyName("FechaInicio")]
        public DateTime? FechaInicio { get; set; }
        [JsonPropertyName("FechaFin")]
        public DateTime? FechaFin { get; set; }
        [JsonPropertyName("DecretoNorma")]
        public string? DecretoNorma { get; set; }
        [JsonPropertyName("ArchivoDecretoNorma")]
        public string? ArchivoDecretoNorma { get; set; }
        [JsonPropertyName("Objetivo")]
        public string? Objetivo { get; set; }
        [JsonPropertyName("EnteRector")]
        public string? EnteRector { get; set; }   
    }
}
