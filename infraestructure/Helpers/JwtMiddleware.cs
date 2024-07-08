using Microsoft.Extensions.Options;
using Application.Service;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application.Input;

namespace Infra.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _appConfiguration;

        public JwtMiddleware(RequestDelegate next, IConfiguration appConfiguration)
        {
            _next = next;
            _appConfiguration = appConfiguration;
        }

        public async Task Invoke(HttpContext context, IUsuarioService usuarioService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                await attachUserToContext(context, usuarioService, token);

            await _next(context);
        }

        private async Task attachUserToContext(HttpContext context, IUsuarioService usuarioService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appConfiguration[$"Authentication:JwtBearer:SecurityKey"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clock skew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userUuid = jwtToken.Claims.First(x => x.Type == "CodigoUUID").Value.ToString();

                //Attach user to context on successful JWT validation
                context.Items["User"] = await usuarioService.GetUsuarioLoginxUUID(userUuid);
            }
            catch (Exception e)
            {
                //Do nothing if JWT validation fails
                // user is not attached to context so the request won't have access to secure routes
            }
        }
    }
}