using Domain.Model;

namespace Application.Output
{
    public interface IMarcoListaPort
    {
        Task<List<MarcoListaModel>> GetAll(string param);
        Task<List<MarcoListaModel>> GetMarcoListasinAginarxPerfil(long idPerfil);
        Task<MarcoListaModel> GetMarcoListaxId(long id);
        Task<long> CreateMarcoLista(MarcoListaModel model);
        Task<long> DeleteMarcoListaxId(long id);
        Task<long> ActivarMarcoListaxId(long id);
        Task<long> DesactivarMarcoListaxId(long id);
    }
}
