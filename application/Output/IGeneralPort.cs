using Domain.Model;

namespace Application.Output
{
    public interface IGeneralPort
    {
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
        Task<List<AnioModel>> GetFrecuencias();
        Task<List<PanelRegistroModel>> GetProgramacionesVigentes();
        Task<List<EtapaModel>> GetEtapas();
    }
}
