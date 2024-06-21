using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IMarcoListaRepository
    {
        Task<List<MarcoListaModel>> GetAll(string param);
        Task<MarcoListaModel> GetMarcoListaxId(long id);
        Task<long> CreateMarcoLista(MarcoListaModel model);
        Task<long> DeleteMarcoListaxId(long id);
        Task<long> ActivarMarcoListaxId(long id);
        Task<long> DesactivarMarcoListaxId(long id);
    }
}
