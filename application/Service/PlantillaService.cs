using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class PlantillaService : IPlantillaService
    {
        private readonly IPlantillaPort _plantillaPort;

        public PlantillaService(IPlantillaPort plantillaPort)
        {
            _plantillaPort = plantillaPort ?? throw new ArgumentNullException(nameof(plantillaPort));
        }
        public async Task<List<PlantillaModel>> GetAll(ParamBusqueda param)
        {
            var plantillas = await _plantillaPort.GetAll(param);
            if (plantillas == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }

            return plantillas;
        }
    
    }
}
