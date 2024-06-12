using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class LineaProduccionService : ILineaProduccionService
    {
        private readonly ILineaProduccionPort _lineaproduccionPort;

        public LineaProduccionService(ILineaProduccionPort lineaproduccionPort)
        {
            _lineaproduccionPort = lineaproduccionPort ?? throw new ArgumentNullException(nameof(lineaproduccionPort));
        }
        public async Task<List<LineaProduccionModel>> GetAll(ParamBusqueda param)
        {
            var lineaproduccions = await _lineaproduccionPort.GetAll(param);
            if (lineaproduccions == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }

            return lineaproduccions;
        }
    }
}
