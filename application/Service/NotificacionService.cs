using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class NotificacionService : INotificacionService
    {
        private readonly INotificacionPort _notificacionPort;

        public NotificacionService(INotificacionPort notificacionPort)
        {
            _notificacionPort = notificacionPort ?? throw new ArgumentNullException(nameof(notificacionPort));
        }
        public async Task<List<NotificacionModel>> GetAll(ParamBusqueda param)
        {
            var notificacions = await _notificacionPort.GetAll(param);
            if (notificacions == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }

            return notificacions;
        }
    }
}
