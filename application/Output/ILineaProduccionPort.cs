using Domain.Model;

namespace Application.Output
{
    public interface ILineaProduccionPort
    {
        Task<List<LineaProduccionModel>> GetAll(ParamBusqueda param);
    }
}
