using Application.Input;
using Application.Service;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Infra.MarcoLista.Input.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/ubigeo")]
    [ApiController]
    public class UbigeoController : ControllerBase
    {
        private readonly IGeneralService _generalService;
        private readonly IMapper _mapper;

        public UbigeoController(IGeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ResponseModel> GetAll(string param = "")
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var ubigeos = await _generalService.GetAllUbigeo(param);
                respuesta.success = true;
                if (ubigeos != null)
                {
                    respuesta.data = _mapper.Map<List<UbigeoListDto>>(ubigeos);
                }
                else
                {
                    respuesta.data = null;
                }
                respuesta.message = "Se listan los datos correctamente";
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
        [Route("GetProvincias")]
        public async Task<ResponseModel> GetProvincias(string idUbigeo)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var ubigeos = await _generalService.GetProvincias(idUbigeo);
                respuesta.success = true;
                if (ubigeos != null)
                {
                    respuesta.data = _mapper.Map<List<SelectTipoDto>>(ubigeos);
                }
                else
                {
                    respuesta.data = null;
                }
                respuesta.message = "Se listan los datos correctamente";
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
        [Route("GetDistritos")]
        public async Task<ResponseModel> GetDistritos(string idUbigeo)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var ubigeos = await _generalService.GetDistritos(idUbigeo);
                respuesta.success = true;
                if (ubigeos != null)
                {
                    respuesta.data = _mapper.Map<List<SelectTipoDto>>(ubigeos);
                }
                else
                {
                    respuesta.data = null;
                }
                respuesta.message = "Se listan los datos correctamente";
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
