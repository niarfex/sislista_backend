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
        public async Task<List<TipoExplotacionModel>> GetAll(string param)
        {
            var tipoexplotacions = await _tipoexplotacionPort.GetAll(param);           
            if (tipoexplotacions == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }         
            return tipoexplotacions;
        }
        public async Task<TipoExplotacionModel> GetTipoExplotacionxId(long id)
        {
            var tipoexplotacion = await _tipoexplotacionPort.GetTipoExplotacionxId(id);

            if (tipoexplotacion == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return tipoexplotacion;
        }
        public async Task<long> CreateTipoExplotacion(TipoExplotacionModel model)
        {
            var id = await _tipoexplotacionPort.CreateTipoExplotacion(model);
            if (id == null)
            {
                throw new NotDataFoundException("No se registraron los datos");

            }
            return id;
        }
        public async Task<long> DeleteTipoExplotacionxId(long id)
        {
            var tipoexplotacion = await _tipoexplotacionPort.DeleteTipoExplotacionxId(id);

            if (tipoexplotacion == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return tipoexplotacion;
        }
        public async Task<long> ActivarTipoExplotacionxId(long id)
        {
            var tipoexplotacion = await _tipoexplotacionPort.ActivarTipoExplotacionxId(id);

            if (tipoexplotacion == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return tipoexplotacion;
        }
        public async Task<long> DesactivarTipoExplotacionxId(long id)
        {
            var tipoexplotacion = await _tipoexplotacionPort.DesactivarTipoExplotacionxId(id);

            if (tipoexplotacion == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return tipoexplotacion;
        }

    }
}
