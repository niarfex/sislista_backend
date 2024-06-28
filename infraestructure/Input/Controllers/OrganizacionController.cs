using Application.Input;
using Application.Service;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Infra.MarcoLista.Input.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/organizacion")]
    [ApiController]
    public class OrganizacionController : ControllerBase
    {
        private readonly IOrganizacionService _organizacionService;
        private readonly IGeneralService _generalService;
        private readonly IMapper _mapper;

        public OrganizacionController(IOrganizacionService organizacionService, 
            IGeneralService generalService, 
            IMapper mapper)
        {
            _organizacionService = organizacionService;
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
                var ubigeos = await _organizacionService.GetAll(param);
                respuesta.success = true;                
                if (ubigeos != null)
                {
                    respuesta.data = _mapper.Map<List<OrganizacionListDto>>(ubigeos);
                }
                else
                {
                    respuesta.data = null;
                }
                respuesta.message="Se listan los datos correctamente";
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
        [Route("GetOrganizacionxId")]
        public async Task<ResponseModel> GetOrganizacionxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                OrganizacionGetDto objOrganizacion = new OrganizacionGetDto();
                var listDepartamentos = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetDepartamentos());
                var listTipoOrganizacion = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetTipoOrganizacion());
                if (id > 0)
                {
                    objOrganizacion= _mapper.Map<OrganizacionGetDto>(await _organizacionService.GetOrganizacionxId(id));
                }
                objOrganizacion.ListDepartamento = listDepartamentos;
                objOrganizacion.ListTipoOrganizacion = listTipoOrganizacion;
                respuesta.success = true;
                respuesta.message = "Se listan los datos correctamente";
                respuesta.data = objOrganizacion;
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
        [Route("CreateOrganizacion")]
        public async Task<ResponseModel> CreateOrganizacion(OrganizacionCreateUpdateDto dto)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var id = await _organizacionService.CreateOrganizacion(_mapper.Map<OrganizacionModel>(dto));             
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
        [Route("DeleteOrganizacionxId")]
        public async Task<ResponseModel> DeleteOrganizacionxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {    
                respuesta.success = true;
                respuesta.message = "Se eliminó el registro correctamente";
                respuesta.data = await _organizacionService.DeleteOrganizacionxId(id);
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
        [Route("ActivarOrganizacionxId")]
        public async Task<ResponseModel> ActivarOrganizacionxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se habilitó el registro correctamente";
                respuesta.data = await _organizacionService.ActivarOrganizacionxId(id);
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
        [Route("DesactivarOrganizacionxId")]
        public async Task<ResponseModel> DesactivarOrganizacionxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se deshabilitó el registro correctamente";
                respuesta.data = await _organizacionService.DesactivarOrganizacionxId(id);
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
