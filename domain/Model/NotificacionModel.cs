using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class NotificacionModel
    {
        public long Id { get; set; }
        public string? Asunto { get; set; }
        public long? IdFrecuencia { get; set; }
        public long? IdProgramacionRegistro { get; set; }
        public long? IdEtapa { get; set; }
        public string? Descripcion { get; set; }
        public long? IdPerfil { get; set; }
        public int EstadoNotificacion { get; set; }
        public DateTime? FechaNotificacion { get; set; }
        public int Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        //Lista
        public string? Frecuencia { get; set; }
        public string? UsuariosNotificados { get; set; }

    }
}
