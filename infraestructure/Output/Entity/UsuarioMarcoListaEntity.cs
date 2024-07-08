using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class UsuarioMarcoListaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_USUARIO_MARCO_LISTA")]
        public long Id { get; set; }
        [Column("IDE_USUARIO")]
        public long IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public UsuarioEntity DetalleUsuario { get; set; }
        [Column("IDE_MARCO_LISTA")]
        public long IdMarcoLista { get; set; }
        [ForeignKey("IdMarcoLista")]
        public MarcoListaEntity DetalleMarcoLista { get; set; }
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
