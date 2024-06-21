using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IGeneralRepository
    {
        Task<List<UbigeoModel>> GetDepartamentos(int idTipo, string idUbigeo);
        Task<List<TipoOrganizacionEntity>> GetTipoOrganizacion();
        Task<List<TipoDocumentoEntity>> GetTipoDocumento();
        Task<PersonaEntity> GetPersonaxId(long id);
        Task<List<PerfilEntity>> GetPerfiles();
    }
}
