using Domain.Model;

namespace Application.Input
{
    public interface IMarcoListaService
    {
        Task<List<MarcoListaModel>> GetAll(ParamBusqueda param);
    }
}
