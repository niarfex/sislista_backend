using Application.Input;
using Application.Service;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/especie")]
    [ApiController]
    public class EspecieController : ControllerBase
    {
        private readonly IEspecieService _especieService;
        private readonly IMapper _mapper;

        public EspecieController(IEspecieService especieService, IMapper mapper)
        {
            _especieService = especieService;
            _mapper = mapper;
        }
    }
}
