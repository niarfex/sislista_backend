using AutoMapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Domain.Model;
using Domain.Model.ExportExcel;
namespace Infra.MarcoLista.Mapper
{
    public class ExcelProfile : Profile
    {
        public ExcelProfile()
        {            
            CreateMap<CondicionJuridicaListDto, CondicionJuridicaExcel>();
            CreateMap<CultivoListDto, CultivoExcel>();
            CreateMap<EspecieListDto, EspecieExcel>();
            CreateMap<LineaProduccionListDto, LineaProduccionExcel>();
            CreateMap<MarcoListaListDto, MarcoListaExcel>();
            CreateMap<GestionRegistroListDto, GestionRegistroExcel>();
            CreateMap<NotificacionListDto, NotificacionExcel>();
            CreateMap<OrganizacionListDto, OrganizacionExcel>();
            CreateMap<PanelRegistroListDto, PanelRegistroExcel>();
            CreateMap<PlantillaListDto, PlantillaExcel>();
            CreateMap<TipoExplotacionListDto, TipoExplotacionExcel>();
            CreateMap<UbigeoListDto, UbigeoExcel>();
            CreateMap<UsuarioListDto, UsuarioExcel>();
        }
    }
}