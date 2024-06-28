﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class UsuarioEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_USUARIO")]
        public long Id { get; set; } 
        
        [Column("IDE_PERSONA")]
        public long IdPersona { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TXT_CODIGO_UUID")]
        public string CodigoUUID { get; set; }
        [Column("TXT_USUARIO")]
        public string? Usuario { get; set; }
        [Column("TXT_CLAVE")]
        public byte[] Clave { get; set; }
        [Column("TXT_TOKEN_RESETEO_CLAVE")]
        public long? TokenReseteoClave { get; set; }

        [Column("FEC_TOKEN_RESETEO_EXPIRACION")]
        public DateTime? FechaTokenReseteoExpiracion { get; set; }

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
