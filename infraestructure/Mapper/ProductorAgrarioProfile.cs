using AutoMapper;
using Infra.ProductorAgrario.Input.Dto;
using Infra.ProductorAgrario.Output.Entity;
using Domain.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Infra.ProductorAgrario.Mapper
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
