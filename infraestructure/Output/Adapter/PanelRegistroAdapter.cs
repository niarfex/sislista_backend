using Application.Output;
using AutoMapper;
using Domain.Model;
using Infra.MarcoLista.Output.Repository;

namespace infraestructure.Output.Adapter
{
    public class PanelRegistroAdapter : IPanelRegistroPort
    {
        private readonly IPanelRegistroRepository _panelregistroRepository;
        private readonly IMapper _mapper;
        public PanelRegistroAdapter(IPanelRegistroRepository panelregistroRepository, IMapper mapper)
        {
            _panelregistroRepository = panelregistroRepository;
            _mapper = mapper;
        }

        public async Task<List<PanelRegistroModel>> GetAll(string param)
        {
            var panelregistroEntity = await _panelregistroRepository.GetAll(param);

            if (panelregistroEntity != null)
            {
                return _mapper.Map<List<PanelRegistroModel>>(panelregistroEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<PanelRegistroModel> GetPanelRegistroxId(long id)
        {
            var panelregistroEntity = await _panelregistroRepository.GetPanelRegistroxId(id);

            if (panelregistroEntity != null)
            {
                return _mapper.Map<PanelRegistroModel>(panelregistroEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<long> CreatePanelRegistro(PanelRegistroModel model)
        {
            var panelregistroEntity = await _panelregistroRepository.CreatePanelRegistro(model);

            if (panelregistroEntity != null)
            {
                return panelregistroEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> DeletePanelRegistroxId(long id)
        {
            var panelregistroEntity = await _panelregistroRepository.DeletePanelRegistroxId(id);

            if (panelregistroEntity != null)
            {
                return panelregistroEntity;
            }
            else
            {
                return 0;
            }
        }
    }
}
