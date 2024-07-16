using Infra.MarcoLista.Input.Dto;
using System.Text.Json.Serialization;

namespace Infra.MarcoLista.Input.Dto
{
    public class FileCuestionarioDto
    {
        [JsonPropertyName("formData")]
        public IFormFile formData { get; set; }
        [JsonPropertyName("Ruc")]
        public string? Ruc { get; set; }
        [JsonPropertyName("Periodo")]
        public string? Periodo { get; set; }
    }
}
