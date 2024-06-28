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
    [Route("/v1/plantilla")]
    [ApiController]
    public class PlantillaController : ControllerBase
    {
        private readonly IPlantillaService _plantillaService;
        private readonly IMapper _mapper;

        public PlantillaController(IPlantillaService plantillaService, IMapper mapper)
        {
            _plantillaService = plantillaService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ResponseModel> GetAll(string param = "")
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var ubigeos = await _plantillaService.GetAll(param);
                respuesta.success = true;
                if (ubigeos != null)
                {
                    respuesta.data = _mapper.Map<List<PlantillaListDto>>(ubigeos);
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
        [Route("GetPlantillaxId")]
        public async Task<ResponseModel> GetPlantillaxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                PlantillaGetDto objPlantilla = new PlantillaGetDto();       
                if (id > 0)
                {
                    objPlantilla = _mapper.Map<PlantillaGetDto>(await _plantillaService.GetPlantillaxId(id));
                } 
                respuesta.success = true;
                respuesta.message = "Se listan los datos correctamente";
                respuesta.data = objPlantilla;
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
        [Route("CreatePlantilla")]
        public async Task<ResponseModel> CreatePlantilla(PlantillaCreateUpdateDto dto)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var id = await _plantillaService.CreatePlantilla(_mapper.Map<PlantillaModel>(dto));
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
        [Route("DeletePlantillaxId")]
        public async Task<ResponseModel> DeletePlantillaxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se eliminó el registro correctamente";
                respuesta.data = await _plantillaService.DeletePlantillaxId(id);
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
        [Route("ActivarPlantillaxId")]
        public async Task<ResponseModel> ActivarPlantillaxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se habilitó el registro correctamente";
                respuesta.data = await _plantillaService.ActivarPlantillaxId(id);
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
        [Route("DesactivarPlantillaxId")]
        public async Task<ResponseModel> DesactivarPlantillaxId(long id)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se deshabilitó el registro correctamente";
                respuesta.data = await _plantillaService.DesactivarPlantillaxId(id);
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
