using Application.Input;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Infra.MarcoLista.Input.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private IUsuarioService _usuarioService;

        public AuthController(IConfiguration config
            , IUsuarioService usuarioService)
        {
            _config = config;
            _usuarioService = usuarioService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<JsonResult> Login(AuthModel param)
        {
            try {
                // Aquí deberías validar las credenciales del usuario
                var usuario = await _usuarioService.datosInicioSesion(param);
                if (usuario.CodigoUUID == null)
                {
                    return new JsonResult((new { success = false, usuario = param.username }));
                }
                return new JsonResult((new { success = true, usuario }));
            }
            catch (Exception e)
            {
                return new JsonResult((new { success = false, usuario = param.username }));
            }           
        }
        [HttpGet]
        [Route("ReestablecerClave")]
        public async Task<ResponseModel> ReestablecerClave(string correo)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = await _usuarioService.ReestablecerClave(correo);
                if (respuesta.success) { respuesta.message = "Se envió el enlace para reestablecer la contraseña"; }
                else { respuesta.message = "No existe el correo indicado"; }
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
        [Route("ValidarTokenReseteo")]
        public async Task<ResponseModel> ValidarTokenReseteo(string token)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = await _usuarioService.ValidarTokenReseteo(token);
                if (respuesta.success) { respuesta.message = "El token proporcionado es válido"; }
                else { respuesta.message = "El token proporcionado es inválido"; }
                respuesta.data = null;
                return respuesta;

            }
            catch (TokenExistException e)
            {
                respuesta.success = false;
                respuesta.message = e.Message;
                return respuesta;
            }
            catch (TokenExpireException e)
            {
                respuesta.success = false;
                respuesta.message = e.Message;
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al enviar las credenciales";
                return respuesta;
            }
        }
        [HttpPost]
        [Route("ActualizarClave")]
        public async Task<ResponseModel> ActualizarClave(ResetAuthModel reset)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = await _usuarioService.ActualizarClave(reset);
                if (respuesta.success) { respuesta.message = "Se actualizó la contraseña correctamente"; }
                else { respuesta.message = "No se actualizó la contraseña"; }
                respuesta.data = null;
                return respuesta;

            }
            catch (TokenExistException e)
            {
                respuesta.success = false;
                respuesta.message = e.Message;
                return respuesta;
            }
            catch (TokenExpireException e)
            {
                respuesta.success = false;
                respuesta.message = e.Message;
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al actualizar la contraseña";
                return respuesta;
            }
        }
    }
}
