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
        public async Task<List<UsuarioModel>> GetAll(ParamBusqueda param)
        {
            var usuarios = await _usuarioPort.GetAll(param);
            if (usuarios == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }

            return usuarios;
        }
    }
}
