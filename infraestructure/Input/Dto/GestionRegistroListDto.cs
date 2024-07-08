using System.Text.Json.Serialization;

namespace Infra.MarcoLista.Input.Dto
{
    public class GestionRegistroListDto
    {
        [JsonPropertyName("IdMarcoLista")]
        public long? IdMarcoLista { get; set; }
        [JsonPropertyName("CodigoUUID")]
        public string? CodigoUUID { get; set; }
        [JsonPropertyName("NumeroDocumento")]
        public string? NumeroDocumento { get; set; }
        [JsonPropertyName("FechaRegistro")]
        public DateTime? FechaRegistro { get; set; }
        [JsonPropertyName("UsuarioCreacion")]
        public string? UsuarioCreacion { get; set; }
        [JsonPropertyName("FechaActualizacion")]
        public DateTime? FechaActualizacion { get; set; }
        [JsonPropertyName("UsuarioActualizacion")]
        public string? UsuarioActualizacion { get; set; }

        //Listado
        [JsonPropertyName("IdPeriodo")]
        public long? IdPeriodo { get; set; }
        [JsonPropertyName("Periodo")]
        public string? Periodo { get; set; }
        [JsonPropertyName("NombreCompleto")]
        public string? NombreCompleto { get; set; }
        [JsonPropertyName("TipoExplotacion")]
        public string? TipoExplotacion { get; set; }
        [JsonPropertyName("Clasificacion")]
        public string? Clasificacion { get; set; }
        [JsonPropertyName("EstadoEntrevista")]
        public int? EstadoEntrevista { get; set; }
        [JsonPropertyName("EstadoSupervision")]
        public int? EstadoSupervision { get; set; }
        [JsonPropertyName("EstadoValidacion")]
        public int? EstadoValidacion { get; set; }
        [JsonPropertyName("EstadoRegistro")]
        public int? EstadoRegistro { get; set; }
    }
}
