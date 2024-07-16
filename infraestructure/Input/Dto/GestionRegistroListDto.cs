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
        [JsonPropertyName("CodigoEstadoEntrevista")]
        public string? CodigoEstadoEntrevista { get; set; }
        [JsonPropertyName("CodigoEstadoSupervision")]
        public string? CodigoEstadoSupervision { get; set; }
        [JsonPropertyName("CodigoEstadoValidacion")]
        public string? CodigoEstadoValidacion { get; set; }
        [JsonPropertyName("CodigoEstadoRegistro")]
        public string? CodigoEstadoRegistro { get; set; }
        [JsonPropertyName("NombreEstadoEntrevista")]
        public string? NombreEstadoEntrevista { get; set; }
        [JsonPropertyName("NombreEstadoSupervision")]
        public string? NombreEstadoSupervision { get; set; }
        [JsonPropertyName("NombreEstadoValidacion")]
        public string? NombreEstadoValidacion { get; set; }
        [JsonPropertyName("NombreEstadoRegistro")]
        public string? NombreEstadoRegistro { get; set; }
    }
}
