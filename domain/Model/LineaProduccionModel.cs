using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class LineaProduccionModel
    {
        public long Id { get; set; }
        public string? CodigoLineaProduccion { get; set; }
        public string? LineaProduccion { get; set; }
        public string? DescripcionLineaProduccion { get; set; }
        public int Estado { get; set; }
    }
}
