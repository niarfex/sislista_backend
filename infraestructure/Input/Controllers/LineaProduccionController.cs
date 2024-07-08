using Application.Input;
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
    [Route("/v1/lineaproduccion")]
    [ApiController]
    public class LineaProduccionController : ControllerBase
    {
        private readonly ILineaProduccionService _lineaproduccionService;
        private readonly IExcelExporterService _excelexporterService;
        private readonly IMapper _mapper;

        public LineaProduccionController(ILineaProduccionService lineaproduccionService,
            IExcelExporterService excelexporterService,
            IMapper mapper)
        {
            _lineaproduccionService = lineaproduccionService;
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
                var ubigeos = await _lineaproduccionService.GetAll(param);
                respuesta.success = true;
                if (ubigeos != null)
                {
                    respuesta.data = _mapper.Map<List<LineaProduccionListDto>>(ubigeos);
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
                var output = _mapper.Map<List<LineaProduccionListDto>>(await _lineaproduccionService.GetAll(param));
                if (output != null)
                {
                    var file = await _excelexporterService.ExportToExcel(_mapper.Map<List<LineaProduccionExcel>>(output));
                    return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "lineaproduccion.xlsx");
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
        [Route("GetLineaProduccionxId")]
        public async Task<ResponseModel> GetLineaProduccionxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                LineaProduccionGetDto objLineaProduccion = new LineaProduccionGetDto();
                if (id > 0)
                {
                    objLineaProduccion = _mapper.Map<LineaProduccionGetDto>(await _lineaproduccionService.GetLineaProduccionxId(id));
                }
                respuesta.success = true;
                respuesta.message = "Se listan los datos correctamente";
                respuesta.data = objLineaProduccion;
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
        [Route("CreateLineaProduccion")]
        public async Task<ResponseModel> CreateLineaProduccion(LineaProduccionCreateUpdateDto dto)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var id = await _lineaproduccionService.CreateLineaProduccion(_mapper.Map<LineaProduccionModel>(dto));
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
        [Route("DeleteLineaProduccionxId")]
        public async Task<ResponseModel> DeleteLineaProduccionxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se eliminó el registro correctamente";
                respuesta.data = await _lineaproduccionService.DeleteLineaProduccionxId(id);
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
        [Route("ActivarLineaProduccionxId")]
        public async Task<ResponseModel> ActivarLineaProduccionxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se habilitó el registro correctamente";
                respuesta.data = await _lineaproduccionService.ActivarLineaProduccionxId(id);
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
        [Route("DesactivarLineaProduccionxId")]
        public async Task<ResponseModel> DesactivarLineaProduccionxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se deshabilitó el registro correctamente";
                respuesta.data = await _lineaproduccionService.DesactivarLineaProduccionxId(id);
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
