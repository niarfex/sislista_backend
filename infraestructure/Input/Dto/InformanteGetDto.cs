using System.Text.Json.Serialization;

namespace Infra.MarcoLista.Input.Dto
{
    public class InformanteGetDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("CodigoUUIDPersona")]
        public string? CodigoUUIDPersona { get; set; }
        [JsonPropertyName("IdEstado")]
        public long IdEstado { get; set; }
        [JsonPropertyName("Observacion")]
        public string? Observacion { get; set; }
        [JsonPropertyName("Direccion")]
        public string? Direccion { get; set; }
        [JsonPropertyName("CoordenadaEste")]
        public string? CoordenadaEste { get; set; }
        [JsonPropertyName("CoordenadaNorte")]
        public string? CoordenadaNorte { get; set; }
        [JsonPropertyName("SistemaCoordenada")]
        public string? SistemaCoordenada { get; set; }
        [JsonPropertyName("NombreCompleto")]
        public string? NombreCompleto { get; set; }
        [JsonPropertyName("IdTipoDocumento")]
        public long? IdTipoDocumento { get; set; }
        [JsonPropertyName("NumeroDocumento")]
        public string? NumeroDocumento { get; set; }
        [JsonPropertyName("Nombre")]
        public string? Nombre { get; set; }
        [JsonPropertyName("ApellidoPaterno")]
        public string? ApellidoPaterno { get; set; }
        [JsonPropertyName("ApellidoMaterno")]
        public string? ApellidoMaterno { get; set; }
        [JsonPropertyName("Cargo")]
        public string? Cargo { get; set; }
        [JsonPropertyName("Correo")]
        public string? Correo { get; set; }
        [JsonPropertyName("Celular")]
        public string? Celular { get; set; }
        [JsonPropertyName("Telefono")]
        public string? Telefono { get; set; }
        [JsonPropertyName("EstadoEntrevista")]
        public string? EstadoEntrevista { get; set; }
    }
}
