using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class ProductorAgrarioDto
    {
        [Required(ErrorMessage = "Nro de documento no debe ser NULO")]
        [MinLength(8, ErrorMessage = "Nro de documento no debe ser vacío")]
        public string Nrodoc { get; set; }

        [Required(ErrorMessage = "Apellido Paterno no debe ser NULO")]
        [MinLength(1, ErrorMessage = "Apellido Paterno no debe ser vacío")]
        public string Paterno { get; set; }

        public string Materno { get; set; }

        [Required(ErrorMessage = "Nombre no debe ser NULO")]
        [MinLength(1, ErrorMessage = "Nombre no debe ser vacío")]
        public string Nombres { get; set; }

        public string Direccion { get; set; }
        public string Celular { get; set; }
    }
}
