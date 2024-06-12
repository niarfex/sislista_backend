using Domain.Model;

namespace Application.Output
{
    public interface ITipoExplotacionPort
    {
        Task<List<TipoExplotacionModel>> GetAll(ParamBusqueda param);
    }
}
