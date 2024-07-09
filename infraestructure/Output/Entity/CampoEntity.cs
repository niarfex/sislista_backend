using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class CampoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_CAMPO")]
        public long Id { get; set; }
        [Column("IDE_FUNDO")]
        public long? IdFundo { get; set; }
        [Column("TXT_CAMPO")]
        public string? Campo { get; set; }
        [Column("IDE_TENENCIA")]
        public long? IdTenencia { get; set; }
        [Column("IDE_USO_TIERRA")]
        public long? IdUsoTierra { get; set; }
        [Column("IDE_CULTIVO")]
        public long? IdCultivo { get; set; }
        [Column("IDE_USO_NO_AGRICOLA")]
        public long? IdUsoNoAgricola { get; set; }
        [Column("TXT_OBSERVACION")]
        public string? Observacion { get; set; }
        [Column("NUM_SUPERFICIE")]
        public double? Superficie { get; set; }
        [Column("NUM_SUPERFICIE_CULTIVADA")]
        public double? SuperficieCultivada { get; set; }
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
