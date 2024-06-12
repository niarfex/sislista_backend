using Domain.Model;

namespace Application.Output
{
    public interface IMarcoListaPort
    {
        Task<List<MarcoListaModel>> GetAll(ParamBusqueda param);
    }
}
