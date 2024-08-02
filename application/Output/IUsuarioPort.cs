using Domain.Model;

namespace Application.Output
{
    public interface IUsuarioPort
    {
        Task<List<UsuarioModel>> GetAll(string param);
        Task<UsuarioModel> GetUsuarioxUUID(string uuid);
        Task<UsuarioModel> GetUsuarioxCorreo(string correo);
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
        Task<LoginModel> datosInicioSesion(AuthModel auth);
        Task<bool> ValidarTokenReseteo(string token);
        Task<bool> ActualizarClave(ResetAuthModel reset);
    }
}
