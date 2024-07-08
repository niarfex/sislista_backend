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
        public async Task<List<EspecieModel>> GetAll(string param)
        {
            var especies = await _especiePort.GetAll(param);
            if (especies == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }

            return especies;
        }
        public async Task<EspecieModel> GetEspeciexId(long id)
        {
            var especie = await _especiePort.GetEspeciexId(id);

            if (especie == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return especie;
        }
        public async Task<long> CreateEspecie(EspecieModel model)
        {
            var id = await _especiePort.CreateEspecie(model);
            if (id == null)
            {
                throw new NotDataFoundException("No se registraron los datos");

            }
            return id;
        }
        public async Task<long> DeleteEspeciexId(long id)
        {
            var especie = await _especiePort.DeleteEspeciexId(id);

            if (especie == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return especie;
        }
        public async Task<long> ActivarEspeciexId(long id)
        {
            var especie = await _especiePort.ActivarEspeciexId(id);

            if (especie == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return especie;
        }
        public async Task<long> DesactivarEspeciexId(long id)
        {
            var especie = await _especiePort.DesactivarEspeciexId(id);

            if (especie == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return especie;
        }
    }
}
