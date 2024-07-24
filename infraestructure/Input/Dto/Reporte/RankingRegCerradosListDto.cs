using Infra.MarcoLista.Input.Dto;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Infra.MarcoLista.Input.Dto
{
    public class RankingRegCerradosListDto
    {
        [JsonPropertyName("Usuario")]
        public string? Usuario { get; set; }
        [JsonPropertyName("CantMarcoLista")]
        public long? CantMarcoLista { get; set; }
        [JsonPropertyName("Tiempo")]
        public string? Tiempo { get; set; }
        [JsonPropertyName("NumTiempo")]
        public long? NumTiempo { get; set; }
    }
}
