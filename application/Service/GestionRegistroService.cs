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
        public async Task<List<FundoModel>> GetFundosCuestionario(string uuid)
        {
            var gestionregistros = await _gestionregistroPort.GetFundosCuestionario(uuid);
            if (gestionregistros == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return gestionregistros;
        }
        public async Task<List<InformanteModel>> GetInformantesCuestionario(string uuid)
        {
            var gestionregistros = await _gestionregistroPort.GetInformantesCuestionario(uuid);
            if (gestionregistros == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return gestionregistros;
        }
        public async Task<List<PecuarioModel>> GetPecuariosCuestionario(string uuid)
        {
            var gestionregistros = await _gestionregistroPort.GetPecuariosCuestionario(uuid);
            if (gestionregistros == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return gestionregistros;
        }
        public async Task<List<TrazabilidadModel>> GetObservacionesCuestionario(string uuid)
        {
            var gestionregistros = await _gestionregistroPort.GetObservacionesCuestionario(uuid);
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
        public async Task<string> DesaprobarCuestionario(GestionRegistroModel model)
        {
            var uuid = await _gestionregistroPort.DesaprobarCuestionario(model);
            if (uuid == null)
            {
                throw new NotDataFoundException("No se registraron los datos");

            }
            return uuid;
        }
        public async Task<string> InvalidarCuestionario(GestionRegistroModel model)
        {
            var uuid = await _gestionregistroPort.InvalidarCuestionario(model);
            if (uuid == null)
            {
                throw new NotDataFoundException("No se registraron los datos");

            }
            return uuid;
        }
        public async Task<string> AprobarCuestionarioxUUID(string uuid)
        {
            var usuario = await _gestionregistroPort.AprobarCuestionarioxUUID(uuid);

            if (usuario == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return usuario;
        }
        public async Task<string> RatificarCuestionarioxUUID(string uuid)
        {
            var usuario = await _gestionregistroPort.RatificarCuestionarioxUUID(uuid);

            if (usuario == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return usuario;
        }
        public async Task<string> DerivarCuestionarioxUUID(string uuid)
        {
            var usuario = await _gestionregistroPort.DerivarCuestionarioxUUID(uuid);

            if (usuario == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return usuario;
        }
        public async Task<string> ValidarCuestionarioxUUID(string uuid)
        {
            var usuario = await _gestionregistroPort.ValidarCuestionarioxUUID(uuid);

            if (usuario == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return usuario;
        }
        public async Task<string> DescartarCuestionarioxUUID(string uuid)
        {
            var usuario = await _gestionregistroPort.DescartarCuestionarioxUUID(uuid);

            if (usuario == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return usuario;
        }        
    }
}
