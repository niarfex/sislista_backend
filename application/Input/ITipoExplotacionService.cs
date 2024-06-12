using Domain.Model;

namespace Application.Input
{
    public interface ITipoExplotacionService
    {
        Task<List<TipoExplotacionModel>> GetAll(ParamBusqueda param);
    }
}
