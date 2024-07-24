using AutoMapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Domain.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Infra.MarcoLista.Mapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioEntity, UsuarioModel>();
            CreateMap<UsuarioModel, UsuarioListDto>();
            CreateMap<UsuarioModel, UsuarioGetDto>();
            CreateMap<UsuarioCreateUpdateDto, UsuarioModel>();
            CreateMap<PerfilEntity, PerfilModel>();
            CreateMap<MenuItemModel, MenuItemGetDto>();
        }
    }
}
