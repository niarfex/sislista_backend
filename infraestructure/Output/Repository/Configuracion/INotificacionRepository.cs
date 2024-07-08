using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface INotificacionRepository
    {
        Task<List<NotificacionEntity>> GetAll(string param);
        Task<NotificacionEntity> GetNotificacionxId(long id);
        Task<long> CreateNotificacion(NotificacionModel model);
        Task<long> DeleteNotificacionxId(long id);
        Task<long> NotificarNotificacionxId(long id);
    }
}
