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
    public class SelectTipoModel
    {
        public string label { get; set; }
        public string value { get; set; }
        public string? codigo { get; set; }
        public SelectTipoModel(string _label, string _value, string _codigo)
        {
            label = _label;
            value = _value;
            codigo = _codigo;
        }
        public SelectTipoModel()
        {
            label = "";
            value = "";
            codigo = "";
        }
    }
}
