using Application.Output;
using AutoMapper;
using Domain.Model;
using Infra.MarcoLista.Output.Repository;

namespace infraestructure.Output.Adapter
{
    public class LineaProduccionAdapter : ILineaProduccionPort
    {
        private readonly ILineaProduccionRepository _lineaproduccionRepository;
        private readonly IMapper _mapper;
        public LineaProduccionAdapter(ILineaProduccionRepository lineaproduccionRepository, IMapper mapper)
        {
            _lineaproduccionRepository = lineaproduccionRepository;
            _mapper = mapper;
        }

        public async Task<List<LineaProduccionModel>> GetAll(string param)
        {
            var lineaproduccionEntity = await _lineaproduccionRepository.GetAll(param);

            if (lineaproduccionEntity != null)
            {
                return _mapper.Map<List<LineaProduccionModel>>(lineaproduccionEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<LineaProduccionModel> GetLineaProduccionxId(long id)
        {
            var lineaproduccionEntity = await _lineaproduccionRepository.GetLineaProduccionxId(id);

            if (lineaproduccionEntity != null)
            {
                return _mapper.Map<LineaProduccionModel>(lineaproduccionEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<long> CreateLineaProduccion(LineaProduccionModel model)
        {
            var lineaproduccionEntity = await _lineaproduccionRepository.CreateLineaProduccion(model);

            if (lineaproduccionEntity != null)
            {
                return lineaproduccionEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> DeleteLineaProduccionxId(long id)
        {
            var lineaproduccionEntity = await _lineaproduccionRepository.DeleteLineaProduccionxId(id);

            if (lineaproduccionEntity != null)
            {
                return lineaproduccionEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> ActivarLineaProduccionxId(long id)
        {
            var lineaproduccionEntity = await _lineaproduccionRepository.ActivarLineaProduccionxId(id);

            if (lineaproduccionEntity != null)
            {
                return lineaproduccionEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> DesactivarLineaProduccionxId(long id)
        {
            var lineaproduccionEntity = await _lineaproduccionRepository.DesactivarLineaProduccionxId(id);

            if (lineaproduccionEntity != null)
            {
                return lineaproduccionEntity;
            }
            else
            {
                return 0;
            }
        }
    }
}
