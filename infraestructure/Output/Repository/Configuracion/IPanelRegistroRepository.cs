using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IPanelRegistroRepository
    {
        Task<List<PanelRegistroEntity>> GetAll(string param);
        Task<PanelRegistroEntity> GetPanelRegistroxId(long id);
        Task<long> CreatePanelRegistro(PanelRegistroModel model);
        Task<long> DeletePanelRegistroxId(long id);
        Task<long> PublicarPanelRegistroxId(long id);
        Task<long> PausarPanelRegistroxId(long id);
        Task<long> ReiniciarPanelRegistroxId(long id);
    }
}
