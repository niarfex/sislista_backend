using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel;

namespace Domain.Model
{
    public class UbigeoFiltro
    {
        [Description("P_TIPO_UBIGEO")]
        public int TipoUbigeo { get; set; }

        [Description("P_IDE_UBIGEO")]
        public string IdUbigeo { get; set; }
    }
}
