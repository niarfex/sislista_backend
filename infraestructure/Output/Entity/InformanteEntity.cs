using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class InformanteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_INFORMANTE")]
        public long Id { get; set; }
        [Column("IDE_CUESTIONARIO")]
        public long? IdCuestionario { get; set; }
        [Column("IDE_PERSONA")]
        public long? IdPersona { get; set; }
        [Column("IDE_ESTADO")]
        public long IdEstado { get; set; }
        [Column("TXT_OBSERVACION")]
        public string? Observacion { get; set; }
        [Column("TXT_DIRECCION")]
        public string? Direccion { get; set; }
        [Column("TXT_COORDENADA_ESTE")]
        public string? CoordenadaEste { get; set; }
        [Column("TXT_COORDENADA_NORTE")]
        public string? CoordenadaNorte { get; set; }
        [Column("TXT_SISTEMA_COORDENADA")]
        public string? SistemaCoordenada { get; set; }
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
