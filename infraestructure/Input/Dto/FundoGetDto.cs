using Infra.MarcoLista.Input.Dto;
using System.Text.Json.Serialization;

namespace Infra.MarcoLista.Input.Dto
{
    public class FundoGetDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("IdCuestionario")]
        public long? IdCuestionario { get; set; }
        [JsonPropertyName("Fundo")]
        public string? Fundo { get; set; }
        [JsonPropertyName("SuperficieTotal")]
        public long? SuperficieTotal { get; set; }
        [JsonPropertyName("SuperficieAgricola")]
        public long? SuperficieAgricola { get; set; }
        [JsonPropertyName("IdUbigeo")]
        public string? IdUbigeo { get; set; }
        [JsonPropertyName("Observacion")]
        public string? Observacion { get; set; }
        [JsonPropertyName("ListCampos")]
        public List<CampoGetDto> ListCampos { get; set; }

    }
}
