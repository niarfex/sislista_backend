using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class TipoOrganizacionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_TIPO_ORGANIZACION")]
        public long Id { get; set; }
        [Column("TXT_CODIGO_TIPO_ORGANIZACION")]
        public string? CodigoTipoOrganizacion { get; set; }
        [Column("TXT_TIPO_ORGANIZACION")]
        public string TipOrganizacion { get; set; }
        [Column("FLG_ESTADO")]
        public int Estado { get; set; }
    }
}
