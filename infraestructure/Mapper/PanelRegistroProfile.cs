using AutoMapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Domain.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Infra.MarcoLista.Mapper
{
    public class PanelRegistroProfile : Profile
    {
        public PanelRegistroProfile()
        {
            CreateMap<PanelRegistroEntity, PanelRegistroModel>();
            CreateMap<PanelRegistroModel, PanelRegistroListDto>();
            CreateMap<PanelRegistroModel, PanelRegistroGetDto>();
            CreateMap<PanelRegistroCreateUpdateDto, PanelRegistroModel>();
        }
    }
}
