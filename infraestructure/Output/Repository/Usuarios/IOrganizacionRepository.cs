using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IOrganizacionRepository
    {
        Task<List<OrganizacionEntity>> GetAll(ParamBusqueda param);
        Task<OrganizacionEntity> getOrganizacion();
        Task<OrganizacionEntity> createOrganizacion();
        Task<OrganizacionEntity> updateOrganizacion();
        Task<bool> deleteOrganizacion();
    }
}
