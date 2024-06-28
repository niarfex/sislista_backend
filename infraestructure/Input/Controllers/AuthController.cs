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
    }
}
