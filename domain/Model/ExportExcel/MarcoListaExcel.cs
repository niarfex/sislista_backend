using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ExportExcel
{
    public class MarcoListaExcel
    {
        [Description("Código")]
        public long Id { get; set; }
        [Description("Número Doc.")]
        public string? NumeroDocumento { get; set; }
        [Description("Razón social/Nombre completo")]
        public string? NombreCompleto { get; set; }
        [Description("Condición jurídica")]
        public string? CondicionJuridica { get; set; }
        [Description("Representante legal")]
        public string? NombreRepLegal { get; set; }
        [Description("Estado")]
        public int Estado { get; set; }

       
    }
}
