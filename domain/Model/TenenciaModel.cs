using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class TenenciaModel
    {
        public long Id { get; set; }
        public string? Tenencia { get; set; }
    }
}
