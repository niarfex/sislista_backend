using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class EspecieListDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("CodigoEspecie")]
        public string? CodigoEspecie { get; set; }
        [JsonPropertyName("Especie")]
        public string? Especie { get; set; }
        [JsonPropertyName("DescripcionEspecie")]
        public string? DescripcionEspecie { get; set; }
        [JsonPropertyName("Estado")]
        public int Estado { get; set; }
    }
}
