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
    [Route("/v1/tipoexplotacion")]
    [ApiController]
    public class TipoExplotacionController : ControllerBase
    {
        private readonly ITipoExplotacionService _tipoexplotacionService;
        private readonly IMapper _mapper;

        public TipoExplotacionController(ITipoExplotacionService tipoexplotacionService, IMapper mapper)
        {
            _tipoexplotacionService = tipoexplotacionService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ResponseModel> GetAll(string param = "")
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var ubigeos = await _tipoexplotacionService.GetAll(param);
                respuesta.success = true;
                if (ubigeos != null)
                {
                    respuesta.data = _mapper.Map<List<TipoExplotacionListDto>>(ubigeos);
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
        [Route("GetTipoExplotacionxId")]
        public async Task<ResponseModel> GetTipoExplotacionxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                TipoExplotacionGetDto objTipoExplotacion = new TipoExplotacionGetDto();
                if (id > 0)
                {
                    objTipoExplotacion = _mapper.Map<TipoExplotacionGetDto>(await _tipoexplotacionService.GetTipoExplotacionxId(id));
                }
                respuesta.success = true;
                respuesta.message = "Se listan los datos correctamente";
                respuesta.data = objTipoExplotacion;
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al consultar el listado";
                return respuesta;
            }
        }
        [HttpPost]
        [Route("CreateTipoExplotacion")]
        public async Task<ResponseModel> CreateTipoExplotacion(TipoExplotacionCreateUpdateDto dto)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var id = await _tipoexplotacionService.CreateTipoExplotacion(_mapper.Map<TipoExplotacionModel>(dto));
                respuesta.success = true;
                respuesta.message = "Se creo el registro correctamente";
                respuesta.data = id;
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
        [Route("DeleteTipoExplotacionxId")]
        public async Task<ResponseModel> DeleteTipoExplotacionxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se eliminó el registro correctamente";
                respuesta.data = await _tipoexplotacionService.DeleteTipoExplotacionxId(id);
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al borrar el registro";
                return respuesta;
            }
        }
        [HttpGet]
        [Route("ActivarTipoExplotacionxId")]
        public async Task<ResponseModel> ActivarTipoExplotacionxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se habilitó el registro correctamente";
                respuesta.data = await _tipoexplotacionService.ActivarTipoExplotacionxId(id);
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al habilitar el registro";
                return respuesta;
            }
        }
        [HttpGet]
        [Route("DesactivarTipoExplotacionxId")]
        public async Task<ResponseModel> DesactivarTipoExplotacionxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se deshabilitó el registro correctamente";
                respuesta.data = await _tipoexplotacionService.DesactivarTipoExplotacionxId(id);
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al deshabilitar el registro";
                return respuesta;
            }
        }
    }
}
