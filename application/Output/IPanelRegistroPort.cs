using Domain.Model;

namespace Application.Output
{
    public interface IPanelRegistroPort
    {
        Task<List<PanelRegistroModel>> GetAll(ParamBusqueda param);
    }
}
