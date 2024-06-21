using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class UsuarioService:IUsuarioService
    {
        private readonly IUsuarioPort _usuarioPort;

        public UsuarioService(IUsuarioPort usuarioPort)
        {
            _usuarioPort = usuarioPort ?? throw new ArgumentNullException(nameof(usuarioPort));
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
    }
}
