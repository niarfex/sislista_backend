using Domain.Model;

namespace Application.Input
{
    public interface ILineaProduccionService
    {
        Task<List<LineaProduccionModel>> GetAll(ParamBusqueda param);
    }
}
