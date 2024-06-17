using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IOrganizacionRepository
    {
        Task<List<OrganizacionEntity>> GetAll(string param);
        Task<OrganizacionEntity> GetOrganizacionxId(long id);
        Task<long> CreateOrganizacion(OrganizacionModel model);
        Task<OrganizacionEntity> updateOrganizacion();
        Task<bool> deleteOrganizacion();
    }
}
