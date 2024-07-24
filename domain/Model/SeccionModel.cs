using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Model
{
    public class SeccionModel
    {
        public long Id { get; set; }
        public string? Seccion { get; set; }
        public string? CodigoSeccion { get; set; }
    }
}
