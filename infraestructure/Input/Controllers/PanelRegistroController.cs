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
    [Route("/v1/panelregistro")]
    [ApiController]
    public class PanelRegistroController : ControllerBase
    {
        private readonly IPanelRegistroService _panelregistroService;
        private readonly IGeneralService _generalService;
        private readonly IMapper _mapper;

        public PanelRegistroController(IPanelRegistroService panelregistroService,
            IGeneralService generalService,
            IMapper mapper)
        {
            _panelregistroService = panelregistroService;
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
                respuesta.message = "Ocurrió un error al consultar el listado";
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
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al borrar el registro";
                return respuesta;
            }
        }               
    }
}
