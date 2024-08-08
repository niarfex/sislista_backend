using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class PecuarioGetDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("IdCampo")]
        public long? IdCampo { get; set; }
        [JsonPropertyName("IdSistemaPecuario")]
        public long? IdSistemaPecuario { get; set; }
        [JsonPropertyName("IdLineaProduccion")]
        public long? IdLineaProduccion { get; set; }
        [JsonPropertyName("IdEspecie")]
        public long? IdEspecie { get; set; }
        [JsonPropertyName("Cantidad")]
        public int Cantidad { get; set; }
        [JsonPropertyName("OrdenFundo")]
        public int OrdenFundo { get; set; }
        [JsonPropertyName("OrdenCampo")]
        public int OrdenCampo { get; set; }
        [JsonPropertyName("Campo")]
        public string? Campo { get; set; }
        [JsonPropertyName("SistemaPecuario")]
        public string? SistemaPecuario { get; set; }
        [JsonPropertyName("Animal")]
        public string? Animal { get; set; }
    }
}
