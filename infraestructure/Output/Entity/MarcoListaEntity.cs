using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class MarcoListaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_MARCO_LISTA")]
        public long Id { get; set; }
        [Column("IDE_PERSONA")]
        public long? IdPersona { get; set; }
        [Column("IDE_TIPO_EXPLOTACION")]
        public long? IdTipoExplotacion { get; set; }
        [Column("TXT_DIRECCION")]
        public string? Direccion { get; set; }
        [Column("IDE_DEPARTAMENTO")]
        public long? IdDepartamento { get; set; }
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
