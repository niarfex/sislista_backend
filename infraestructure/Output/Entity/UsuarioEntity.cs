using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class UsuarioEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_USUARIO", TypeName = "bigint", Order = 0)]
        public long Id { get; set; }

        [Required]
        [Column("IDE_PERSONA", TypeName = "varchar", Order = 1)]
        public long IdPersona { get; set; }
        [Required]
        [Column("TXT_USUARIO", TypeName = "varchar", Order = 1)]
        public string Usuario { get; set; }     
        [Column("TXT_TOKEN_RESETEO_CLAVE", TypeName = "varchar", Order = 1)]
        public long TokenReseteoClave { get; set; }

        [Column("FEC_TOKEN_RESETEO_EXPIRACION", TypeName = "varchar", Order = 1)]
        public DateTime FechaTokenReseteoExpiracion { get; set; }
        [Required]
        [Column("FLG_ESTADO", TypeName = "varchar", Order = 1)]
        public int Estado { get; set; }
    
        [Column("FEC_CREACION", TypeName = "varchar", Order = 1)]
        public DateTime FechaRegistro { get; set; }
  
        [Column("TXT_USUARIO_CREACION", TypeName = "varchar", Order = 1)]
        public string UsuarioCreacion { get; set; }
    
        [Column("FEC_ACTUALIZACION", TypeName = "timestamp", Order = 1)]
        public DateTime FechaActualizacion { get; set; }

        [Column("TXT_USUARIO_ACTUALIZACION", TypeName = "varchar", Order = 1)]
        public string UsuarioActualizacion { get; set; }
    }
}
