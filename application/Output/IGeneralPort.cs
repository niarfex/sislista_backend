using Domain.Model;

namespace Application.Output
{
    public interface IGeneralPort
    {
        Task<List<CultivoModel>> GetAllCultivos();
        Task<List<UbigeoModel>> GetAllUbigeo(int idTipo, string idUbigeo);
        Task<List<UbigeoModel>> GetDepartamentos(int idTipo, string idUbigeo);
        Task<List<UbigeoModel>> GetProvincias(int idTipo, string idUbigeo);
        Task<List<UbigeoModel>> GetDistritos(int idTipo, string idUbigeo);
        Task<List<TipoOrganizacionModel>> GetTipoOrganizacion();
        Task<List<TipoDocumentoModel>> GetTipoDocumento();
        Task<PersonaModel> GetPersonaxId(long id);
        Task<List<PerfilModel>> GetPerfiles();
        Task<List<PerfilModel>> GetPerfilesTodos();
        Task<List<AnioModel>> GetPeriodos();
        Task<List<PlantillaModel>> GetPlantillasActivas();
        Task<List<FrecuenciaModel>> GetFrecuencias();
        Task<List<PanelRegistroModel>> GetProgramacionesVigentes();
        Task<List<EtapaModel>> GetEtapas();
        Task<List<TenenciaModel>> GetTenencias();
        Task<List<UsoTierraModel>> GetUsoTierras();
        Task<List<CultivoModel>> GetCultivos();
        Task<List<UsoNoAgricolaModel>> GetUsoNoAgricolas();
        Task<List<EstadoModel>> GetEstadoEntrevista();
        Task<List<TipoInformacionModel>> GetTipoInformacion();
        Task<List<LineaProduccionModel>> GetLineaProduccion();
        Task<List<EspecieModel>> GetEspecies();
        Task<List<SeccionModel>> GetSecciones();
        Task<List<EstadoModel>> GetEstadosCuestionario();
    }
}
