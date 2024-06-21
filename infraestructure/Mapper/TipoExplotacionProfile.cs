using AutoMapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Domain.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Infra.MarcoLista.Mapper
{
    public class TipoExplotacionProfile : Profile
    {
        public TipoExplotacionProfile()
        {
            CreateMap<TipoExplotacionEntity, TipoExplotacionModel>();
            CreateMap<TipoExplotacionModel, TipoExplotacionListDto>();
            CreateMap<TipoExplotacionModel, TipoExplotacionGetDto>();     
            CreateMap<TipoExplotacionCreateUpdateDto, TipoExplotacionModel>();   
        }
    }
}
