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
        public async Task<List<LineaProduccionModel>> GetAll(string param)
        {
            var lineaproduccions = await _lineaproduccionPort.GetAll(param);          
            if (lineaproduccions == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }          
            return lineaproduccions;
        }
        public async Task<LineaProduccionModel> GetLineaProduccionxId(long id)
        {
            var lineaproduccion = await _lineaproduccionPort.GetLineaProduccionxId(id);

            if (lineaproduccion == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return lineaproduccion;
        }
        public async Task<long> CreateLineaProduccion(LineaProduccionModel model)
        {
            var id = await _lineaproduccionPort.CreateLineaProduccion(model);
            if (id == null)
            {
                throw new NotDataFoundException("No se registraron los datos");

            }
            return id;
        }
        public async Task<long> DeleteLineaProduccionxId(long id)
        {
            var lineaproduccion = await _lineaproduccionPort.DeleteLineaProduccionxId(id);

            if (lineaproduccion == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return lineaproduccion;
        }
        public async Task<long> ActivarLineaProduccionxId(long id)
        {
            var lineaproduccion = await _lineaproduccionPort.ActivarLineaProduccionxId(id);

            if (lineaproduccion == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return lineaproduccion;
        }
        public async Task<long> DesactivarLineaProduccionxId(long id)
        {
            var lineaproduccion = await _lineaproduccionPort.DesactivarLineaProduccionxId(id);

            if (lineaproduccion == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return lineaproduccion;
        }
    }
}
