using Application.Output;
using AutoMapper;
using Domain.Model;
using Infra.MarcoLista.Output.Repository;

namespace Infra.MarcoLista.Output.Adapter
{
    public class GestionRegistroAdapter : IGestionRegistroPort
    {
        private readonly IGestionRegistroRepository _gestionregistroRepository;
        private readonly IMapper _mapper;
        public GestionRegistroAdapter(IGestionRegistroRepository gestionregistroRepository, IMapper mapper)
        {
            _gestionregistroRepository = gestionregistroRepository;
            _mapper = mapper;
        }
        public async Task<List<GestionRegistroModel>> GetAll(string param, string uuid)
        {
            var gestionregistroEntity = await _gestionregistroRepository.GetAll(param,uuid);

            if (gestionregistroEntity != null)
            {
                return gestionregistroEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<GestionRegistroModel> GetGestionRegistroxUUID(string uuid)
        {
            var gestionregistroEntity = await _gestionregistroRepository.GetGestionRegistroxUUID(uuid);

            if (gestionregistroEntity != null)
            {
                return _mapper.Map<GestionRegistroModel>(gestionregistroEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<GestionRegistroModel> GetUUIDCuestionario(string numDoc, long idPeriodo)
        {
            var gestionregistroEntity = await _gestionregistroRepository.GetUUIDCuestionario(numDoc,idPeriodo);

            if (gestionregistroEntity != null)
            {
                return gestionregistroEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<FundoModel>> GetFundosCuestionario(string uuid)
        {
            var gestionregistroEntity = await _gestionregistroRepository.GetFundosCuestionario(uuid);

            if (gestionregistroEntity != null)
            {
                return gestionregistroEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<InformanteModel>> GetInformantesCuestionario(string uuid)
        {
            var gestionregistroEntity = await _gestionregistroRepository.GetInformantesCuestionario(uuid);

            if (gestionregistroEntity != null)
            {
                return gestionregistroEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<PecuarioModel>> GetPecuariosCuestionario(string uuid)
        {
            var gestionregistroEntity = await _gestionregistroRepository.GetPecuariosCuestionario(uuid);

            if (gestionregistroEntity != null)
            {
                return gestionregistroEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<TrazabilidadModel>> GetObservacionesCuestionario(string uuid)
        {
            var gestionregistroEntity = await _gestionregistroRepository.GetObservacionesCuestionario(uuid);

            if (gestionregistroEntity != null)
            {
                return gestionregistroEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<ArchivoModel>> GetArchivosCuestionario(string uuid)
        {
            var gestionregistroEntity = await _gestionregistroRepository.GetArchivosCuestionario(uuid);

            if (gestionregistroEntity != null)
            {
                return gestionregistroEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<string> CreateCuestionario(GestionRegistroModel model)
        {
            var gestionregistroEntity = await _gestionregistroRepository.CreateCuestionario(model);

            if (gestionregistroEntity != null)
            {
                return gestionregistroEntity;
            }
            else
            {
                return "";
            }
        }
        public async Task<string> DesaprobarCuestionario(GestionRegistroModel model)
        {
            var gestionregistroEntity = await _gestionregistroRepository.DesaprobarCuestionario(model);

            if (gestionregistroEntity != null)
            {
                return gestionregistroEntity;
            }
            else
            {
                return "";
            }
        }
        public async Task<string> InvalidarCuestionario(GestionRegistroModel model)
        {
            var gestionregistroEntity = await _gestionregistroRepository.InvalidarCuestionario(model);

            if (gestionregistroEntity != null)
            {
                return gestionregistroEntity;
            }
            else
            {
                return "";
            }
        }
        public async Task<string> AprobarCuestionarioxUUID(string uuid)
        {
            var gestionregistroEntity = await _gestionregistroRepository.AprobarCuestionarioxUUID(uuid);

            if (gestionregistroEntity != null)
            {
                return gestionregistroEntity;
            }
            else
            {
                return "";
            }
        }
        public async Task<string> RatificarCuestionarioxUUID(string uuid)
        {
            var gestionregistroEntity = await _gestionregistroRepository.RatificarCuestionarioxUUID(uuid);

            if (gestionregistroEntity != null)
            {
                return gestionregistroEntity;
            }
            else
            {
                return "";
            }
        }
        public async Task<string> DerivarCuestionarioxUUID(string uuid)
        {
            var gestionregistroEntity = await _gestionregistroRepository.DerivarCuestionarioxUUID(uuid);

            if (gestionregistroEntity != null)
            {
                return gestionregistroEntity;
            }
            else
            {
                return "";
            }
        }
        public async Task<string> ValidarCuestionarioxUUID(string uuid)
        {
            var gestionregistroEntity = await _gestionregistroRepository.ValidarCuestionarioxUUID(uuid);

            if (gestionregistroEntity != null)
            {
                return gestionregistroEntity;
            }
            else
            {
                return "";
            }
        }
        public async Task<string> DescartarCuestionarioxUUID(string uuid)
        {
            var gestionregistroEntity = await _gestionregistroRepository.DescartarCuestionarioxUUID(uuid);

            if (gestionregistroEntity != null)
            {
                return gestionregistroEntity;
            }
            else
            {
                return "";
            }
        }
    }
}
