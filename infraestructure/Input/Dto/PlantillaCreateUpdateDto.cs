using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class PlantillaCreateUpdateDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("Plantilla")]
        public string? Plantilla { get; set; }
        [JsonPropertyName("Descripcion")]
        public string? Descripcion { get; set; }
        [JsonPropertyName("NumCuestionario")]
        public long NumCuestionario { get; set; }
    }
}
