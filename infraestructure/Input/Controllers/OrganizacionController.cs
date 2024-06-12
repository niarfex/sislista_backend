using Application.Input;
using Application.Service;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/organizacion")]
    [ApiController]
    public class OrganizacionController : ControllerBase
    {
        private readonly IOrganizacionService _organizacionService;
        private readonly IMapper _mapper;

        public OrganizacionController(IOrganizacionService organizacionService, IMapper mapper)
        {
            _organizacionService = organizacionService;
            _mapper = mapper;
        }
    }
}
