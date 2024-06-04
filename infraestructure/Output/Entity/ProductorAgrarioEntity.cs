using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Output.Entity
{
    public class ProductorAgrarioEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDE_PERSONA", TypeName = "bigint", Order = 0)]
        public long Id { get; set; }

        [Required]
        [Column("TXT_NRODOC", TypeName = "varchar", Order = 1)]
        public string Nrodoc { get; set; }

        [Required]
        [Column("TXT_APELLIDOPATERNO", TypeName = "varchar", Order = 2)]
        public string Paterno { get; set; }

        [Required]
        [Column("TXT_APELLIDOMATERNO", TypeName = "varchar", Order = 3)]
        public string Materno { get; set; }

        [Required]
        [Column("TXT_NOMBRES", TypeName = "varchar", Order = 4)]
        public string Nombres { get; set; }

        [Required]
        [Column("TXT_DIRECCION", TypeName = "varchar", Order = 5)]
        public string Direccion { get; set; }

        [Required]
        [Column("TXT_CELULAR", TypeName = "varchar", Order = 6)]
        public string Celular { get; set; }
    }
}
