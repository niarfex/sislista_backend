using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ProductorAgrario
    {
        public long Id { get; set; }
        public string Nrodoc { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }

        public ProductorAgrario(long id, string nrodoc, string paterno, string materno, string nombres, string direccion, string celular)
        {
            Id = id;
            Nrodoc = nrodoc;
            Paterno = paterno;
            Materno = materno;
            Nombres = nombres;
            Direccion = direccion;
            Celular = celular;
        }
    }
}
