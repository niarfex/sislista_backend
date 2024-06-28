using Domain.Model;

namespace Application.Input
{
    public interface IGeneralService
    {
        Task<List<UbigeoModel>> GetAllUbigeo(string param);
        Task<List<SelectTipoModel>> GetDepartamentos();
        Task<List<SelectTipoModel>> GetDepartamentosMarcoLista();
        Task<List<SelectTipoModel>> GetProvincias(string idUbigeo);
        Task<List<SelectTipoModel>> GetDistritos(string idUbigeo);
        Task<List<SelectTipoModel>> GetTipoOrganizacion();
        Task<List<SelectTipoModel>> GetCondicionJuridicas();
        Task<List<SelectTipoModel>> GetCondicionJuridicaOtros();
        Task<List<SelectTipoModel>> GetTipoExplotacion();
        Task<List<SelectTipoModel>> GetTipoDocumento();
        Task<List<SelectTipoModel>> GetTipoDocumentoPN();
        Task<List<SelectTipoModel>> GetOrganizaciones();
        Task<List<SelectTipoModel>> GetPerfiles();
        Task<List<SelectTipoModel>> GetPerfilesTodos();
        Task<List<SelectTipoModel>> GetPeriodos();
        Task<List<SelectTipoModel>> GetPlantillasActivas();
        Task<List<SelectTipoModel>> GetFrecuencias();
        Task<List<SelectTipoModel>> GetProgramacionesVigentes();
        Task<List<SelectTipoModel>> GetEtapas();
        Task<object> GetDatosRENIEC(string dni);
    }
}
