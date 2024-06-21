using Domain.Model;

namespace Application.Input
{
    public interface ILineaProduccionService
    {
        Task<List<LineaProduccionModel>> GetAll(string param);
        Task<LineaProduccionModel> GetLineaProduccionxId(long id);
        Task<long> CreateLineaProduccion(LineaProduccionModel model);
        Task<long> DeleteLineaProduccionxId(long id);
        Task<long> ActivarLineaProduccionxId(long id);
        Task<long> DesactivarLineaProduccionxId(long id);
    }
}
