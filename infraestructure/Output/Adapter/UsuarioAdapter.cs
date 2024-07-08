using Application.Output;
using AutoMapper;
using Domain.Model;
using Infra.MarcoLista.Output.Repository;

namespace infraestructure.Output.Adapter
{
    public class UsuarioAdapter: IUsuarioPort
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioAdapter(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<List<UsuarioModel>> GetAll(string param)
        {
            var usuarioEntity = await _usuarioRepository.GetAll(param);

            if (usuarioEntity != null)
            {
                return usuarioEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<UsuarioModel> GetUsuarioxUUID(string uuid)
        {
            var usuarioEntity = await _usuarioRepository.GetUsuarioxUUID(uuid);

            if (usuarioEntity != null)
            {
                return usuarioEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<LoginModel> GetUsuarioLoginxUUID(string uuid)
        {
            var usuarioEntity = await _usuarioRepository.GetUsuarioLoginxUUID(uuid);

            if (usuarioEntity != null)
            {
                return usuarioEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<string> CreateUsuario(UsuarioModel model)
        {
            var usuarioEntity = await _usuarioRepository.CreateUsuario(model);

            if (usuarioEntity != null)
            {
                return usuarioEntity;
            }
            else
            {
                return "";
            }
        }
        public async Task<string> DeleteUsuarioxUUID(string uuid)
        {
            var usuarioEntity = await _usuarioRepository.DeleteUsuarioxUUID(uuid);

            if (usuarioEntity != null)
            {
                return usuarioEntity;
            }
            else
            {
                return "";
            }
        }
        public async Task<string> ActivarUsuarioxUUID(string uuid)
        {
            var usuarioEntity = await _usuarioRepository.ActivarUsuarioxUUID(uuid);

            if (usuarioEntity != null)
            {
                return usuarioEntity;
            }
            else
            {
                return "";
            }
        }
        public async Task<string> DesactivarUsuarioxUUID(string uuid)
        {
            var usuarioEntity = await _usuarioRepository.DesactivarUsuarioxUUID(uuid);

            if (usuarioEntity != null)
            {
                return usuarioEntity;
            }
            else
            {
                return "";
            }
        }
        public async Task<List<UsuarioModel>> GetCorreosUsuariosxPerfil(long idPerfil)
        {
            var usuarioEntity = await _usuarioRepository.GetCorreosUsuariosxPerfil(idPerfil);

            if (usuarioEntity != null)
            {
                return usuarioEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> ActualizarRefreshToken(string uuid, DateTime expiracion, string refreshToken)
        {
            var usuarioEntity = await _usuarioRepository.ActualizarRefreshToken(uuid,expiracion,refreshToken);

            if (usuarioEntity != null)
            {
                return usuarioEntity;
            }
            else
            {
                return false;
            }
        }
        public async Task<List<MarcoListaModel>> GetUsuarioMarcoLista(string uuid)
        {
            var marcolistaEntity = await _usuarioRepository.GetUsuarioMarcoLista(uuid);

            if (marcolistaEntity != null)
            {
                return marcolistaEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<LoginModel> datosInicioSesion(AuthModel auth)
        {
            var marcolistaEntity = await _usuarioRepository.datosInicioSesion(auth);

            if (marcolistaEntity != null)
            {
                return marcolistaEntity;
            }
            else
            {
                return null;
            }
        }
    }
}
