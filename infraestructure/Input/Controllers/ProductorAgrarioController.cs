using Application.Input;
using AutoMapper;
using Domain.Exceptions;
using Infra.ProductorAgrario.Input.Dto;


//using Infra.ProductorAgrario.Mapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace infraestructure.Input.Controllers
{
    [Route("/v1/productores-agrarios")]
    [ApiController]
    public class ProductorAgrarioController : ControllerBase
    {

        private readonly IProductorAgrarioService _productorAgrarioService;
        private readonly IMapper _mapper;
        private readonly ConcurrentDictionary<string, object> _response = new ConcurrentDictionary<string, object>();

        public ProductorAgrarioController(IProductorAgrarioService productorAgrarioService, IMapper mapper)
        {
            _productorAgrarioService = productorAgrarioService;
            _mapper = mapper;
        }


        [HttpGet("{nrodoc}")]
        public async Task<IActionResult> getByNrodoc(string nrodoc)
        {
            _response.Clear();

            try
            {
                var productorAgrario = await _productorAgrarioService.getByNrodoc(nrodoc);
                _response["success"] = true;
                _response["data"] = productorAgrario;
                return Ok(_response);

            }
            catch (NotDataFoundException e)
            {
                _response["success"] = false;
                _response["message"] = e.Message;
                return NoContent();
            }
        }
    }
}
