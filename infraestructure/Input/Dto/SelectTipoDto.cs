using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class SelectTipoDto
    {
        [JsonPropertyName("label")]
        public string label { get; set; }
        [JsonPropertyName("value")]
        public string value { get; set; }
        [JsonPropertyName("codigo")]
        public string? codigo { get; set; }
    }
}
