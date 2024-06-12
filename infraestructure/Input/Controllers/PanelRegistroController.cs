using Application.Input;
using Application.Service;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/panelregistro")]
    [ApiController]
    public class PanelRegistroController : ControllerBase
    {
        private readonly IPanelRegistroService _panelregistroService;
        private readonly IMapper _mapper;

        public PanelRegistroController(IPanelRegistroService panelregistroService, IMapper mapper)
        {
            _panelregistroService = panelregistroService;
            _mapper = mapper;
        }
    }
}
