using Application.Input;
using Application.Service;
using AutoMapper;
using AutoMapper.Internal.Mappers;
using Domain.Exceptions;
using Domain.Model;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;


namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/ubigeo")]
    [ApiController]
    public class UbigeoController : ControllerBase
    {
        private readonly IUbigeoService _ubigeoService;
        private readonly IMapper _mapper;
        //private readonly ConcurrentDictionary<string, object> _response = new ConcurrentDictionary<string, object>();

        public UbigeoController(IUbigeoService ubigeoService, IMapper mapper)
        {
            _ubigeoService = ubigeoService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ResponseModel> GetAll(string param="")
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var ubigeos = await _ubigeoService.GetAll(param);
                respuesta.success = true;
                if (ubigeos != null){
                    respuesta.data = _mapper.Map<List<UbigeoListDto>>(ubigeos);
                }
                else{
                    respuesta.data = null;
                }               
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al consultar el listado";
                return respuesta;
            }
        }
        [HttpGet]
        [Route("GetDepartamentos")]
        public async Task<ResponseModel> GetDepartamentos(string param = "")
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var ubigeos = await _ubigeoService.GetAll(param);
                respuesta.success = true;
                if (ubigeos != null)
                {
                    respuesta.data = _mapper.Map<List<UbigeoListDto>>(ubigeos);
                }
                else
                {
                    respuesta.data = null;
                }
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al consultar el listado";
                return respuesta;
            }
        }
    }
}
