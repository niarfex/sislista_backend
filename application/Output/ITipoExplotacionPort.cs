using Domain.Model;

namespace Application.Output
{
    public interface ITipoExplotacionPort
    {
        Task<List<TipoExplotacionModel>> GetAll(string param);
        Task<TipoExplotacionModel> GetTipoExplotacionxId(long id);
        Task<long> CreateTipoExplotacion(TipoExplotacionModel model);
        Task<long> DeleteTipoExplotacionxId(long id);
        Task<long> ActivarTipoExplotacionxId(long id);
        Task<long> DesactivarTipoExplotacionxId(long id);
    }
}
