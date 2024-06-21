using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class LineaProduccionCreateUpdateDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("CodigoLineaProduccion")]
        public string? CodigoLineaProduccion { get; set; }
        [JsonPropertyName("LineaProduccion")]
        public string? LineaProduccion { get; set; }
        [JsonPropertyName("DescripcionLineaProduccion")]
        public string? DescripcionLineaProduccion { get; set; }
    }
}
