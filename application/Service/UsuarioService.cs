using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Domain;
using Application.Common;

namespace Application.Service
{
    public class UsuarioService:IUsuarioService
    {
        private readonly IUsuarioPort _usuarioPort;
        private readonly IGeneralPort _generalPort;
        private readonly IConfiguration _appConfiguration;
        public UsuarioService(IUsuarioPort usuarioPort
            , IGeneralPort generalPort
            , IConfiguration appConfiguration )
        {
            _appConfiguration = appConfiguration;
            _usuarioPort = usuarioPort ?? throw new ArgumentNullException(nameof(usuarioPort));
            _generalPort = generalPort ?? throw new ArgumentNullException(nameof(generalPort));
        }
        public async Task<List<UsuarioModel>> GetAll(string param)
        {
            var usuarios = await _usuarioPort.GetAll(param);
            if (usuarios == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return usuarios;
        }
        public async Task<UsuarioModel> GetUsuarioxUUID(string uuid)
        {
            var usuario = await _usuarioPort.GetUsuarioxUUID(uuid);

            if (usuario == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return usuario;
        }
        public async Task<LoginModel> GetUsuarioLoginxUUID(string uuid)
        {
            var usuario = await _usuarioPort.GetUsuarioLoginxUUID(uuid);

            if (usuario == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return usuario;
        }
        public async Task<string> CreateUsuario(UsuarioModel model)
        {
            var uuid = await _usuarioPort.CreateUsuario(model);
            if (uuid == null)
            {
                throw new NotDataFoundException("No se registraron los datos");

            }
            return uuid;
        }
        public async Task<string> DeleteUsuarioxUUID(string uuid)
        {
            var usuario = await _usuarioPort.DeleteUsuarioxUUID(uuid);

            if (usuario == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return usuario;
        }
        public async Task<string> ActivarUsuarioxUUID(string uuid)
        {
            var usuario = await _usuarioPort.ActivarUsuarioxUUID(uuid);

            if (usuario == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return usuario;
        }
        public async Task<string> DesactivarUsuarioxUUID(string uuid)
        {
            var usuario = await _usuarioPort.DesactivarUsuarioxUUID(uuid);

            if (usuario == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return usuario;
        }
        public async Task<List<MarcoListaModel>> GetUsuarioMarcoLista(string uuid)
        {
            var marcolistas = await _usuarioPort.GetUsuarioMarcoLista(uuid);
            var departamentos = await _generalPort.GetDepartamentos(1, "");
            if (marcolistas == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            var query = from m in marcolistas
                        join d in departamentos on m.IdDepartamento equals d.Id
                        select new MarcoListaModel
                        {
                            Id = m.Id,
                            NumeroDocumento = m.NumeroDocumento,
                            NombreCompleto = m.NombreCompleto,
                            CondicionJuridica = m.CondicionJuridica,
                            NombreRepLegal = m.NombreRepLegal,
                            IdDepartamento = m.IdDepartamento,
                            Departamento = d.Departamento,
                            Estado = m.Estado
                        };

            return query.ToList();
        }

        public async Task<bool> SendCredenciales(string uuid)
        {
            string asunto = "";
            string mensaje = "";
            string concopia = "";
            concopia = _appConfiguration[$"configCorreo:concopia"] == "" ? "" : "," + _appConfiguration[$"configCorreo:concopia"];
            try
            {
                var objUsuario = await GetUsuarioxUUID(uuid);
                if (objUsuario.Estado == 0)//Estado Inactivo
                {
                    asunto = "Deshabilitación de Credenciales del Sistema de Marco de Lista";
                    mensaje = $"Estimado(a) {objUsuario.Nombre} mediante la presente comunicación te informamos que tus credenciales para acceso al Sistema del Marco de Lista de Encuesta Nacional Agropecuaria han sido deshabilitadas, por lo que no podrás volver a acceder al sistema." + "<br><br>" +
                        $"Para mayor información, comunicate con el Administrador del Sistema." + "<br><br>";

                }
                else if (objUsuario.Estado == 1)//Estado Activo 
                {
                    asunto = "Credenciales de acceso para el Sistema de Marco de Lista";
                    mensaje = $"Bienvenido(a) {objUsuario.Nombre} al Sistema del Marco de Lista de Encuesta Nacional Agropecuaria" + "<br><br>" +
                        $"Para acceder debe ingresar al siguiente enlace de acceso al sistema: {_appConfiguration[$"enlacesSISLISTA:urlApp"]}" + "<br><br>" +
                        $"Sus credenciales de acceso son las siguientes: " + "<br>" +
                        $"Usuario: {objUsuario.Usuario} " + "<br>" +
                        $"Contraseña: {objUsuario.Clave}" + "<br><br>";
                }
                var url = $"{_appConfiguration[$"configCorreo:endpoint"]}";
                var request = (HttpWebRequest)WebRequest.Create(url);
                string json = $"{{\"from\":\"{_appConfiguration[$"configCorreo:remitente"]}\"," +
                    $"\"vto\":\"{objUsuario.CorreoElectronico + concopia}\"," +
                    $"\"vasunto\":\"{asunto}\"," +
                    $"\"vmensaje\":\"{mensaje}\"}}";

                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return false;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = await objReader.ReadToEndAsync();
                        }
                    }
                }
                Utils.registrarLog("Se remitió la notificación de manera exitosa", "SendCredenciales", "SUCCESSFUL");
                return true;
            }
            catch (WebException ex)
            {
                Utils.registrarLog(ex.Message, "SendCredenciales", "ERROR");
                throw ex;
            }
        }
        public async Task<LoginModel> datosInicioSesion(AuthModel auth)
        {
            var usuario = await _usuarioPort.datosInicioSesion(auth);

            if (usuario.CodigoUUID == null)
            {
                throw new NotDataFoundException("El usuario y/o contraseña no son correctos");
            }
            if (usuario.CodigoUUID!=null)
            {
                var tokens = await GenerateJWTToken(usuario);
                usuario.AccessToken = tokens.AccessToken;
                usuario.RefreshToken = tokens.RefreshToken;
                return usuario;
            }
            else
            {
                return null;
            }            
        }
        private async Task<TokenModel> GenerateJWTToken(LoginModel usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfiguration[$"Authentication:JwtBearer:SecurityKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            TokenModel tokens = new TokenModel();

            var claims = new[] {
                new Claim("Usuario", usuario.Usuario),
                new Claim("Nombre", usuario.Nombre),
                new Claim(JwtRegisteredClaimNames.Aud, _appConfiguration[$"Authentication:JwtBearer:Audience"]),                
                new Claim("CodigoUUID", usuario.CodigoUUID),
                new Claim("CodigoPerfil", usuario.CodigoPerfil),
                new Claim("Perfil", usuario.Perfil)
            };

            var token = new JwtSecurityToken(
                issuer: _appConfiguration[$"Authentication:JwtBearerJ:Issuer"],
                audience: _appConfiguration[$"Authentication:JwtBearer:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_appConfiguration[$"Authentication:JwtBearer:Duracion"].ToString())),
                signingCredentials: credentials);

            var AccesToken= new JwtSecurityTokenHandler().WriteToken(token);

            var expiracion = DateTime.UtcNow.AddDays(7);
            var refreshToken = Guid.NewGuid().ToString("N");

            var actualizado = await _usuarioPort.ActualizarRefreshToken(usuario.CodigoUUID, expiracion, refreshToken);
            tokens.AccessToken = AccesToken;
            tokens.RefreshToken = refreshToken;

            return tokens;

        }
    }
}
