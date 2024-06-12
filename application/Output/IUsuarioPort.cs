using Domain.Model;

namespace Application.Output
{
    public interface IUsuarioPort
    {
        Task<List<UsuarioModel>> GetAll(ParamBusqueda param);
    }
}
