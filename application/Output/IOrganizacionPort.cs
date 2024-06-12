using Domain.Model;

namespace Application.Output
{
    public interface IOrganizacionPort
    {
        Task<List<OrganizacionModel>> GetAll(ParamBusqueda param);
    }
}
