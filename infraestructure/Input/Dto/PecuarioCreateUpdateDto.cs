using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class PecuarioCreateUpdateDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("IdFundo")]
        public long? IdFundo { get; set; }
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
        [JsonPropertyName("SistemaPecuario")]
        public string? SistemaPecuario { get; set; }

    }
}
