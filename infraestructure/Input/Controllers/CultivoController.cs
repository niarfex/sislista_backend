using Application.Input;
using Application.Service;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/cultivo")]
    [ApiController]
    public class CultivoController : ControllerBase
    {
        private readonly ICultivoService _cultivoService;
        private readonly IMapper _mapper;

        public CultivoController(ICultivoService cultivoService, IMapper mapper)
        {
            _cultivoService = cultivoService;
            _mapper = mapper;
        }
    }
}
