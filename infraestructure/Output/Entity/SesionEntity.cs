using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class SesionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_SESION")]
        public long Id { get; set; }
        [Column("IDE_USUARIO")]
        public long IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public PerfilEntity DetalleUsuario { get; set; }
        [Column("HORA_INICIO_SESION")]
        public DateTime? HoraInicioSesion { get; set; }
        [Column("HORA_FIN_SESION")]
        public DateTime? HoraFinSesion { get; set; }
        [Column("IP_DIRECCION")]
        public string? IpDireccion { get; set; }
        [Column("TXT_NAVEGADOR")]
        public string? Navegador { get; set; }
        [Column("FEC_REGISTRO")]
        public DateTime? FechaRegistroSesion { get; set; }
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
