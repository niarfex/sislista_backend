using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class TrazabilidadEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_TRAZABILIDAD")]
        public long Id { get; set; }
        [Column("IDE_CUESTIONARIO")]
        public long? IdCuestionario { get; set; }
        [Column("TXT_OBSERVACION")]
        public string? Observacion { get; set; }
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
        [Column("IDE_ESTADO_RESULTADO")]
        public long? EstadoResultado { get; set; }
        [Column("IDE_SECCION")]
        public long? IdSeccion { get; set; }
        [Column("TXT_PERFIL")]
        public string? Perfil { get; set; }
    }
}
