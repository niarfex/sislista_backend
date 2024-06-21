using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class TipoDocumentoModel
    {
        public long Id { get; set; }
        public string TipoDocumento { get; set; }
    }
}
