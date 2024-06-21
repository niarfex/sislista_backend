using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class OrganizacionModel
    {
        public long Id { get; set; }
        public long? IdTipoOrganizacion { get; set; }
        public string? IdDepartamento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Organizacion { get; set; }
        public string? DireccionFiscal { get; set; }
        public string? Telefono { get; set; }
        public string? PaginaWeb { get; set; }
        public string? CorreoElectronico { get; set; }        
        //Para el listado
        public string? TipoOrganizacion { get; set; }
        public string? Departamento { get; set; }
        public int Usuarios { get; set; }
        public int Estado { get; set; }



    }
}
