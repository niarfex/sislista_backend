using Domain.Model;

namespace Application.Input
{
    public interface ICondicionJuridicaService
    {
        Task<List<CondicionJuridicaModel>> GetAll(string param);
        Task<CondicionJuridicaModel> GetCondicionJuridicaxId(long id);
        Task<long> CreateCondicionJuridica(CondicionJuridicaModel model);
        Task<long> DeleteCondicionJuridicaxId(long id);
        Task<long> ActivarCondicionJuridicaxId(long id);
        Task<long> DesactivarCondicionJuridicaxId(long id);
    }
}
