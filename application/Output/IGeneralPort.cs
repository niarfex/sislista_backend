using Domain.Model;

namespace Application.Output
{
    public interface IGeneralPort
    {
        Task<List<UbigeoModel>> GetDepartamentos(int idTipo, string idUbigeo);
        Task<List<TipoOrganizacionModel>> GetTipoOrganizacion();
    }
}
