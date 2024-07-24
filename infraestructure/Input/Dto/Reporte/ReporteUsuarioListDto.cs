using Infra.MarcoLista.Input.Dto;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Infra.MarcoLista.Input.Dto
{
    public class ReporteUsuarioListDto
    {
        [JsonPropertyName("Usuario")]
        public string? Usuario { get; set; }
        [JsonPropertyName("Avance")]
        public double? Avance { get; set; }
        [JsonPropertyName("Cambio")]
        public double? Cambio { get; set; }
        [JsonPropertyName("CantMarcoLista")]
        public long? CantMarcoLista { get; set; }
        [JsonPropertyName("Perfil")]
        public string? Perfil { get; set; }
        [JsonPropertyName("RegCerrados")]
        public long? RegCerrados { get; set; }
    }
}
