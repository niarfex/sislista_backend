using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface ICultivoRepository
    {
        Task<List<CultivoEntity>> GetAll(ParamBusqueda param);
        Task<CultivoEntity> getCultivo();
        Task<CultivoEntity> createCultivo();
        Task<CultivoEntity> updateCultivo();
        Task<bool> deleteCultivo();
    }
}
