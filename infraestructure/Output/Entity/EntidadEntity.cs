﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class EntidadEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_ENTIDAD")]
        public long Id { get; set; }
        [Column("TXT_ENTIDAD")]
        public string? Entidad { get; set; }
        [Column("TXT_DESCRIPCION")]
        public string? Descripcion { get; set; }
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
