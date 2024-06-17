using Application.Input;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Infra.MarcoLista.Input.Dto;
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

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [Route("login")]
        public async Task<JsonResult> Login(Login param)
        {
            // Aquí deberías validar las credenciales del usuario
            // Si las credenciales son válidas, genera y retorna un token JWT

            var tokenString = GenerateJWTToken();
            return new JsonResult((new { usuario = new { accessToken = tokenString, numeroDocumento = "45372155", username = "45372155"} } ));
        }

        private string GenerateJWTToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer:"usuario",//_config["Jwt:Issuer"],
                audience:"usuario",//_config["Jwt:Issuer"],
                claims:null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
