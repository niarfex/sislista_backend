using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface ILineaProduccionRepository
    {
        Task<List<LineaProduccionEntity>> GetAll(string param);
        Task<LineaProduccionEntity> GetLineaProduccionxId(long id);
        Task<long> CreateLineaProduccion(LineaProduccionModel model);
        Task<long> DeleteLineaProduccionxId(long id);
        Task<long> ActivarLineaProduccionxId(long id);
        Task<long> DesactivarLineaProduccionxId(long id);
    }
}
