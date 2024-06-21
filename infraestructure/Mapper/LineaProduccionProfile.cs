using AutoMapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Domain.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Infra.MarcoLista.Mapper
{
    public class LineaProduccionProfile : Profile
    {
        public LineaProduccionProfile()
        {
            CreateMap<LineaProduccionEntity, LineaProduccionModel>();
            CreateMap<LineaProduccionModel, LineaProduccionListDto>();
            CreateMap<LineaProduccionModel, LineaProduccionGetDto>();        
            CreateMap<LineaProduccionCreateUpdateDto, LineaProduccionModel>();

        }
    }
}
