using Domain.Model;

namespace Application.Input
{
    public interface IOrganizacionService
    {
        Task<List<OrganizacionModel>> GetAll(ParamBusqueda param);
    }
}
