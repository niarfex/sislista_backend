using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class GestionRegistroModel
    {
        public long Id { get; set; }
        public long? IdPPA { get; set; }
        public long? IdMarcoLista { get; set; }
        public long? IdCondicionJuridica { get; set; }
        public long? IdTipoDocumento { get; set; }
        public string? CodigoUUID { get; set; }
        public string? CodigoIdentificacion { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? RazonSocial { get; set; }
        public string? DireccionFiscalDomicilio { get; set; }
        public string? IdUbigeo { get; set; }
        public long? IdTipoExplotacion { get; set; }
        public string? TieneRuc { get; set; }
        public string? Telefono { get; set; }
        public string? Celular { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? PaginaWeb { get; set; }
        public string? NombreRepLegal { get; set; }
        public string? CorreoRepLegal { get; set; }
        public string? CelularRepLegal { get; set; }
        public string? CantidadFundo { get; set; }
        public int Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? UsuarioCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string? UsuarioActualizacion { get; set; }
        //

        public List<FundoModel> ListFundos { get; set; }
        public List<PecuarioModel> ListPecuarios { get; set; }
        public List<ArchivoModel> ListArchivos { get; set; }
        public List<InformanteModel> ListInformantes { get; set; }
        public List<TrazabilidadModel> ListObservaciones { get; set; }

        //Listado
        public long? IdPeriodo { get; set; }
        public string? Periodo { get; set; }
        public string? NombreCompleto { get; set; }
        public string? TipoExplotacion { get; set; }
        public string? Clasificacion { get; set; }
        public string? CodigoEstadoEntrevista { get; set; }
        public string? CodigoEstadoSupervision { get; set; }
        public string? CodigoEstadoValidacion { get; set; }
        public string? CodigoEstadoRegistro { get; set; }
        public string? NombreEstadoEntrevista { get; set; }
        public string? NombreEstadoSupervision { get; set; }
        public string? NombreEstadoValidacion { get; set; }
        public string? NombreEstadoRegistro { get; set; }
    }
}
