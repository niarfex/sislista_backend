using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class LineaProduccionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_LINEA_PRODUCCION")]
        public long Id { get; set; }
        [Column("TXT_CODIGO_LINEA_PRODUCCION")]
        public string? CodigoLineaProduccion { get; set; }
        [Column("TXT_LINEA_PRODUCCION")]
        public string? LineaProduccion { get; set; }
        [Column("TXT_DESCRIPCION_LINEA_PRODUCCION")]
        public string? DescripcionLineaProduccion { get; set; }
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
