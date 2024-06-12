using Domain.Model;

namespace Application.Input
{
    public interface IPanelRegistroService
    {
        Task<List<PanelRegistroModel>> GetAll(ParamBusqueda param);
    }
}
