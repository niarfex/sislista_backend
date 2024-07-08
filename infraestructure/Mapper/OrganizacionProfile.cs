using AutoMapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Domain.Model;
using Domain.Model.ExportExcel;
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
            CreateMap<UbigeoModel, UbigeoListDto>();
            CreateMap<OrganizacionListDto, OrganizacionExcel>();
        }
    }
}
