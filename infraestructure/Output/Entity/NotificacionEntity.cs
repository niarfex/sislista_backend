using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class NotificacionEntity
    {
        [Column("IDE_NOTIFICACION")]
        public long Id { get; set; }
        [Column("TXT_ASUNTO")]
        public string? Asunto { get; set; }
        [Column("IDE_FRECUENCIA")]
        public long? IdFrecuencia { get; set; }
        [ForeignKey("IdFrecuencia")]
        public FrecuenciaEntity DetalleFrecuencia { get; set; }
        [Column("IDE_PROGRAMACION_REGISTRO")]
        public long? IdProgramacionRegistro { get; set; }
        [ForeignKey("IdProgramacionRegistro")]
        public PanelRegistroEntity DetalleProgramacionRegistro { get; set; }
        [Column("IDE_ETAPA")]
        public long? IdEtapa { get; set; }
        [ForeignKey("IdEtapa")]
        public EtapaEntity DetalleEtapa { get; set; }
        [Column("TXT_DESCRIPCION")]
        public string? Descripcion { get; set; }
        [Column("IDE_PERFIL")]
        public long? IdPerfil { get; set; }
        [ForeignKey("IdPerfil")]
        public EtapaEntity DetallePerfil { get; set; }
        [Column("INT_ESTADO_NOTIFICACION")]
        public int EstadoNotificacion { get; set; }
        [Column("FEC_NOTIFICACION")]
        public DateTime? FechaNotificacion { get; set; }
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
