using Application.Output;
using AutoMapper;
using Domain.Model;
using Infra.MarcoLista.Output.Repository;

namespace Infra.MarcoLista.Output.Adapter
{
    public class NotificacionAdapter : INotificacionPort
    {
        private readonly INotificacionRepository _notificacionRepository;
        private readonly IMapper _mapper;
        public NotificacionAdapter(INotificacionRepository notificacionRepository, IMapper mapper)
        {
            _notificacionRepository = notificacionRepository;
            _mapper = mapper;
        }

        public async Task<List<NotificacionModel>> GetAll(string param)
        {
            var notificacionEntity = await _notificacionRepository.GetAll(param);

            if (notificacionEntity != null)
            {
                return _mapper.Map<List<NotificacionModel>>(notificacionEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<NotificacionModel> GetNotificacionxId(long id)
        {
            var notificacionEntity = await _notificacionRepository.GetNotificacionxId(id);

            if (notificacionEntity != null)
            {
                return _mapper.Map<NotificacionModel>(notificacionEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<long> CreateNotificacion(NotificacionModel model)
        {
            var notificacionEntity = await _notificacionRepository.CreateNotificacion(model);

            if (notificacionEntity != null)
            {
                return notificacionEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> DeleteNotificacionxId(long id)
        {
            var notificacionEntity = await _notificacionRepository.DeleteNotificacionxId(id);

            if (notificacionEntity != null)
            {
                return notificacionEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> NotificarNotificacionxId(long id)
        {
            var notificacionEntity = await _notificacionRepository.NotificarNotificacionxId(id);

            if (notificacionEntity != null)
            {
                return notificacionEntity;
            }
            else
            {
                return 0;
            }
        }
    }
}
