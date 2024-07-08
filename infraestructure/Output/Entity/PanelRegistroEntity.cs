using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class PanelRegistroEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_PROGRAMACION_REGISTRO")]
        public long Id { get; set; }
        [Column("IDE_PLANTILLA")]
        public long? IdPlantilla { get; set; }
        [ForeignKey("IdPlantilla")]
        public PlantillaEntity DetallePlantilla { get; set; }
        [Column("IDE_USUARIO")]
        public long? IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public UsuarioEntity DetalleUsuario { get; set; }
        [Column("IDE_ANIO")]
        public long? IdAnio { get; set; }
        [ForeignKey("IdAnio")]
        public UsuarioEntity DetalleAnio { get; set; }
        [Column("TXT_PROGRAMACION_REGISTRO")]
        public string? ProgramacionRegistro { get; set; }
        [Column("FEC_INICIO")]
        public DateTime? FechaInicio { get; set; }
        [Column("FEC_FIN")]
        public DateTime? FechaFin { get; set; }
        [Column("TXT_DECRETO_NORMA")]
        public string? DecretoNorma { get; set; }
        [Column("TXT_ARCHIVO_DECRETO_NORMA")]
        public string? ArchivoDecretoNorma { get; set; }
        [Column("TXT_OBJETIVO")]
        public string? Objetivo { get; set; }
        [Column("TXT_ENTE_RECTOR")]
        public string? EnteRector { get; set; }
        [Column("INT_ESTADO_PROGRAMACION")]
        public int EstadoProgramacion { get; set; }
        [Column("FLG_ESTADO")]
        public int Estado { get; set; }
        [Column("FEC_CREACION")]
        public DateTime? FechaRegistro { get; set; }
        [Column("TXT_USUARIO_CREACION")]
        public string? UsuarioCreacion { get; set; }
        [Column("FEC_ACTUALIZACION")]
        public DateTime? FechaActualizacion { get; set; }
        [Column("TXT_USUARIO_ACTUALIZACION")]
        public string? UsuarioActualizacion { get; set; }
    }
}
