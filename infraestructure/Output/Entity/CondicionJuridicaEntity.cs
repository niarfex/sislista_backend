using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class CondicionJuridicaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_CONDICION_JURIDICA")]
        public long Id { get; set; }
        [Column("TXT_CODIGO_CONDICION_JURIDICA")]
        public string? CodigoCondicionJuridica { get; set; }
        [Column("TXT_CONDICION_JURIDICA")]
        public string? CondicionJuridica { get; set; }
        [Column("TXT_DESCRIPCION_CONDICION_JURIDICA")]
        public string? DescripcionCondicionJuridica { get; set; }
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
