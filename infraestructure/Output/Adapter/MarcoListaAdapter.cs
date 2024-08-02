using Application.Output;
using AutoMapper;
using Domain.Model;
using Infra.MarcoLista.Output.Repository;

namespace Infra.MarcoLista.Output.Adapter
{
    public class MarcoListaAdapter : IMarcoListaPort
    {
        private readonly IMarcoListaRepository _marcolistaRepository;
        private readonly IMapper _mapper;
        public MarcoListaAdapter(IMarcoListaRepository marcolistaRepository, IMapper mapper)
        {
            _marcolistaRepository = marcolistaRepository;
            _mapper = mapper;
        }

        public async Task<List<MarcoListaModel>> GetAll(string param)
        {
            var marcolistaEntity = await _marcolistaRepository.GetAll(param);

            if (marcolistaEntity != null)
            {
                return marcolistaEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<MarcoListaModel>> GetMarcoListasinAginarxPerfil(long idPerfil)
        {
            var marcolistaEntity = await _marcolistaRepository.GetMarcoListasinAginarxPerfil(idPerfil);

            if (marcolistaEntity != null)
            {
                return marcolistaEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<MarcoListaModel> GetMarcoListaxId(long id)
        {
            var marcolistaEntity = await _marcolistaRepository.GetMarcoListaxId(id);

            if (marcolistaEntity != null)
            {
                return marcolistaEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<long> CreateMarcoLista(MarcoListaModel model)
        {
            var marcolistaEntity = await _marcolistaRepository.CreateMarcoLista(model);

            if (marcolistaEntity != null)
            {
                return marcolistaEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> DeleteMarcoListaxId(long id)
        {
            var marcolistaEntity = await _marcolistaRepository.DeleteMarcoListaxId(id);

            if (marcolistaEntity != null)
            {
                return marcolistaEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> ActivarMarcoListaxId(long id)
        {
            var marcolistaEntity = await _marcolistaRepository.ActivarMarcoListaxId(id);

            if (marcolistaEntity != null)
            {
                return marcolistaEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> DesactivarMarcoListaxId(long id)
        {
            var marcolistaEntity = await _marcolistaRepository.DesactivarMarcoListaxId(id);

            if (marcolistaEntity != null)
            {
                return marcolistaEntity;
            }
            else
            {
                return 0;
            }
        }
    }
}
