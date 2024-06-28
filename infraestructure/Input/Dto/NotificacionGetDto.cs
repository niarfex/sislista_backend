using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class NotificacionGetDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("Asunto")]
        public string? Asunto { get; set; }
        [JsonPropertyName("IdFrecuencia")]
        public long? IdFrecuencia { get; set; }
        [JsonPropertyName("IdProgramacionRegistro")]
        public long? IdProgramacionRegistro { get; set; }
        [JsonPropertyName("IdEtapa")]
        public long? IdEtapa { get; set; }
        [JsonPropertyName("Descripcion")]
        public string? Descripcion { get; set; }
        [JsonPropertyName("IdPerfil")]
        public long? IdPerfil { get; set; }
        [JsonPropertyName("ListFrecuencias")]
        public List<SelectTipoDto> ListFrecuencias { get; set; }
        [JsonPropertyName("ListProgramacionesVigentes")]
        public List<SelectTipoDto> ListProgramacionesVigentes { get; set; }
        [JsonPropertyName("ListEtapas")]
        public List<SelectTipoDto> ListEtapas { get; set; }
        [JsonPropertyName("ListPerfiles")]
        public List<SelectTipoDto> ListPerfiles { get; set; }
    }
}
