using Domain.Model;

namespace Application.Input
{
    public interface IPlantillaService
    {
        Task<List<PlantillaModel>> GetAll(ParamBusqueda param);
    }
}
