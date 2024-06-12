using Domain.Model;

namespace Application.Input
{
    public interface IUsuarioService
    {
        Task<List<UsuarioModel>> GetAll(ParamBusqueda param);
    }
}
