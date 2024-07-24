using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class PecuarioEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_PECUARIO")]
        public long Id { get; set; }
        [Column("IDE_FUNDO")]
        public long? IdFundo { get; set; }
        [Column("IDE_CAMPO")]
        public long? IdCampo { get; set; }
        [Column("IDE_SISTEMA_PECUARIO")]
        public long? IdSistemaPecuario { get; set; }
        [Column("IDE_LINEA_PRODUCCION")]
        public long? IdLineaProduccion { get; set; }
        [Column("IDE_ESPECIE")]
        public long? IdEspecie { get; set; }
        [Column("NUM_CANTIDAD")]
        public int Cantidad { get; set; }
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
