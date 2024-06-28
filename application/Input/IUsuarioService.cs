﻿using Domain.Model;

namespace Application.Input
{
    public interface IUsuarioService
    {
        Task<List<UsuarioModel>> GetAll(string param);
        Task<UsuarioModel> GetUsuarioxUUID(string uuid);
        Task<string> CreateUsuario(UsuarioModel model);
        Task<string> DeleteUsuarioxUUID(string uuid);
        Task<string> ActivarUsuarioxUUID(string uuid);
        Task<string> DesactivarUsuarioxUUID(string uuid);
        Task<List<MarcoListaModel>> GetUsuarioMarcoLista(string uuid);
        Task<bool> SendCredenciales(string uuid);
        Task<LoginModel> datosInicioSesion(AuthModel auth);
    }
}
