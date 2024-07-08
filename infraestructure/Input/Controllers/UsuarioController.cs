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
    [Route("/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IGeneralService _generalService;
        private readonly IExcelExporterService _excelexporterService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService,
            IGeneralService generalService,
            IExcelExporterService excelexporterService,
            IMapper mapper)
        {
            _usuarioService = usuarioService;
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
                var ubigeos = await _usuarioService.GetAll(param);
                respuesta.success = true;
                if (ubigeos != null)
                {
                    respuesta.data = _mapper.Map<List<UsuarioListDto>>(ubigeos);
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
                var output = _mapper.Map<List<UsuarioListDto>>(await _usuarioService.GetAll(param));
                if (output != null)
                {
                    var file = await _excelexporterService.ExportToExcel(_mapper.Map<List<UsuarioExcel>>(output));
                    return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "usuarios.xlsx");
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
        [Route("GetUsuarioxUUID")]
        public async Task<ResponseModel> GetUsuarioxUUID(string uuid="")
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                UsuarioGetDto objUsuario = new UsuarioGetDto();
                var listTipoDocumento = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetTipoDocumentoPN());
                var listPerfil = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetPerfiles());
                var listOrganizacion = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetOrganizaciones());
                var listDepartamentos = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetDepartamentosMarcoLista());
                if (uuid!="")
                {
                    objUsuario = _mapper.Map<UsuarioGetDto>(await _usuarioService.GetUsuarioxUUID(uuid));
                    objUsuario.ListMarcoListaAsignados = _mapper.Map< List<MarcoListaListDto>>(await _usuarioService.GetUsuarioMarcoLista(uuid));
                }
                objUsuario.ListTipoDocumento=listTipoDocumento;
                objUsuario.ListPerfil = listPerfil;
                objUsuario.ListOrganizacion = listOrganizacion;
                objUsuario.ListDepartamento = listDepartamentos;
                respuesta.success = true;
                respuesta.message = "Se listan los datos correctamente";
                respuesta.data = objUsuario;
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
        [Route("CreateUsuario")]
        public async Task<ResponseModel> CreateUsuario(UsuarioCreateUpdateDto dto)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var id = await _usuarioService.CreateUsuario(_mapper.Map<UsuarioModel>(dto));
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
        [Route("DeleteUsuarioxUUID")]
        public async Task<ResponseModel> DeleteUsuarioxUUID(string uuid)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se eliminó el registro correctamente";
                respuesta.data = await _usuarioService.DeleteUsuarioxUUID(uuid);
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
        [Route("ActivarUsuarioxUUID")]
        public async Task<ResponseModel> ActivarUsuarioxUUID(string uuid)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se habilitó el registro correctamente";
                respuesta.data = await _usuarioService.ActivarUsuarioxUUID(uuid);
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
        [Route("DesactivarUsuarioxUUID")]
        public async Task<ResponseModel> DesactivarUsuarioxUUID(string uuid)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se deshabilitó el registro correctamente";
                respuesta.data = await _usuarioService.DesactivarUsuarioxUUID(uuid);
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al deshabilitar el registro";
                return respuesta;
            }
        }
        [HttpGet]
        [Route("EnviarCredencialesxUUID")]
        public async Task<ResponseModel> EnviarCredencialesxUUID(string uuid)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = await _usuarioService.SendCredenciales(uuid);
                if (respuesta.success) { respuesta.message = "Se enviaron las credenciales correctamente"; }
                else { respuesta.message = "Ocurrió un problema al enviar el mensaje"; }                
                respuesta.data = null;
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al enviar las credenciales";
                return respuesta;
            }
        }
        [HttpGet]
        [Route("GetDatosRENIEC")]
        public async Task<ResponseModel> GetDatosREINEC(string dni)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var datos = await _generalService.GetDatosRENIEC(dni);
                if (datos == null){
                    respuesta.success = false;
                    respuesta.message = "El DNI no retorno ningún resultado";
                    respuesta.data = datos;
                }
                else {
                    respuesta.success = true;
                    respuesta.message = "Se obtuvieron los datos correctamente";
                    respuesta.data = datos;
                }       
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al consultar los datos";
                return respuesta;
            }
        }
        [HttpGet]
        [Route("GetDatosSUNAT")]
        public async Task<ResponseModel> GetDatosSUNAT(string ruc)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var datos = await _generalService.GetDatosSUNAT(ruc);
                if (datos == null)
                {
                    respuesta.success = false;
                    respuesta.message = "El RUC no retorno ningún resultado";
                    respuesta.data = datos;
                }
                else
                {
                    respuesta.success = true;
                    respuesta.message = "Se obtuvieron los datos correctamente";
                    respuesta.data = datos;
                }
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al consultar los datos";
                return respuesta;
            }
        }
    }
}
