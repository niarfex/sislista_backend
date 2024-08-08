using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class UsoNoAgricolaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_USO_NO_AGRICOLA")]
        public long Id { get; set; }
        [Column("TXT_USO_NO_AGRICOLA")]
        public string? UsoNoAgricola { get; set; }
        [Column("TXT_CODIGO_USO_NO_AGRICOLA")]
        public string? CodigoUsoNoAgricola { get; set; }
        [Column("FLG_AGRICOLA")]
        public int Agricola { get; set; }
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
