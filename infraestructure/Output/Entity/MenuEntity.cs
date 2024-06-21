using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class MenuEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_MENU")]
        public long Id { get; set; }
        [Column("IDE_MENU_PADRE")]
        public long? IdMenuPadre { get; set; }
        [ForeignKey("IdMenuPadre")]
        public MenuEntity DetalleMenu { get; set; }
        [Column("TXT_MENU")]
        public string? Menu { get; set; }
        [Column("TXT_ENLACE")]
        public string? Enlace { get; set; }
        [Column("NUM_ORDEN")]
        public int Orden { get; set; }
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
