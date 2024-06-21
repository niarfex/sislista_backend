using Domain.Model;

namespace Application.Input
{
    public interface ITipoExplotacionService
    {
        Task<List<TipoExplotacionModel>> GetAll(string param);
        Task<TipoExplotacionModel> GetTipoExplotacionxId(long id);
        Task<long> CreateTipoExplotacion(TipoExplotacionModel model);
        Task<long> DeleteTipoExplotacionxId(long id);
        Task<long> ActivarTipoExplotacionxId(long id);
        Task<long> DesactivarTipoExplotacionxId(long id);
    }
}
