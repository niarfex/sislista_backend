using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ExportExcel
{
    public class CondicionJuridicaExcel
    {
        [Description("Código")]
        public string? CodigoCondicionJuridica { get; set; }
        [Description("Nombre")]
        public string? CondicionJuridica { get; set; }
        [Description("Descripción")]
        public string? DescripcionCondicionJuridica { get; set; }
        [Description("Estado")]
        public int Estado { get; set; }
    }
}
