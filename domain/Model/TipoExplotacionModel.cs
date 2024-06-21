using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class TipoExplotacionModel
    {
        public long Id { get; set; }
        public string? CodigoTipoExplotacion { get; set; }
        public string? TipoExplotacion { get; set; }
        public string? DescripcionTipoExplotacion { get; set; }
        public int Estado { get; set; }
    }
}
