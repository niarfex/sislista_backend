using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class EspecieService : IEspecieService
    {
        private readonly IEspeciePort _especiePort;

        public EspecieService(IEspeciePort especiePort)
        {
            _especiePort = especiePort ?? throw new ArgumentNullException(nameof(especiePort));
        }
        public async Task<List<EspecieModel>> GetAll(ParamBusqueda param)
        {
            var especies = await _especiePort.GetAll(param);
            if (especies == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }

            return especies;
        }
    }
}
