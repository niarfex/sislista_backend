using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class PanelRegistroService : IPanelRegistroService
    {
        private readonly IPanelRegistroPort _panelregistroPort;

        public PanelRegistroService(IPanelRegistroPort panelregistroPort)
        {
            _panelregistroPort = panelregistroPort ?? throw new ArgumentNullException(nameof(panelregistroPort));
        }
        public async Task<List<PanelRegistroModel>> GetAll(ParamBusqueda param)
        {
            var panelregistros = await _panelregistroPort.GetAll(param);
            if (panelregistros == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }

            return panelregistros;
        }
    }
}
