using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class MarcoListaService : IMarcoListaService
    {
        private readonly IMarcoListaPort _marcolistaPort;

        public MarcoListaService(IMarcoListaPort marcolistaPort)
        {
            _marcolistaPort = marcolistaPort ?? throw new ArgumentNullException(nameof(marcolistaPort));
        }
        public async Task<List<MarcoListaModel>> GetAll(ParamBusqueda param)
        {
            var marcolistas = await _marcolistaPort.GetAll(param);
            if (marcolistas == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }

            return marcolistas;
        }
    }
}
