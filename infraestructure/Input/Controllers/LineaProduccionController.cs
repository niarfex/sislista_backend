using Application.Input;
using Application.Service;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/lineaproduccion")]
    [ApiController]
    public class LineaProduccionController : ControllerBase
    {
        private readonly ILineaProduccionService _lineaproduccionService;
        private readonly IMapper _mapper;

        public LineaProduccionController(ILineaProduccionService lineaproduccionService, IMapper mapper)
        {
            _lineaproduccionService = lineaproduccionService;
            _mapper = mapper;
        }
    }
}
