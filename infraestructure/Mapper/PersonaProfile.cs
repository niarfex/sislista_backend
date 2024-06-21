using AutoMapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Domain.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Infra.MarcoLista.Mapper
{
    public class PersonaProfile : Profile
    {
        public PersonaProfile()
        {
            CreateMap<PersonaEntity, PersonaModel>();
            CreateMap<TipoDocumentoEntity, TipoDocumentoModel>();
        
        }
    }
}
