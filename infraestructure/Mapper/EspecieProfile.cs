using AutoMapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Domain.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Infra.MarcoLista.Mapper
{
    public class EspecieProfile : Profile
    {
        public EspecieProfile()
        {
            CreateMap<EspecieEntity, EspecieModel>();
            CreateMap<EspecieModel, EspecieListDto>();
            CreateMap<EspecieModel, EspecieGetDto>();
            CreateMap<EspecieCreateUpdateDto, EspecieModel>();
        }
    }
}