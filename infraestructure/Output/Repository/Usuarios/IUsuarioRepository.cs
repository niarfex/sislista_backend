using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioModel>> GetAll(string param);
        Task<UsuarioEntity> GetUsuarioxUUID(string uuid);
        Task<string> CreateUsuario(UsuarioModel model);
        Task<string> DeleteUsuarioxUUID(string uuid);
        Task<string> ActivarUsuarioxUUID(string uuid);
        Task<string> DesactivarUsuarioxUUID(string uuid);
    }
}
