using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class TipoExplotacionGetDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("CodigoTipoExplotacion")]
        public string? CodigoTipoExplotacion { get; set; }
        [JsonPropertyName("TipoExplotacion")]
        public string? TipoExplotacion { get; set; }
        [JsonPropertyName("DescripcionTipoExplotacion")]
        public string? DescripcionTipoExplotacion { get; set; }      
    }
}
