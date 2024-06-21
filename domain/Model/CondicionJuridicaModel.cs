using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class CondicionJuridicaModel
    {
        public long Id { get; set; }
        public string? CodigoCondicionJuridica { get; set; }
        public string? CondicionJuridica { get; set; }
        public string? DescripcionCondicionJuridica { get; set; }
        public int Otros { get; set; }
        public int Estado { get; set; }
    }
}
