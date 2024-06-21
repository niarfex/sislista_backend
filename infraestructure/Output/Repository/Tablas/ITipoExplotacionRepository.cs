using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface ITipoExplotacionRepository
    {
        Task<List<TipoExplotacionEntity>> GetAll(string param);
        Task<TipoExplotacionEntity> GetTipoExplotacionxId(long id);
        Task<long> CreateTipoExplotacion(TipoExplotacionModel model);
        Task<long> DeleteTipoExplotacionxId(long id);
        Task<long> ActivarTipoExplotacionxId(long id);
        Task<long> DesactivarTipoExplotacionxId(long id);
    }
}
