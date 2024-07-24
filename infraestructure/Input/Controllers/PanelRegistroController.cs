using Application.Input;
using Application.Service;
using Application.Service.Exportar;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Domain.Model.ExportExcel;
using Infra.Helpers;
using Infra.MarcoLista.Input.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/panelregistro")]
    [ApiController]
    [Authorize]
    public class PanelRegistroController : ControllerBase
    {
        private readonly IPanelRegistroService _panelregistroService;
        private readonly IGeneralService _generalService;
        private readonly IExcelExporterService _excelexporterService;
        private readonly IMapper _mapper;

        public PanelRegistroController(IPanelRegistroService panelregistroService,
            IGeneralService generalService,
            IExcelExporterService excelexporterService,
            IMapper mapper)
        {
            _panelregistroService = panelregistroService;
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
                var ubigeos = await _panelregistroService.GetAll(param);
                respuesta.success = true;
                if (ubigeos != null)
                {
                    respuesta.data = _mapper.Map<List<PanelRegistroListDto>>(ubigeos);
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
                var output = _mapper.Map<List<PanelRegistroListDto>>(await _panelregistroService.GetAll(param));
                if (output != null)
                {
                    var file = await _excelexporterService.ExportToExcel(_mapper.Map<List<PanelRegistroExcel>>(output));
                    return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "panelregistro.xlsx");
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
        [Route("GetPanelRegistroxId")]
        public async Task<ResponseModel> GetPanelRegistroxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                PanelRegistroGetDto objPanelRegistro = new PanelRegistroGetDto();
                var listPeriodos = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetPeriodos());
                var listPlantillasActivas = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetPlantillasActivas());
                if (id > 0)
                {
                    objPanelRegistro = _mapper.Map<PanelRegistroGetDto>(await _panelregistroService.GetPanelRegistroxId(id));
                }
                objPanelRegistro.ListPeriodos = listPeriodos;
                objPanelRegistro.ListPlantillasActivas = listPlantillasActivas;       
                respuesta.success = true;
                respuesta.message = "Se listan los datos correctamente";
                respuesta.data = objPanelRegistro;
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al obtener los datos";
                return respuesta;
            }
        }
        [HttpPost]
        [Route("CreatePanelRegistro")]
        public async Task<ResponseModel> CreatePanelRegistro(PanelRegistroCreateUpdateDto dto)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var id = await _panelregistroService.CreatePanelRegistro(_mapper.Map<PanelRegistroModel>(dto));
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
        [Route("DeletePanelRegistroxId")]
        public async Task<ResponseModel> DeletePanelRegistroxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se eliminó el registro correctamente";
                respuesta.data = await _panelregistroService.DeletePanelRegistroxId(id);
                return respuesta;

            }
            catch (RelatedDataFoundException e)
            {
                respuesta.success = false;
                respuesta.message = e.Message;
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
        [Route("PublicarPanelRegistroxId")]
        public async Task<ResponseModel> PublicarPanelRegistroxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se publicó el registro correctamente";
                respuesta.data = await _panelregistroService.PublicarPanelRegistroxId(id);
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al publicar el registro";
                return respuesta;
            }
        }
        [HttpGet]
        [Route("PausarPanelRegistroxId")]
        public async Task<ResponseModel> PausarPanelRegistroxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se pausó el registro correctamente";
                respuesta.data = await _panelregistroService.PausarPanelRegistroxId(id);
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al pausar el registro";
                return respuesta;
            }
        }
        [HttpGet]
        [Route("ReiniciarPanelRegistroxId")]
        public async Task<ResponseModel> ReiniciarPanelRegistroxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se reinició el registro correctamente";
                respuesta.data = await _panelregistroService.ReiniciarPanelRegistroxId(id);
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al reiniciar el registro";
                return respuesta;
            }
        }
    }
}
