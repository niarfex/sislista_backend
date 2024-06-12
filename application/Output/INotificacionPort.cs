using Domain.Model;

namespace Application.Output
{
    public interface INotificacionPort
    {
        Task<List<NotificacionModel>> GetAll(ParamBusqueda param);
    }
}
