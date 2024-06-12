using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class OrganizacionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_ORGANIZACION")]
        public long Id { get; set; }
        [Column("IDE_TIPO_ORGANIZACION")]
        public long? IdTipoOrganizacion { get; set; }
        [Column("IDE_DEPARTAMENTO")]
        public long? IdDepartamento { get; set; }
        [Column("TXT_NUMERO_DOCUMENTO")]
        public string? NumeroDocumento { get; set; }
        [Column("TXT_ORGANIZACION")]
        public string? Organizacion { get; set; }
        [Column("TXT_DIRECCION_FISCAL")]
        public string? DireccionFiscal { get; set; }
        [Column("TXT_TELEFONO")]
        public string? Telefono { get; set; }
        [Column("TXT_PAGINA_WEB")]
        public string? PaginaWeb { get; set; }
        [Column("TXT_CORREO_ELECTRONICO")]
        public string? CorreoElectronico { get; set; }
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
