using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class PerfilPermisoEntidadEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_PERFIL_PERMISO_ENTIDAD")]
        public long Id { get; set; }
        [Column("IDE_PERFIL")]
        public long? IdPerfil { get; set; }
        [ForeignKey("IdPerfil")]
        public PerfilEntity DetallePerfil { get; set; }
        [Column("IDE_PERMISO")]
        public long IdPermiso { get; set; }
        [ForeignKey("IdPermiso")]
        public PermisoEntity DetallePermiso { get; set; }
        [Column("IDE_ENTIDAD")]
        public long IdEntidad { get; set; }
        [ForeignKey("IdEntidad")]
        public EntidadEntity DetalleEntidad { get; set; }
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
