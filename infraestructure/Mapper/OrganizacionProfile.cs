using AutoMapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Domain.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Infra.MarcoLista.Mapper
{
    public class OrganizacionProfile : Profile
    {
        public OrganizacionProfile()
        {
            CreateMap<OrganizacionEntity, OrganizacionModel>();
            CreateMap<OrganizacionModel, OrganizacionListDto>();
            CreateMap<OrganizacionModel, OrganizacionGetDto>();
            CreateMap<TipoOrganizacionEntity, TipoOrganizacionModel>();
            CreateMap<OrganizacionCreateUpdateDto, OrganizacionModel>();
            CreateMap<SelectTipoModel, SelectTipoDto>();
        }
    }
}
