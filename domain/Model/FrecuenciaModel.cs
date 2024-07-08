using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class FrecuenciaModel
    {
        public long Id { get; set; }
        public string? Frecuencia { get; set; }      
    }
}
