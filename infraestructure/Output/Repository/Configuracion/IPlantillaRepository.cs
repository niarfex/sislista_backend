using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IPlantillaRepository
    {
        Task<List<PlantillaEntity>> GetAll(ParamBusqueda param);
        Task<PlantillaEntity> getPlantilla();
        Task<PlantillaEntity> createPlantilla();
        Task<PlantillaEntity> updatePlantilla();
        Task<bool> deletePlantilla();
    }
}
