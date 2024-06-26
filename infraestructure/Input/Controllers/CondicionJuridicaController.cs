﻿using Application.Input;
using Application.Service;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Infra.MarcoLista.Input.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/condicionjuridica")]
    [ApiController]
    public class CondicionJuridicaController : ControllerBase
    {
        private readonly ICondicionJuridicaService _condicionjuridicaService;
        private readonly IMapper _mapper;

        public CondicionJuridicaController(ICondicionJuridicaService condicionjuridicaService, IMapper mapper)
        {
            _condicionjuridicaService = condicionjuridicaService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ResponseModel> GetAll(string param = "")
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var ubigeos = await _condicionjuridicaService.GetAll(param);
                respuesta.success = true;
                if (ubigeos != null)
                {
                    respuesta.data = _mapper.Map<List<CondicionJuridicaListDto>>(ubigeos);
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
        [Route("GetCondicionJuridicaxId")]
        public async Task<ResponseModel> GetCondicionJuridicaxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                CondicionJuridicaGetDto objCondicionJuridica = new CondicionJuridicaGetDto();
                if (id > 0)
                {
                    objCondicionJuridica = _mapper.Map<CondicionJuridicaGetDto>(await _condicionjuridicaService.GetCondicionJuridicaxId(id));
                }
                respuesta.success = true;
                respuesta.message = "Se listan los datos correctamente";
                respuesta.data = objCondicionJuridica;
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
        [Route("CreateCondicionJuridica")]
        public async Task<ResponseModel> CreateCondicionJuridica(CondicionJuridicaCreateUpdateDto dto)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var id = await _condicionjuridicaService.CreateCondicionJuridica(_mapper.Map<CondicionJuridicaModel>(dto));
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
        [Route("DeleteCondicionJuridicaxId")]
        public async Task<ResponseModel> DeleteCondicionJuridicaxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se eliminó el registro correctamente";
                respuesta.data = await _condicionjuridicaService.DeleteCondicionJuridicaxId(id);
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
        [Route("ActivarCondicionJuridicaxId")]
        public async Task<ResponseModel> ActivarCondicionJuridicaxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se habilitó el registro correctamente";
                respuesta.data = await _condicionjuridicaService.ActivarCondicionJuridicaxId(id);
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
        [Route("DesactivarCondicionJuridicaxId")]
        public async Task<ResponseModel> DesactivarCondicionJuridicaxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se deshabilitó el registro correctamente";
                respuesta.data = await _condicionjuridicaService.DesactivarCondicionJuridicaxId(id);
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
