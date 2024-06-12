using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioEntity>> GetAll(ParamBusqueda param);
        Task<UsuarioEntity> getUsuarioxUUID();
        Task<UsuarioEntity> createUsuario();
        Task<UsuarioEntity> updateUsuarioxUUID();
        Task<bool> deleteUsuarioxUUID();
    }
}
