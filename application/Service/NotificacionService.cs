using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class NotificacionService : INotificacionService
    {
        private readonly INotificacionPort _notificacionPort;
        private readonly IGeneralPort _generalPort;

        public NotificacionService(INotificacionPort notificacionPort
            , IGeneralPort generalPort)
        {
            _notificacionPort = notificacionPort ?? throw new ArgumentNullException(nameof(notificacionPort));
            _generalPort = generalPort ?? throw new ArgumentNullException(nameof(generalPort));
        }
        public async Task<List<NotificacionModel>> GetAll(string param)
        {
            var notificacions = await _notificacionPort.GetAll(param);
            var frecuencia = await _generalPort.GetFrecuencias();
            var perfiles = await _generalPort.GetPerfilesTodos();
            if (notificacions == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            var query = from o in notificacions
                        join t in frecuencia on o.IdFrecuencia equals t.Id
                        join p in perfiles on o.IdPerfil equals p.Id
                        where o.Estado == 0 || o.Estado == 1
                        select new NotificacionModel
                        {
                            Id = o.Id,
                            Asunto = o.Asunto,
                            Frecuencia = t.Anio,
                            UsuariosNotificados = p.Perfil,
                            FechaRegistro = o.FechaRegistro,
                            FechaNotificacion = o.FechaNotificacion,
                            EstadoNotificacion = o.EstadoNotificacion
                        };
            return query.ToList();
        }
        public async Task<NotificacionModel> GetNotificacionxId(long id)
        {
            var notificacion = await _notificacionPort.GetNotificacionxId(id);

            if (notificacion == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return notificacion;
        }
        public async Task<long> CreateNotificacion(NotificacionModel model)
        {
            var id = await _notificacionPort.CreateNotificacion(model);
            if (id == null)
            {
                throw new NotDataFoundException("No se registraron los datos");

            }
            return id;
        }
        public async Task<long> DeleteNotificacionxId(long id)
        {
            var notificacion = await _notificacionPort.DeleteNotificacionxId(id);

            if (notificacion == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return notificacion;
        }        
    }
}
