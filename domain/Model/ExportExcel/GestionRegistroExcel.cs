using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ExportExcel
{
    public class GestionRegistroExcel
    {
        [Description("Periodo")]
        public string? Periodo { get; set; }
        [Description("Razón social/Nombre completo")]
        public string? NombreCompleto { get; set; }
        [Description("Número Doc.")]
        public string? NumeroDocumento { get; set; }
        [Description("Fecha de registro")]
        public DateTime? FechaRegistro { get; set; }
        [Description("Usuario de registro")]
        public string? UsuarioCreacion { get; set; }
        [Description("Fecha de modificación")]
        public DateTime? FechaActualizacion { get; set; }
        [Description("Usuario de modificación")]
        public string? UsuarioActualizacion { get; set; }
        [Description("Tipo de Explotación")]
        public string? TipoExplotacion { get; set; }
        [Description("Clasificación")]
        public string? Clasificacion { get; set; }
        [Description("Estado de Entrevista")]
        public string? NombreEstadoEntrevista { get; set; }
        [Description("Estado de Supervisión")]
        public string? NombreEstadoSupervision { get; set; }
        [Description("Estado de Validación")]
        public string? NombreEstadoValidacion { get; set; }
        [Description("Estado de Registro")]
        public string? NombreEstadoRegistro { get; set; }
    }
}
