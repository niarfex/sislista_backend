using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class UsoNoAgricolaModel
    {
        public long Id { get; set; }
        public string? UsoNoAgricola { get; set; }
    }
}
