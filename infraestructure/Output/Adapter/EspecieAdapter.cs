using Application.Output;
using AutoMapper;
using Domain.Model;
using Infra.MarcoLista.Output.Repository;

namespace infraestructure.Output.Adapter
{
    public class EspecieAdapter : IEspeciePort
    {
        private readonly IEspecieRepository _especieRepository;
        private readonly IMapper _mapper;
        public EspecieAdapter(IEspecieRepository especieRepository, IMapper mapper)
        {
            _especieRepository = especieRepository;
            _mapper = mapper;
        }

        public async Task<List<EspecieModel>> GetAll(string param)
        {
            var especieEntity = await _especieRepository.GetAll(param);

            if (especieEntity != null)
            {
                return _mapper.Map<List<EspecieModel>>(especieEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<EspecieModel> GetEspeciexId(long id)
        {
            var especieEntity = await _especieRepository.GetEspeciexId(id);

            if (especieEntity != null)
            {
                return _mapper.Map<EspecieModel>(especieEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<long> CreateEspecie(EspecieModel model)
        {
            var especieEntity = await _especieRepository.CreateEspecie(model);

            if (especieEntity != null)
            {
                return especieEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> DeleteEspeciexId(long id)
        {
            var especieEntity = await _especieRepository.DeleteEspeciexId(id);

            if (especieEntity != null)
            {
                return especieEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> ActivarEspeciexId(long id)
        {
            var especieEntity = await _especieRepository.ActivarEspeciexId(id);

            if (especieEntity != null)
            {
                return especieEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> DesactivarEspeciexId(long id)
        {
            var especieEntity = await _especieRepository.DesactivarEspeciexId(id);

            if (especieEntity != null)
            {
                return especieEntity;
            }
            else
            {
                return 0;
            }
        }
    }
}
