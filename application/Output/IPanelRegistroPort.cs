using Domain.Model;

namespace Application.Output
{
    public interface IPanelRegistroPort
    {
        Task<List<PanelRegistroModel>> GetAll(string param);
        Task<PanelRegistroModel> GetPanelRegistroxId(long id);
        Task<long> CreatePanelRegistro(PanelRegistroModel model);
        Task<long> DeletePanelRegistroxId(long id);
        Task<long> PublicarPanelRegistroxId(long id);
        Task<long> PausarPanelRegistroxId(long id);
        Task<long> ReiniciarPanelRegistroxId(long id);
    }
}
