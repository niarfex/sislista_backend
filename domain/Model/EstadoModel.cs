﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class EstadoModel
    {
        public long Id { get; set; }
        public string? TipoEstado { get; set; }     
        public string? CodigoEstado { get; set; }
        public string? CodigoEstadoPadre { get; set; }
    }
}
