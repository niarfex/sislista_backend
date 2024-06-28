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
    public class UbigeoModel
    {        
        public string Id { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }


        public UbigeoModel(string id, string departamento, string provincia, string distrito) {
            Id = id;
            Departamento = departamento;
            Provincia = provincia;
            Distrito = distrito;
        }
        public UbigeoModel()
        {
            Id = "";
            Departamento = "";
            Provincia = "";
            Distrito = "";
        }
    }
}
