using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class FundoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_FUNDO")]
        public long Id { get; set; }
        [Column("IDE_CUESTIONARIO")]
        public long? IdCuestionario { get; set; }
        [Column("TXT_FUNDO")]
        public string? Fundo { get; set; }
        [Column("IDE_UBIGEO")]
        public string? IdUbigeo { get; set; }
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
    }
}
