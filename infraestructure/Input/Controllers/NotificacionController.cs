using Application.Input;
using Application.Service;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/notificacion")]
    [ApiController]
    public class NotificacionController : ControllerBase
    {
        private readonly INotificacionService _notificacionService;
        private readonly IMapper _mapper;

        public NotificacionController(INotificacionService notificacionService, IMapper mapper)
        {
            _notificacionService = notificacionService;
            _mapper = mapper;
        }
    }
}
