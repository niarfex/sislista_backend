using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface ICondicionJuridicaRepository
    {
        Task<List<CondicionJuridicaEntity>> GetAll(ParamBusqueda param);
        Task<CondicionJuridicaEntity> getCondicionJuridica();
        Task<CondicionJuridicaEntity> createCondicionJuridica();
        Task<CondicionJuridicaEntity> updateCondicionJuridica();
        Task<bool> deleteCondicionJuridica();
    }
}
