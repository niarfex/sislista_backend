using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class ArchivoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_ARCHIVO")]
        public long Id { get; set; }
        [Column("IDE_CUESTIONARIO")]
        public long IdCuestionario { get; set; }
        [Column("TXT_NOMBRE_ARCHIVO")]
        public string? NombreArchivo { get; set; }
        [Column("TXT_ARCHIVO")]
        public string? Archivo { get; set; }
        [Column("TXT_DESCRIPCION_ARCHIVO")]
        public string? DescripcionArchivo { get; set; }
        [Column("FLG_CUESTIONARIO_PRINCIPAL")]
        public int? CuestionarioPrincipal { get; set; }
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
        [Column("IDE_TIPO_INFORMACION")]
        public long? IdTipoInformacion { get; set; }
        [Column("NUM_PESO")]
        public double? Peso { get; set; }
    }
}
