using AutoMapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Domain.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Infra.MarcoLista.Mapper
{
    public class PlantillaProfile : Profile
    {
        public PlantillaProfile()
        {
            CreateMap<PlantillaEntity, PlantillaModel>();
            CreateMap<PlantillaModel, PlantillaListDto>();
            CreateMap<PlantillaModel, PlantillaGetDto>();
            CreateMap<PlantillaCreateUpdateDto, PlantillaModel>();
            CreateMap<AnioEntity, AnioModel>();
        }
    }
}
