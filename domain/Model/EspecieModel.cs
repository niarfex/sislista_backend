using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class EspecieModel
    {
        public long Id { get; set; }
        public string? CodigoEspecie { get; set; }
        public string? Especie { get; set; }
        public string? DescripcionEspecie { get; set; }
        public int Estado { get; set; }
    }
}
