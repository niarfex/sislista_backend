using Infra.MarcoLista.Input.Dto;
using System.Text.Json.Serialization;

namespace Infra.MarcoLista.Input.Dto
{
    public class FundoCreateUpdateDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("IdCuestionario")]
        public long? IdCuestionario { get; set; }
        [JsonPropertyName("Fundo")]
        public string? Fundo { get; set; }
        [JsonPropertyName("SuperficieTotal")]
        public double? SuperficieTotal { get; set; }
        [JsonPropertyName("SuperficieAgricola")]
        public double? SuperficieAgricola { get; set; }
        [JsonPropertyName("IdUbigeo")]
        public string? IdUbigeo { get; set; }
        [JsonPropertyName("Observacion")]
        public string? Observacion { get; set; }
        [JsonPropertyName("Orden")]
        public int? Orden { get; set; }       
        [JsonPropertyName("ListCampos")]
        public List<CampoGetDto> ListCampos { get; set; }
    }
}