using Infra.MarcoLista.Input.Dto;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Infra.MarcoLista.Input.Dto
{
    public class CampoGetDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("IdFundo")]
        public long? IdFundo { get; set; }
        [JsonPropertyName("Campo")]
        public string? Campo { get; set; }
        [JsonPropertyName("IdTenencia")]
        public long? IdTenencia { get; set; }
        [JsonPropertyName("IdUsoTierra")]
        public long? IdUsoTierra { get; set; }
        [JsonPropertyName("IdCultivo")]
        public long? IdCultivo { get; set; }
        [JsonPropertyName("IdUsoNoAgricola")]
        public long? IdUsoNoAgricola { get; set; }
        [JsonPropertyName("Observacion")]
        public string? Observacion { get; set; }
        [JsonPropertyName("Superficie")]
        public long? Superficie { get; set; }
        [JsonPropertyName("SuperficieCultivada")]
        public long? SuperficieCultivada { get; set; }

    }
}
