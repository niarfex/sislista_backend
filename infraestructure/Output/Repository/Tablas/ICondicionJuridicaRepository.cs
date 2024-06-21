using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface ICondicionJuridicaRepository
    {
        Task<List<CondicionJuridicaEntity>> GetAll(string param);
        Task<CondicionJuridicaEntity> GetCondicionJuridicaxId(long id);
        Task<long> CreateCondicionJuridica(CondicionJuridicaModel model);
        Task<long> DeleteCondicionJuridicaxId(long id);
        Task<long> ActivarCondicionJuridicaxId(long id);
        Task<long> DesactivarCondicionJuridicaxId(long id);
    }
}
