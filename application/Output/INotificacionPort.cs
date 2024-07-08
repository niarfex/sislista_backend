using Domain.Model;

namespace Application.Output
{
    public interface INotificacionPort
    {
        Task<List<NotificacionModel>> GetAll(string param);
        Task<NotificacionModel> GetNotificacionxId(long id);
        Task<long> CreateNotificacion(NotificacionModel model);
        Task<long> DeleteNotificacionxId(long id);
        Task<long> NotificarNotificacionxId(long id);
    }
}
