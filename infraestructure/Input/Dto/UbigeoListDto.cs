using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class UbigeoListDto
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }
        [JsonPropertyName("Departamento")]
        public string Departamento { get; set; }
        [JsonPropertyName("Provincia")]
        public string Provincia { get; set; }
        [JsonPropertyName("Distrito")]
        public string Distrito { get; set; }             
    }
}
