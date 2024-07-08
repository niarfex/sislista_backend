using Domain.Model;

namespace Application.Input
{
    public interface INotificacionService
    {
        Task<List<NotificacionModel>> GetAll(string param);
        Task<NotificacionModel> GetNotificacionxId(long id);
        Task<long> CreateNotificacion(NotificacionModel model);
        Task<long> DeleteNotificacionxId(long id);
        Task<long> NotificarNotificacionxId(long id);
    }
}
