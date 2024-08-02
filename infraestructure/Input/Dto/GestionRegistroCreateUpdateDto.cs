using Infra.MarcoLista.Input.Dto;
using System.Text.Json.Serialization;

namespace Infra.MarcoLista.Input.Dto
{
    public class GestionRegistroCreateUpdateDto
    {
        [JsonPropertyName("CodigoUUID")]
        public string? CodigoUUID { get; set; }
        [JsonPropertyName("IdPPA")]
        public long? IdPPA { get; set; }
        [JsonPropertyName("IdMarcoLista")]
        public long? IdMarcoLista { get; set; }
        [JsonPropertyName("IdCondicionJuridica")]
        public long? IdCondicionJuridica { get; set; }
        [JsonPropertyName("IdCondicionJuridicaOtros")]
        public long? IdCondicionJuridicaOtros { get; set; }
        [JsonPropertyName("IdTipoDocumento")]
        public long? IdTipoDocumento { get; set; }
        [JsonPropertyName("CodigoIdentificacion")]
        public string? CodigoIdentificacion { get; set; }
        [JsonPropertyName("NumeroDocumento")]
        public string? NumeroDocumento { get; set; }
        [JsonPropertyName("Nombre")]
        public string? Nombre { get; set; }
        [JsonPropertyName("ApellidoPaterno")]
        public string? ApellidoPaterno { get; set; }
        [JsonPropertyName("ApellidoMaterno")]
        public string? ApellidoMaterno { get; set; }
        [JsonPropertyName("RazonSocial")]
        public string? RazonSocial { get; set; }
        [JsonPropertyName("DireccionFiscalDomicilio")]
        public string? DireccionFiscalDomicilio { get; set; }
        [JsonPropertyName("IdUbigeo")]
        public string? IdUbigeo { get; set; }
        [JsonPropertyName("IdTipoExplotacion")]
        public long? IdTipoExplotacion { get; set; }
        [JsonPropertyName("TieneRuc")]
        public string? TieneRuc { get; set; }
        [JsonPropertyName("Telefono")]
        public string? Telefono { get; set; }
        [JsonPropertyName("Celular")]
        public string? Celular { get; set; }
        [JsonPropertyName("CorreoElectronico")]
        public string? CorreoElectronico { get; set; }
        [JsonPropertyName("PaginaWeb")]
        public string? PaginaWeb { get; set; }
        [JsonPropertyName("NombreRepLegal")]
        public string? NombreRepLegal { get; set; }
        [JsonPropertyName("CorreoRepLegal")]
        public string? CorreoRepLegal { get; set; }
        [JsonPropertyName("CelularRepLegal")]
        public string? CelularRepLegal { get; set; }
        [JsonPropertyName("CantidadFundo")]
        public string? CantidadFundo { get; set; }
        [JsonPropertyName("EstadoEntrevista")]
        public int? EstadoEntrevista { get; set; }
        [JsonPropertyName("IdPeriodo")]
        public long? IdPeriodo { get; set; }

        [JsonPropertyName("ListFundos")]
        public List<FundoCreateUpdateDto> ListFundos { get; set; }
        [JsonPropertyName("ListPecuarios")]
        public List<PecuarioCreateUpdateDto> ListPecuarios { get; set; }
        [JsonPropertyName("ListArchivos")]
        public List<ArchivoCreateUpdateDto> ListArchivos { get; set; }
        [JsonPropertyName("ListInformantes")]
        public List<InformanteGetDto> ListInformantes { get; set; }       
        [JsonPropertyName("ListObservaciones")]
        public List<TrazabilidadCreateUpdateDto> ListObservaciones { get; set; }
        
    }
}
