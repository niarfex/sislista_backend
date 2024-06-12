using AutoMapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Domain.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Infra.MarcoLista.Mapper
{
    public class UbigeoProfile : Profile
    {
        public UbigeoProfile()
        {
            CreateMap<UbigeoEntity, UbigeoModel>();
            CreateMap<UbigeoModel, UbigeoDto>();
        }
    }
}
