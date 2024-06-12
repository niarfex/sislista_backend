using Application.Input;
using Application.Service;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/tipoexplotacion")]
    [ApiController]
    public class TipoExplotacionController : ControllerBase
    {
        private readonly ITipoExplotacionService _tipoexplotacionService;
        private readonly IMapper _mapper;

        public TipoExplotacionController(ITipoExplotacionService tipoexplotacionService, IMapper mapper)
        {
            _tipoexplotacionService = tipoexplotacionService;
            _mapper = mapper;
        }
    }
}
