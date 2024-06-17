using Domain.Model;

namespace Application.Input
{
    public interface IOrganizacionService
    {
        Task<List<OrganizacionModel>> GetAll(string param);
        Task<OrganizacionModel> GetOrganizacionxId(long id);
        Task<long> CreateOrganizacion(OrganizacionModel model);
    }
}
