using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.MarcoLista.Output.Entity
{
    public class EstadoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_ESTADO")]
        public long Id { get; set; }
        [Column("TXT_ESTADO")]
        public string? TipoEstado { get; set; }
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
        [Column("TXT_CODIGO_ESTADO")]
        public string? CodigoEstado { get; set; }
        [Column("TXT_CODIGO_ESTADO_PADRE")]
        public string? CodigoEstadoPadre { get; set; }
    }
}
