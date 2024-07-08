using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class GestionRegistroEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_CUESTIONARIO")]
        public long Id { get; set; }
        [Column("IDE_PPA")]
        public long? IdPPA { get; set; }
        [Column("IDE_MARCO_LISTA")]
        public long? IdMarcoLista { get; set; }
        [Column("IDE_CONDICION_JURIDICA")]
        public long? IdCondicionJuridica { get; set; }
        [Column("IDE_TIPO_DOCUMENTO")]
        public long? IdTipoDocumento { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TXT_CODIGO_UUID")]
        public string? CodigoUUID { get; set; }
        [Column("TXT_CODIGO_IDENTIFICACION")]
        public string? CodigoIdentificacion { get; set; }
        [Column("TXT_NUMERO_DOCUMENTO")]
        public string? NumeroDocumento { get; set; }
        [Column("TXT_NOMBRE")]
        public string? Nombre { get; set; }
        [Column("TXT_APELLIDO_PATERNO")]
        public string? ApellidoPaterno { get; set; }
        [Column("TXT_APELLIDO_MATERNO")]
        public string? ApellidoMaterno { get; set; }
        [Column("TXT_RAZON_SOCIAL")]
        public string? RazonSocial { get; set; }
        [Column("TXT_DIRECCION_FISCAL_DOMICILIO")]
        public string? DireccionFiscalDomicilio { get; set; }
        [Column("IDE_UBIGEO")]
        public string? IdUbigeo { get; set; }
        [Column("IDE_TIPO_EXPLOTACION")]
        public long? IdTipoExplotacion { get; set; }
        [Column("TXT_TIENE_RUC")]
        public string? TieneRuc { get; set; }
        [Column("TXT_TELEFONO")]
        public string? Telefono { get; set; }
        [Column("TXT_CELULAR")]
        public string? Celular { get; set; }
        [Column("TXT_CORREO_ELECTRONICO")]
        public string? CorreoElectronico { get; set; }
        [Column("TXT_PAGINA_WEB")]
        public string? PaginaWeb { get; set; }
        [Column("TXT_NOMBRE_COMPLETO_REPRESENTANTE_LEGAL")]
        public string? NombreRepLegal { get; set; }
        [Column("TXT_CORREO_ELECTRONICO_REPRESENTANTE_LEGAL")]
        public string? CorreoRepLegal { get; set; }
        [Column("TXT_CELULAR_REPRESENTANTE_LEGAL")]
        public string? CelularRepLegal { get; set; }
        [Column("TXT_CANTIDAD_FUNDO")]
        public string? CantidadFundo { get; set; }
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
