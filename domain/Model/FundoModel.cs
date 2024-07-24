using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class FundoModel
    {
        public long Id { get; set; }
        public long? IdCuestionario { get; set; }
        public string? Fundo { get; set; }
        public double? SuperficieTotal { get; set; }
        public double? SuperficieAgricola { get; set; }
        public string? IdUbigeo { get; set; }
        public string? Observacion { get; set; }
        public List<CampoModel> ListCampos { get; set; }
    }
}
