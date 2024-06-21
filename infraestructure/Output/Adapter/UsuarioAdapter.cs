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
                return _mapper.Map<UsuarioModel>(usuarioEntity);
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
    }
}
