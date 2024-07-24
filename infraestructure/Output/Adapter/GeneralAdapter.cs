using Application.Output;
using Infra.MarcoLista.Output.Repository;
using Domain.Model;
using AutoMapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
//using Infra.ProductorAgrario.Mapper;
#nullable disable
namespace Infra.MarcoLista.Output.Adapter
{
    public class GeneralAdapter : IGeneralPort
    {
        private readonly IGeneralRepository _generalRepository;
        private readonly IMapper _mapper;
        public GeneralAdapter(IGeneralRepository generalRepository, IMapper mapper)
        {
            _generalRepository = generalRepository;
            _mapper = mapper;
        }
        public async Task<List<CultivoModel>> GetAllCultivos()
        {
            var cultivoEntity = await _generalRepository.GetAllCultivos();

            if (cultivoEntity != null)
            {
                return cultivoEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<UbigeoModel>> GetAllUbigeo(int idTipo, string idUbigeo)
        {
            var ubigeoEntity = await _generalRepository.GetAllUbigeo(idTipo, idUbigeo);

            if (ubigeoEntity != null)
            {
                return ubigeoEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<UbigeoModel>> GetDepartamentos(int idTipo, string idUbigeo)
        {
            var ubigeoEntity = await _generalRepository.GetDepartamentos(idTipo, idUbigeo);

            if (ubigeoEntity != null)
            {
                return ubigeoEntity;
            }
            else
            {
                return null;
            }
        }       
        public async Task<List<UbigeoModel>> GetProvincias(int idTipo, string idUbigeo)
        {
            var ubigeoEntity = await _generalRepository.GetProvincias(idTipo, idUbigeo);

            if (ubigeoEntity != null)
            {
                return ubigeoEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<UbigeoModel>> GetDistritos(int idTipo, string idUbigeo)
        {
            var ubigeoEntity = await _generalRepository.GetDistritos(idTipo, idUbigeo);

            if (ubigeoEntity != null)
            {
                return ubigeoEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<TipoOrganizacionModel>> GetTipoOrganizacion()
        {
            var tipoorganizacionEntity = await _generalRepository.GetTipoOrganizacion();

            if (tipoorganizacionEntity != null)
            {
                return _mapper.Map<List<TipoOrganizacionModel>>(tipoorganizacionEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<TipoDocumentoModel>> GetTipoDocumento()
        {
            var tipodocumentoEntity = await _generalRepository.GetTipoDocumento();

            if (tipodocumentoEntity != null)
            {
                return _mapper.Map<List<TipoDocumentoModel>>(tipodocumentoEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<PersonaModel> GetPersonaxId(long id)
        {
            var personaEntity = await _generalRepository.GetPersonaxId(id);

            if (personaEntity != null)
            {
                return _mapper.Map<PersonaModel>(personaEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<PerfilModel>> GetPerfiles()
        {
            var perfilEntity = await _generalRepository.GetPerfiles();

            if (perfilEntity != null)
            {
                return _mapper.Map<List<PerfilModel>>(perfilEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<PerfilModel>> GetPerfilesTodos()
        {
            var perfilEntity = await _generalRepository.GetPerfilesTodos();

            if (perfilEntity != null)
            {
                return _mapper.Map<List<PerfilModel>>(perfilEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<AnioModel>> GetPeriodos()
        {
            var objetoEntity = await _generalRepository.GetPeriodos();

            if (objetoEntity != null)
            {
                return _mapper.Map<List<AnioModel>>(objetoEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<PlantillaModel>> GetPlantillasActivas()
        {
            var objetoEntity = await _generalRepository.GetPlantillasActivas();

            if (objetoEntity != null)
            {
                return _mapper.Map<List<PlantillaModel>>(objetoEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<FrecuenciaModel>> GetFrecuencias()
        {
            var objetoEntity = await _generalRepository.GetFrecuencias();

            if (objetoEntity != null)
            {
                return _mapper.Map<List<FrecuenciaModel>>(objetoEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<PanelRegistroModel>> GetProgramacionesVigentes()
        {
            var objetoEntity = await _generalRepository.GetProgramacionesVigentes();

            if (objetoEntity != null)
            {
                return _mapper.Map<List<PanelRegistroModel>>(objetoEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<EtapaModel>> GetEtapas()
        {
            var objetoEntity = await _generalRepository.GetEtapas();

            if (objetoEntity != null)
            {
                return _mapper.Map<List<EtapaModel>>(objetoEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<TenenciaModel>> GetTenencias()
        {
            var objetoEntity = await _generalRepository.GetTenencias();

            if (objetoEntity != null)
            {
                return _mapper.Map<List<TenenciaModel>>(objetoEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<UsoTierraModel>> GetUsoTierras()
        {
            var objetoEntity = await _generalRepository.GetUsoTierras();

            if (objetoEntity != null)
            {
                return _mapper.Map<List<UsoTierraModel>>(objetoEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<CultivoModel>> GetCultivos()
        {
            var objetoEntity = await _generalRepository.GetAllCultivos();

            if (objetoEntity != null)
            {
                return _mapper.Map<List<CultivoModel>>(objetoEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<UsoNoAgricolaModel>> GetUsoNoAgricolas()
        {
            var objetoEntity = await _generalRepository.GetUsoNoAgricolas();

            if (objetoEntity != null)
            {
                return _mapper.Map<List<UsoNoAgricolaModel>>(objetoEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<EstadoModel>> GetEstadoEntrevista()
        {
            var objetoEntity = await _generalRepository.GetEstadoEntrevista();

            if (objetoEntity != null)
            {
                return _mapper.Map<List<EstadoModel>>(objetoEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<TipoInformacionModel>> GetTipoInformacion()
        {
            var objetoEntity = await _generalRepository.GetTipoInformacion();

            if (objetoEntity != null)
            {
                return _mapper.Map<List<TipoInformacionModel>>(objetoEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<LineaProduccionModel>> GetLineaProduccion()
        {
            var objetoEntity = await _generalRepository.GetLineaProduccion();

            if (objetoEntity != null)
            {
                return _mapper.Map<List<LineaProduccionModel>>(objetoEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<EspecieModel>> GetEspecies()
        {
            var objetoEntity = await _generalRepository.GetEspecies();

            if (objetoEntity != null)
            {
                return _mapper.Map<List<EspecieModel>>(objetoEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<SeccionModel>> GetSecciones()
        {
            var objetoEntity = await _generalRepository.GetSecciones();

            if (objetoEntity != null)
            {
                return _mapper.Map<List<SeccionModel>>(objetoEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<EstadoModel>> GetEstadosCuestionario()
        {
            var objetoEntity = await _generalRepository.GetEstadosCuestionario();

            if (objetoEntity != null)
            {
                return _mapper.Map<List<EstadoModel>>(objetoEntity);
            }
            else
            {
                return null;
            }
        }
    }
}
