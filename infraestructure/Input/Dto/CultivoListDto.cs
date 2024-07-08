using System.Text.Json.Serialization;

namespace Infra.MarcoLista.Input.Dto
{
    public class CultivoListDto
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }
        [JsonPropertyName("Cultivo")]
        public string Cultivo { get; set; }       
    }
}
