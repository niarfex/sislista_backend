using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ExportExcel
{
    public class OrganizacionExcel
    {
        [Description("Tipo de Organización")]
        public string? TipoOrganizacion { get; set; }
        [Description("RUC")]
        public string? NumeroDocumento { get; set; }
        [Description("Organización")]
        public string? Organizacion { get; set; }
        [Description("Departamento")]
        public string? Departamento { get; set; }
        [Description("Usuarios Vinculados")]
        public int Usuarios { get; set; }
        [Description("Estado")]
        public int Estado { get; set; }      
    }
}
