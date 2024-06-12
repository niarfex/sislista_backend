using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class CultivoService : ICultivoService
    {
        private readonly ICultivoPort _cultivoPort;

        public CultivoService(ICultivoPort cultivoPort)
        {
            _cultivoPort = cultivoPort ?? throw new ArgumentNullException(nameof(cultivoPort));
        }
        public async Task<List<CultivoModel>> GetAll(ParamBusqueda param)
        {
            var cultivos = await _cultivoPort.GetAll(param);
            if (cultivos == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }

            return cultivos;
        }
    }
}
