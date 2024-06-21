using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class UsuarioListDto
    {
        [JsonPropertyName("CodigoUUIDUsuario")]
        public string CodigoUUIDUsuario { get; set; }
        [JsonPropertyName("Perfil")]
        public string? Perfil { get; set; }
        [JsonPropertyName("NumeroDocumento")]
        public string? NumeroDocumento { get; set; }
        [JsonPropertyName("NombreCompleto")]
        public string? NombreCompleto { get; set; }
        [JsonPropertyName("CorreoElectronico")]
        public string? CorreoElectronico { get; set; }
        [JsonPropertyName("Estado")]
        public int Estado { get; set; }
    }
}
