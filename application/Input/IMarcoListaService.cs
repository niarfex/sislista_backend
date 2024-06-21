using Domain.Model;

namespace Application.Input
{
    public interface IMarcoListaService
    {
        Task<List<MarcoListaModel>> GetAll(string param);
        Task<MarcoListaModel> GetMarcoListaxId(long id);
        Task<long> CreateMarcoLista(MarcoListaModel model);
        Task<long> DeleteMarcoListaxId(long id);
        Task<long> ActivarMarcoListaxId(long id);
        Task<long> DesactivarMarcoListaxId(long id);
    }
}
