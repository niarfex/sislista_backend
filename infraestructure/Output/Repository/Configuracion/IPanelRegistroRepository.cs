using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IPanelRegistroRepository
    {
        Task<List<PanelRegistroEntity>> GetAll(ParamBusqueda param);
        Task<PanelRegistroEntity> getPanelRegistro();
        Task<PanelRegistroEntity> createPanelRegistro();
        Task<PanelRegistroEntity> updatePanelRegistro();
        Task<bool> deletePanelRegistro();
    }
}
