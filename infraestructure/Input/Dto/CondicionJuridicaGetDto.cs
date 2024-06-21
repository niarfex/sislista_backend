using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class CondicionJuridicaGetDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("CodigoCondicionJuridica")]
        public string? CodigoCondicionJuridica { get; set; }
        [JsonPropertyName("CondicionJuridica")]
        public string? CondicionJuridica { get; set; }
        [JsonPropertyName("DescripcionCondicionJuridica")]
        public string? DescripcionCondicionJuridica { get; set; }
        [JsonPropertyName("Otros")]
        public int Otros { get; set; }
    }
}
