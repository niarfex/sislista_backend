using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IOrganizacionRepository
    {
        Task<List<OrganizacionEntity>> GetAll(string param);
        Task<OrganizacionEntity> GetOrganizacionxId(long id);
        Task<long> CreateOrganizacion(OrganizacionModel model);
        Task<long> DeleteOrganizacionxId(long id);
        Task<long> ActivarOrganizacionxId(long id);
        Task<long> DesactivarOrganizacionxId(long id);
    }
}
