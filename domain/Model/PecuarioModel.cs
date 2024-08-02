using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class PecuarioModel
    {
        public long Id { get; set; }
        public long? IdFundo { get; set; }
        public long? IdCampo { get; set; }       

        public long? IdSistemaPecuario { get; set; }
        public long? IdLineaProduccion { get; set; }
        public long? IdEspecie { get; set; }
        public int Cantidad { get; set; }
        public string? Campo { get; set; }
        public int OrdenFundo { get; set; }
        public int OrdenCampo { get; set; }
        public string? SistemaPecuario { get; set; }
        public string? Animal { get; set; }
    }
}
