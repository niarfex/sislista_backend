using Domain.Model;

namespace Application.Output
{
    public interface IUsuarioPort
    {
        Task<List<UsuarioModel>> GetAll(string param);
        Task<UsuarioModel> GetUsuarioxUUID(string uuid);
        Task<string> CreateUsuario(UsuarioModel model);
        Task<string> DeleteUsuarioxUUID(string uuid);
        Task<string> ActivarUsuarioxUUID(string uuid);
        Task<string> DesactivarUsuarioxUUID(string uuid);
    }
}
