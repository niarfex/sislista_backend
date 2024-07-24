using Infra.MarcoLista.Input.Dto;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Infra.MarcoLista.Input.Dto
{
    public class FlujoValidacionListDto
    {
        [JsonPropertyName("Empresa")]
        public string? Empresa { get; set; }
        [JsonPropertyName("Tiempo")]
        public string? Tiempo { get; set; }
        [JsonPropertyName("NumTiempo")]
        public long? NumTiempo { get; set; }
    }
}
