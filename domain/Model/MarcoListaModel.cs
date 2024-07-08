using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class MarcoListaModel
    {
        public long Id { get; set; }
        public long? IdPersona { get; set; }
        public long? IdTipoExplotacion { get; set; }
        public string? Direccion { get; set; }
        public string? IdDepartamento { get; set; }
        public int Estado { get; set; }
        //Para persona
        public long? IdTipoDocumento { get; set; }
        public long? IdCondicionJuridica { get; set; }
        public long? IdCondicionJuridicaOtros { get; set; }
        public string? IdUbigeo { get; set; }
        public long? IdAnio { get; set; }
        public string? CodigoUUIDPersona { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? RazonSocial { get; set; }
        public string? Celular { get; set; }
        public string? Telefono { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? PaginaWeb { get; set; }
        public string? DireccionFiscalDomicilio { get; set; }
        public string? NombreRepLegal { get; set; }
        public string? CorreoRepLegal { get; set; }
        public string? CelularRepLegal { get; set; }
        public string? TieneRuc { get; set; }
        //Lista
        public string? CondicionJuridica { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Departamento { get; set; }
    }
}
