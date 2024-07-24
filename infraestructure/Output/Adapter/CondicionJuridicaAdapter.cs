using Application.Output;
using AutoMapper;
using Domain.Model;
using Infra.MarcoLista.Output.Repository;

namespace Infra.MarcoLista.Output.Adapter
{
    public class CondicionJuridicaAdapter : ICondicionJuridicaPort
    {
        private readonly ICondicionJuridicaRepository _condicionjuridicaRepository;
        private readonly IMapper _mapper;
        public CondicionJuridicaAdapter(ICondicionJuridicaRepository condicionjuridicaRepository, IMapper mapper)
        {
            _condicionjuridicaRepository = condicionjuridicaRepository;
            _mapper = mapper;
        }

        public async Task<List<CondicionJuridicaModel>> GetAll(string param)
        {
            var condicionjuridicaEntity = await _condicionjuridicaRepository.GetAll(param);

            if (condicionjuridicaEntity != null)
            {
                return _mapper.Map<List<CondicionJuridicaModel>>(condicionjuridicaEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<CondicionJuridicaModel> GetCondicionJuridicaxId(long id)
        {
            var condicionjuridicaEntity = await _condicionjuridicaRepository.GetCondicionJuridicaxId(id);

            if (condicionjuridicaEntity != null)
            {
                return _mapper.Map<CondicionJuridicaModel>(condicionjuridicaEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<long> CreateCondicionJuridica(CondicionJuridicaModel model)
        {
            var condicionjuridicaEntity = await _condicionjuridicaRepository.CreateCondicionJuridica(model);

            if (condicionjuridicaEntity != null)
            {
                return condicionjuridicaEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> DeleteCondicionJuridicaxId(long id)
        {
            var condicionjuridicaEntity = await _condicionjuridicaRepository.DeleteCondicionJuridicaxId(id);

            if (condicionjuridicaEntity != null)
            {
                return condicionjuridicaEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> ActivarCondicionJuridicaxId(long id)
        {
            var condicionjuridicaEntity = await _condicionjuridicaRepository.ActivarCondicionJuridicaxId(id);

            if (condicionjuridicaEntity != null)
            {
                return condicionjuridicaEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> DesactivarCondicionJuridicaxId(long id)
        {
            var condicionjuridicaEntity = await _condicionjuridicaRepository.DesactivarCondicionJuridicaxId(id);

            if (condicionjuridicaEntity != null)
            {
                return condicionjuridicaEntity;
            }
            else
            {
                return 0;
            }
        }
    }
}
