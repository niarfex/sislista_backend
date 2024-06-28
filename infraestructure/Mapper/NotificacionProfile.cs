using AutoMapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Domain.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Infra.MarcoLista.Mapper
{
    public class NotificacionProfile : Profile
    {
        public NotificacionProfile()
        {
            CreateMap<NotificacionEntity, NotificacionModel>();
            CreateMap<NotificacionModel, NotificacionListDto>();
            CreateMap<NotificacionModel, NotificacionGetDto>();
            CreateMap<NotificacionCreateUpdateDto, NotificacionModel>();
            CreateMap<AnioEntity, AnioModel>();
            CreateMap<EtapaEntity, EtapaModel>();
        }
    }
}
