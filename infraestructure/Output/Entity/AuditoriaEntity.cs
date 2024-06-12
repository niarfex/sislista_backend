using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class AuditoriaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_AUDITORIA")]
        public long Id { get; set; }
        [Column("TXT_TABLA")]
        public string? Tabla { get; set; }
        [Column("TXT_OPERACION")]
        public string? Operacion { get; set; }
        [Column("IDE_TABLA")]
        public long? IdTabla { get; set; }
        [Column("TXT_DATO_ANTERIOR")]
        public string? DatoAnterior { get; set; }
        [Column("TXT_DATO_NUEVO")]
        public string? DatoNuevo { get; set; }
        [Column("TXT_USUARIO")]
        public string? Usuario { get; set; }
        [Column("FEC_MODIFICADA")]
        public DateTime? FechaModificada { get; set; }
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
