using AutoMapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Domain.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Infra.MarcoLista.Mapper
{
    public class CondicionJuridicaProfile : Profile
    {
        public CondicionJuridicaProfile()
        {
            CreateMap<CondicionJuridicaEntity, CondicionJuridicaModel>();
            CreateMap<CondicionJuridicaModel, CondicionJuridicaListDto>();
            CreateMap<CondicionJuridicaModel, CondicionJuridicaGetDto>();
            CreateMap<CondicionJuridicaCreateUpdateDto, CondicionJuridicaModel>();
        }
    }
}
