using Application.Output;
using AutoMapper;
using Domain.Model;
using Infra.MarcoLista.Output.Repository;

namespace Infra.MarcoLista.Output.Adapter
{
    public class TipoExplotacionAdapter : ITipoExplotacionPort
    {
        private readonly ITipoExplotacionRepository _tipoexplotacionRepository;
        private readonly IMapper _mapper;
        public TipoExplotacionAdapter(ITipoExplotacionRepository tipoexplotacionRepository, IMapper mapper)
        {
            _tipoexplotacionRepository = tipoexplotacionRepository;
            _mapper = mapper;
        }

        public async Task<List<TipoExplotacionModel>> GetAll(string param)
        {
            var tipoexplotacionEntity = await _tipoexplotacionRepository.GetAll(param);

            if (tipoexplotacionEntity != null)
            {
                return _mapper.Map<List<TipoExplotacionModel>>(tipoexplotacionEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<TipoExplotacionModel> GetTipoExplotacionxId(long id)
        {
            var tipoexplotacionEntity = await _tipoexplotacionRepository.GetTipoExplotacionxId(id);

            if (tipoexplotacionEntity != null)
            {
                return _mapper.Map<TipoExplotacionModel>(tipoexplotacionEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<long> CreateTipoExplotacion(TipoExplotacionModel model)
        {
            var tipoexplotacionEntity = await _tipoexplotacionRepository.CreateTipoExplotacion(model);

            if (tipoexplotacionEntity != null)
            {
                return tipoexplotacionEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> DeleteTipoExplotacionxId(long id)
        {
            var tipoexplotacionEntity = await _tipoexplotacionRepository.DeleteTipoExplotacionxId(id);

            if (tipoexplotacionEntity != null)
            {
                return tipoexplotacionEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> ActivarTipoExplotacionxId(long id)
        {
            var tipoexplotacionEntity = await _tipoexplotacionRepository.ActivarTipoExplotacionxId(id);

            if (tipoexplotacionEntity != null)
            {
                return tipoexplotacionEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> DesactivarTipoExplotacionxId(long id)
        {
            var tipoexplotacionEntity = await _tipoexplotacionRepository.DesactivarTipoExplotacionxId(id);

            if (tipoexplotacionEntity != null)
            {
                return tipoexplotacionEntity;
            }
            else
            {
                return 0;
            }
        }
    }
}
