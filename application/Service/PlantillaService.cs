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
        public async Task<List<PlantillaModel>> GetAll(string param)
        {
            var plantillas = await _plantillaPort.GetAll(param);
            if (plantillas == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            var query = from o in plantillas               
                        where o.Estado == 0 || o.Estado == 1
                        select new PlantillaModel
                        {
                            Id = o.Id,
                            Plantilla=o.Plantilla,
                            UsuarioCreacion = "",
                            FechaRegistro = o.FechaRegistro,
                            UsuarioActualizacion = o.UsuarioActualizacion,
                            FechaActualizacion = o.FechaActualizacion,               
                            Estado = o.Estado
                        };
            return query.ToList();
        }
        public async Task<PlantillaModel> GetPlantillaxId(long id)
        {
            var plantilla = await _plantillaPort.GetPlantillaxId(id);

            if (plantilla == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return plantilla;
        }
        public async Task<long> CreatePlantilla(PlantillaModel model)
        {
            var id = await _plantillaPort.CreatePlantilla(model);
            if (id == null)
            {
                throw new NotDataFoundException("No se registraron los datos");

            }
            return id;
        }
        public async Task<long> DeletePlantillaxId(long id)
        {
            var plantilla = await _plantillaPort.DeletePlantillaxId(id);

            if (plantilla == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return plantilla;
        }
        public async Task<long> ActivarPlantillaxId(long id)
        {
            var plantilla = await _plantillaPort.ActivarPlantillaxId(id);

            if (plantilla == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return plantilla;
        }
        public async Task<long> DesactivarPlantillaxId(long id)
        {
            var plantilla = await _plantillaPort.DesactivarPlantillaxId(id);

            if (plantilla == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return plantilla;
        }

    }
}
