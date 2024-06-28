using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class LoginModel
    {
        [JsonPropertyName("CodigoUUID")]
        public string CodigoUUID { get; set; }
        [JsonPropertyName("Usuario")]
        public string Usuario { get; set; }
        [JsonPropertyName("NumeroDocumento")]
        public string NumeroDocumento { get; set; }
        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("ApellidoPaterno")]
        public string ApellidoPaterno { get; set; }
        [JsonPropertyName("ApellidoMaterno")]
        public string ApellidoMaterno { get; set; }
        [JsonPropertyName("IdPerfil")]
        public long IdPerfil { get; set; }
        [JsonPropertyName("CodigoPerfil")]
        public string CodigoPerfil { get; set; }
        [JsonPropertyName("Perfil")]
        public string Perfil { get; set; }
        [JsonPropertyName("AccessToken")]
        public string AccessToken { get; set; }
    }
}
