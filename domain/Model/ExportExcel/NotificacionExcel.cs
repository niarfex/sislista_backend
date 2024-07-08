using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ExportExcel
{
    public class NotificacionExcel
    {
        [Description("Asunto")]
        public string? Asunto { get; set; }
        [Description("Frecuencia")]
        public string? Frecuencia { get; set; }
        [Description("Usuarios notificados")]
        public string? UsuariosNotificados { get; set; }
        [Description("Fecha de registro")]
        public DateTime? FechaRegistro { get; set; }
        [Description("Fecha de notificación")]
        public DateTime? FechaNotificacion { get; set; }
        [Description("Estado")]
        public int EstadoNotificacion { get; set; }

        //Lista


    }
}
