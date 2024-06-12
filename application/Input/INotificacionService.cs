using Domain.Model;

namespace Application.Input
{
    public interface INotificacionService
    {
        Task<List<NotificacionModel>> GetAll(ParamBusqueda param);
    }
}
