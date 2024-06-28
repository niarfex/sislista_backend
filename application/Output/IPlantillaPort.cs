using Domain.Model;

namespace Application.Output
{
    public interface IPlantillaPort
    {
        Task<List<PlantillaModel>> GetAll(string param);
        Task<PlantillaModel> GetPlantillaxId(long id);
        Task<long> CreatePlantilla(PlantillaModel model);
        Task<long> DeletePlantillaxId(long id);
        Task<long> ActivarPlantillaxId(long id);
        Task<long> DesactivarPlantillaxId(long id);
    }
}
