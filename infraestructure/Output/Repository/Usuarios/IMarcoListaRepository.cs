using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IMarcoListaRepository
    {
        Task<List<MarcoListaEntity>> GetAll(ParamBusqueda param);
        Task<MarcoListaEntity> getMarcoListaxUUID();
        Task<MarcoListaEntity> createMarcoListaxUUID();
        Task<MarcoListaEntity> updateMarcoListaxUUID();
        Task<bool> deleteMarcoListaxUUID();
    }
}
