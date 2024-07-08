using Domain.Model;

namespace Application.Input
{
    public interface IPanelRegistroService
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
