using Domain.Model;

namespace Application.Input
{
    public interface IGeneralService
    {
        Task<List<SelectTipoModel>> GetDepartamentos();
        Task<List<SelectTipoModel>> GetTipoOrganizacion();
        Task<List<SelectTipoModel>> GetCondicionJuridicas();
        Task<List<SelectTipoModel>> GetCondicionJuridicaOtros();
        Task<List<SelectTipoModel>> GetTipoExplotacion();
        Task<List<SelectTipoModel>> GetTipoDocumento();
        Task<List<SelectTipoModel>> GetTipoDocumentoPN();
        Task<List<SelectTipoModel>> GetOrganizaciones();
        Task<List<SelectTipoModel>> GetPerfiles();
    }
}
