using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface ILineaProduccionRepository
    {
        Task<List<LineaProduccionEntity>> GetAll(ParamBusqueda param);
        Task<LineaProduccionEntity> getLineaProduccion();
        Task<LineaProduccionEntity> createLineaProduccion();
        Task<LineaProduccionEntity> updateLineaProduccion();        
        Task<bool> deleteLineaProduccion();
    }
}
