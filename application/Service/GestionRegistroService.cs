using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{ 
    public class GestionRegistroService:IGestionRegistroService
    {
        private readonly IGestionRegistroPort _gestionregistroPort;

        public GestionRegistroService(IGestionRegistroPort gestionregistroPort)
        {
            _gestionregistroPort = gestionregistroPort ?? throw new ArgumentNullException(nameof(gestionregistroPort));
        }
        public async Task<List<GestionRegistroModel>> GetAll(string param, string uuid)
        {
            var gestionregistros = await _gestionregistroPort.GetAll(param,uuid);
            if (gestionregistros == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return gestionregistros;
        }
        public async Task<GestionRegistroModel> GetGestionRegistroxUUID(string uuid)
        {
            var gestionregistro = await _gestionregistroPort.GetGestionRegistroxUUID(uuid);

            if (gestionregistro == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return gestionregistro;
        }
        public async Task<GestionRegistroModel> GetUUIDCuestionario(string numDoc,long  idPeriodo)
        {
            var gestionregistro = await _gestionregistroPort.GetUUIDCuestionario(numDoc,idPeriodo);

            if (gestionregistro == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return gestionregistro;
        }
        public async Task<List<ArchivoModel>> GetArchivosCuestionario(string uuid)
        {
            var gestionregistros = await _gestionregistroPort.GetArchivosCuestionario(uuid);
            if (gestionregistros == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return gestionregistros;
        }
        public async Task<string> CreateCuestionario(GestionRegistroModel model)
        {
            var uuid = await _gestionregistroPort.CreateCuestionario(model);
            if (uuid == null)
            {
                throw new NotDataFoundException("No se registraron los datos");

            }
            return uuid;
        }
    }
}
