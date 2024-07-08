using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IGeneralRepository
    {
        Task<List<CultivoModel>> GetAllCultivos();
        Task<List<UbigeoModel>> GetAllUbigeo(int idTipo, string idUbigeo);
        Task<List<UbigeoModel>> GetDepartamentos(int idTipo, string idUbigeo);
        Task<List<UbigeoModel>> GetProvincias(int idTipo, string idUbigeo);
        Task<List<UbigeoModel>> GetDistritos(int idTipo, string idUbigeo);
        Task<List<TipoOrganizacionEntity>> GetTipoOrganizacion();
        Task<List<TipoDocumentoEntity>> GetTipoDocumento();
        Task<PersonaEntity> GetPersonaxId(long id);
        Task<List<PerfilEntity>> GetPerfiles();
        Task<List<PerfilEntity>> GetPerfilesTodos();
        Task<List<AnioEntity>> GetPeriodos();
        Task<List<PlantillaEntity>> GetPlantillasActivas();
        Task<List<FrecuenciaEntity>> GetFrecuencias();
        Task<List<PanelRegistroEntity>> GetProgramacionesVigentes();
        Task<List<EtapaEntity>> GetEtapas();
        Task<List<TenenciaEntity>> GetTenencias();
        Task<List<UsoTierraEntity>> GetUsoTierras();
        Task<List<UsoNoAgricolaEntity>> GetUsoNoAgricolas();
    }
}
