using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IPlantillaRepository
    {
        Task<List<PlantillaEntity>> GetAll(string param);
        Task<PlantillaEntity> GetPlantillaxId(long id);
        Task<long> CreatePlantilla(PlantillaModel model);
        Task<long> DeletePlantillaxId(long id);
        Task<long> ActivarPlantillaxId(long id);
        Task<long> DesactivarPlantillaxId(long id);
    }
}
