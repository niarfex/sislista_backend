using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class UsuarioPerfilEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_USUARIO_PERFIL")]
        public long Id { get; set; }
        [Column("IDE_USUARIO")]
        public long IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public UsuarioEntity DetalleUsuario { get; set; }
        [Column("IDE_PERFIL")]
        public long IdPerfil { get; set; }
        [ForeignKey("IdPerfil")]
        public PerfilEntity DetallePerfil { get; set; }
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
