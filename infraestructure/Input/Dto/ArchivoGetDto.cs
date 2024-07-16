using Infra.MarcoLista.Input.Dto;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Infra.MarcoLista.Input.Dto
{
    public class ArchivoGetDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("NombreArchivo")]
        public string? NombreArchivo { get; set; }
        [JsonPropertyName("Archivo")]
        public string? Archivo { get; set; }
        [JsonPropertyName("DescripcionArchivo")]
        public string? DescripcionArchivo { get; set; }
        [JsonPropertyName("CuestionarioPrincipal")]
        public int? CuestionarioPrincipal { get; set; }
        [JsonPropertyName("IdTipoInformacion")]
        public long? IdTipoInformacion { get; set; }
        [JsonPropertyName("Peso")]
        public long? Peso { get; set; }
        [JsonPropertyName("TipoInformacion")]
        public string? TipoInformacion { get; set; }
    }
}
