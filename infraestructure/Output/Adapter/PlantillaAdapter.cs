using Application.Output;
using AutoMapper;
using Domain.Model;
using Infra.MarcoLista.Output.Repository;

namespace infraestructure.Output.Adapter
{
    public class PlantillaAdapter : IPlantillaPort
    {
        private readonly IPlantillaRepository _plantillaRepository;
        private readonly IMapper _mapper;
        public PlantillaAdapter(IPlantillaRepository plantillaRepository, IMapper mapper)
        {
            _plantillaRepository = plantillaRepository;
            _mapper = mapper;
        }

        public async Task<List<PlantillaModel>> GetAll(string param)
        {
            var plantillaEntity = await _plantillaRepository.GetAll(param);

            if (plantillaEntity != null)
            {
                return _mapper.Map<List<PlantillaModel>>(plantillaEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<PlantillaModel> GetPlantillaxId(long id)
        {
            var plantillaEntity = await _plantillaRepository.GetPlantillaxId(id);

            if (plantillaEntity != null)
            {
                return _mapper.Map<PlantillaModel>(plantillaEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<long> CreatePlantilla(PlantillaModel model)
        {
            var plantillaEntity = await _plantillaRepository.CreatePlantilla(model);

            if (plantillaEntity != null)
            {
                return plantillaEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> DeletePlantillaxId(long id)
        {
            var plantillaEntity = await _plantillaRepository.DeletePlantillaxId(id);

            if (plantillaEntity != null)
            {
                return plantillaEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> ActivarPlantillaxId(long id)
        {
            var plantillaEntity = await _plantillaRepository.ActivarPlantillaxId(id);

            if (plantillaEntity != null)
            {
                return plantillaEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> DesactivarPlantillaxId(long id)
        {
            var plantillaEntity = await _plantillaRepository.DesactivarPlantillaxId(id);

            if (plantillaEntity != null)
            {
                return plantillaEntity;
            }
            else
            {
                return 0;
            }
        }
    }
}
