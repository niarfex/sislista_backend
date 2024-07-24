﻿using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioModel>> GetAll(string param);
        Task<UsuarioModel> GetUsuarioxUUID(string uuid);
        Task<LoginModel> GetUsuarioLoginxUUID(string uuid);
        Task<string> CreateUsuario(UsuarioModel model);
        Task<string> DeleteUsuarioxUUID(string uuid);
        Task<string> ActivarUsuarioxUUID(string uuid);
        Task<string> DesactivarUsuarioxUUID(string uuid);
        Task<List<UsuarioModel>> GetCorreosUsuariosxPerfil(long idPerfil);
        Task<List<UsuarioModel>> GetCorreosUsuariosxOrganizacion(long idOrganizacion);
        Task<List<UsuarioModel>> GetCorreosUsuariosxMarcoLista(long idMarcoLista);
        Task<List<MenuItemModel>> GetMenuItemxUsuario(long idPadre);
        Task<bool> ActualizarRefreshToken(string uuid, DateTime expiracion, string refreshToken);
        Task<List<MarcoListaModel>> GetUsuarioMarcoLista(string uuid);
        Task<string> GetClaveEncriptada(string clave);
        Task<string> GetClaveDesencriptada(string claveEncriptada);
        //Task<string> GetClaveUsuario(long idUsuario);
        Task<LoginModel> datosInicioSesion(AuthModel auth);
    }
}
