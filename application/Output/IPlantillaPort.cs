using Domain.Model;

namespace Application.Output
{
    public interface IPlantillaPort
    {
        Task<List<PlantillaModel>> GetAll(ParamBusqueda param);
    }
}
