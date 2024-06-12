using Application.Input;
using Application.Service;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/condicionjuridica")]
    [ApiController]
    public class CondicionJuridicaController : ControllerBase
    {
        private readonly ICondicionJuridicaService _condicionjuridicaService;
        private readonly IMapper _mapper;

        public CondicionJuridicaController(ICondicionJuridicaService condicionjuridicaService, IMapper mapper)
        {
            _condicionjuridicaService = condicionjuridicaService;
            _mapper = mapper;
        }
    }
}
