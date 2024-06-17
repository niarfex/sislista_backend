using Domain.Model;

namespace Application.Input
{
    public interface IGeneralService
    {
        Task<List<SelectTipoModel>> GetDepartamentos();
        Task<List<SelectTipoModel>> GetTipoOrganizacion();
    }
}
