using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ExportExcel
{
    public class UsuarioExcel
    {
        [Description("Perfil")]
        public string? Perfil { get; set; }
        [Description("Número de documento")]
        public string? NumeroDocumento { get; set; }
        [Description("Nombre completo")]
        public string NombreCompleto { get; set; }
        [Description("Correo electrónico")]
        public string? CorreoElectronico { get; set; }
        [Description("Estado")]
        public int Estado { get; set; }



        
    }
}
