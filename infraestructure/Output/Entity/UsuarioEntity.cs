using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class UsuarioEntity
    {
        [Key]
        [Description("IDE_USUARIO")]
        public long Id { get; set; } 
        
        [Description("IDE_PERSONA")]
        public long IdPersona { get; set; }
     
        [Description("TXT_USUARIO")]
        public string Usuario { get; set; }     
        [Description("TXT_TOKEN_RESETEO_CLAVE")]
        public long? TokenReseteoClave { get; set; }

        [Description("FEC_TOKEN_RESETEO_EXPIRACION")]
        public DateTime? FechaTokenReseteoExpiracion { get; set; }
        [Required]
        [Description("FLG_ESTADO")]
        public int Estado { get; set; }
    
        [Description("FEC_CREACION")]
        public DateTime? FechaRegistro { get; set; }
  
        [Description("TXT_USUARIO_CREACION")]
        public string? UsuarioCreacion { get; set; }
    
        [Description("FEC_ACTUALIZACION")]
        public DateTime? FechaActualizacion { get; set; }

        [Description("TXT_USUARIO_ACTUALIZACION")]
        public string? UsuarioActualizacion { get; set; }
    }
}
