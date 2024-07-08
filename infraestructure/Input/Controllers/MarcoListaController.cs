﻿using Application.Input;
using Application.Service;
using Application.Service.Exportar;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Domain.Model.ExportExcel;
using Infra.MarcoLista.Input.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/marcolista")]
    [ApiController]
    public class MarcoListaController : ControllerBase
    {
        private readonly IMarcoListaService _marcolistaService;
        private readonly IGeneralService _generalService;
        private readonly IExcelExporterService _excelexporterService;
        private readonly IMapper _mapper;

        public MarcoListaController(IMarcoListaService marcolistaService, 
            IGeneralService generalService,
            IExcelExporterService excelexporterService,
            IMapper mapper)        {
            _marcolistaService = marcolistaService;
            _generalService = generalService;
            _excelexporterService = excelexporterService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<ResponseModel> GetAll(string param = "")
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var ubigeos = await _marcolistaService.GetAll(param);
                respuesta.success = true;
                if (ubigeos != null)
                {
                    respuesta.data = _mapper.Map<List<MarcoListaListDto>>(ubigeos);
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
        [Route("GetAllToExcel")]
        public async Task<FileResult> GetAllToExcel(string param = "")
        {
            try
            {
                var output = _mapper.Map<List<MarcoListaListDto>>(await _marcolistaService.GetAll(param));
                if (output != null)
                {
                    var file = await _excelexporterService.ExportToExcel(_mapper.Map<List<MarcoListaExcel>>(output));
                    return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "marcolista.xlsx");
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpGet]
        [Route("GetMarcoListaxId")]
        public async Task<ResponseModel> GetMarcoListaxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                MarcoListaGetDto objMarcoLista = new MarcoListaGetDto();
                var listDepartamentos = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetDepartamentos());
                var listCondicionJuridica = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetCondicionJuridicas());
                var listCondicionJuridicaOtros = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetCondicionJuridicaOtros());
                var listTipoDocumento = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetTipoDocumento());
                var listTipoExplotacion = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetTipoExplotacion());
                var listPeriodos = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetPeriodos());
                if (id > 0)
                {
                    objMarcoLista = _mapper.Map<MarcoListaGetDto>(await _marcolistaService.GetMarcoListaxId(id));
                    objMarcoLista.ListProvincia = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetProvincias(objMarcoLista.IdUbigeo.Substring(0,2)));
                    objMarcoLista.ListDistrito = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetDistritos(objMarcoLista.IdUbigeo.Substring(0, 4)));
                
                }
                objMarcoLista.ListCondicionJuridica = listCondicionJuridica;
                objMarcoLista.ListCondicionJuridicaOtros = listCondicionJuridicaOtros;
                objMarcoLista.ListTipoDocumento = listTipoDocumento;
                objMarcoLista.ListTipoExplotacion = listTipoExplotacion;
                objMarcoLista.ListPeriodos = listPeriodos;
                objMarcoLista.ListDepartamento = listDepartamentos;
                respuesta.success = true;
                respuesta.message = "Se listan los datos correctamente";
                respuesta.data = objMarcoLista;
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
        [Route("CreateMarcoLista")]
        public async Task<ResponseModel> CreateMarcoLista(MarcoListaCreateUpdateDto dto)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var id = await _marcolistaService.CreateMarcoLista(_mapper.Map<MarcoListaModel>(dto));
                respuesta.success = true;
                respuesta.message = "Se registraron los datos correctamente";
                respuesta.data = id;
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al registrar los datos";
                return respuesta;
            }
        }
        [HttpGet]
        [Route("DeleteMarcoListaxId")]
        public async Task<ResponseModel> DeleteMarcoListaxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se eliminó el registro correctamente";
                respuesta.data = await _marcolistaService.DeleteMarcoListaxId(id);
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
        [Route("ActivarMarcoListaxId")]
        public async Task<ResponseModel> ActivarMarcoListaxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se habilitó el registro correctamente";
                respuesta.data = await _marcolistaService.ActivarMarcoListaxId(id);
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
        [Route("DesactivarMarcoListaxId")]
        public async Task<ResponseModel> DesactivarMarcoListaxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se deshabilitó el registro correctamente";
                respuesta.data = await _marcolistaService.DesactivarMarcoListaxId(id);
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