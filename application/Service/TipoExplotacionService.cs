using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class TipoExplotacionService : ITipoExplotacionService
    {
        private readonly ITipoExplotacionPort _tipoexplotacionPort;

        public TipoExplotacionService(ITipoExplotacionPort tipoexplotacionPort)
        {
            _tipoexplotacionPort = tipoexplotacionPort ?? throw new ArgumentNullException(nameof(tipoexplotacionPort));
        }
        public async Task<List<TipoExplotacionModel>> GetAll(ParamBusqueda param)
        {
            var tipoexplotacions = await _tipoexplotacionPort.GetAll(param);
            if (tipoexplotacions == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }

            return tipoexplotacions;
        }
    
    }
}
