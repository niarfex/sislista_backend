using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class CampoModel
    {
        public long Id { get; set; }
        public long? IdFundo { get; set; }
        public string? Campo { get; set; }
        public long? IdTenencia { get; set; }
        public long? IdUsoTierra { get; set; }
        public long? IdCultivo { get; set; }
        public string? IdUsoNoAgricola { get; set; }
        public string? Observacion { get; set; }
        public int? Orden { get; set; }
        public double? Superficie { get; set; }
        public double? SuperficieCultivada { get; set; }
    }
}
