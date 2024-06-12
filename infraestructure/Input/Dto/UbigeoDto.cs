using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class UbigeoDto
    {
        public long Id { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Estado { get; set; }
    }
}
