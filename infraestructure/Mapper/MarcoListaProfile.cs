using AutoMapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Domain.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Infra.MarcoLista.Mapper

{
    public class MarcoListaProfile : Profile
    {
        public MarcoListaProfile()
        {
            CreateMap<MarcoListaEntity, MarcoListaModel>();
            CreateMap<MarcoListaModel, MarcoListaListDto>();
            CreateMap<MarcoListaModel, MarcoListaGetDto>();
            CreateMap<MarcoListaCreateUpdateDto, MarcoListaModel>();
            CreateMap<MarcoListaListDto, MarcoListaModel>();
        }
    }
}
