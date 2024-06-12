using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class CultivoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_SUB_CLASE_NACIONAL")]
        public long Id { get; set; }
        [Column("IDE_ARANCEL_ADUANA")]
        public long? IdArancelAduana { get; set; }
        [Column("IDE_CLANAE")]
        public long? IdClanae { get; set; }
        [Column("TXT_CODIGO_SUB_CLASE_NACIONAL")]
        public string? CodigoSubClaseNacional { get; set; }
        [Column("TXT_SUB_CLASE_NACIONAL")]
        public string? SubClaseNacional { get; set; }
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
