using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface ITipoExplotacionRepository
    {
        Task<List<TipoExplotacionEntity>> GetAll(ParamBusqueda param);
        Task<TipoExplotacionEntity> getTipoExplotacion();
        Task<TipoExplotacionEntity> createTipoExplotacion();
        Task<TipoExplotacionEntity> updateTipoExplotacion();        
        Task<bool> deleteTipoExplotacion();
    }
}
