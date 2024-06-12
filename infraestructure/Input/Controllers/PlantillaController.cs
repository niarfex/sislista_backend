using Application.Input;
using Application.Service;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/plantilla")]
    [ApiController]
    public class PlantillaController : ControllerBase
    {
        private readonly IPlantillaService _plantillaService;
        private readonly IMapper _mapper;

        public PlantillaController(IPlantillaService plantillaService, IMapper mapper)
        {
            _plantillaService = plantillaService;
            _mapper = mapper;
        }
    }
}
