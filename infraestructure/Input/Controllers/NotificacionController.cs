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
    [Route("/v1/notificacion")]
    [ApiController]
    public class NotificacionController : ControllerBase
    {
        private readonly INotificacionService _notificacionService;
        private readonly IGeneralService _generalService;
        private readonly IMapper _mapper;

        public NotificacionController(INotificacionService notificacionService,
            IGeneralService generalService,
            IMapper mapper)
        {
            _notificacionService = notificacionService;
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
                var ubigeos = await _notificacionService.GetAll(param);
                respuesta.success = true;
                if (ubigeos != null)
                {
                    respuesta.data = _mapper.Map<List<NotificacionListDto>>(ubigeos);
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
        [Route("GetNotificacionxId")]
        public async Task<ResponseModel> GetNotificacionxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                NotificacionGetDto objNotificacion = new NotificacionGetDto();
                var listFrecuencias = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetFrecuencias());
                var listProgramacionesVigentes = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetProgramacionesVigentes());
                var listEtapas = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetEtapas());
                var listPerfiles = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetPerfilesTodos());
                if (id > 0)
                {
                    objNotificacion = _mapper.Map<NotificacionGetDto>(await _notificacionService.GetNotificacionxId(id));
                }
                objNotificacion.ListFrecuencias = listFrecuencias;
                objNotificacion.ListProgramacionesVigentes = listProgramacionesVigentes;
                objNotificacion.ListEtapas = listEtapas;
                objNotificacion.ListPerfiles = listPerfiles;
                respuesta.success = true;
                respuesta.message = "Se listan los datos correctamente";
                respuesta.data = objNotificacion;
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
        [Route("CreateNotificacion")]
        public async Task<ResponseModel> CreateNotificacion(NotificacionCreateUpdateDto dto)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var id = await _notificacionService.CreateNotificacion(_mapper.Map<NotificacionModel>(dto));
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
        [Route("DeleteNotificacionxId")]
        public async Task<ResponseModel> DeleteNotificacionxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se eliminó el registro correctamente";
                respuesta.data = await _notificacionService.DeleteNotificacionxId(id);
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al borrar el registro";
                return respuesta;
            }
        }      
        
    }
}
