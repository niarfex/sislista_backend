using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface INotificacionRepository
    {
        Task<List<NotificacionEntity>> GetAll(ParamBusqueda param);

        Task<NotificacionEntity> getNotificacion();

        Task<NotificacionEntity> createNotificacion();

        Task<NotificacionEntity> updateNotificacion();

        Task<bool> deleteNotificacion();
    }
}
