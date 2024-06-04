using AutoMapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Domain.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Infra.MarcoLista.Mapper
{
    public class ProductorAgrarioProfile : Profile
    {
        public ProductorAgrarioProfile()
        {
            CreateMap<ProductorAgrarioEntity, Domain.Model.ProductorAgrario>();
            CreateMap<Domain.Model.ProductorAgrario, ProductorAgrarioDto>();
        }
    }
}
