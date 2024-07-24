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
    }
}
