using Application.Output;
using Infra.MarcoLista.Output.Repository;
using Domain.Model;
using AutoMapper;
using Infra.MarcoLista.Input.Dto;
//using Infra.ProductorAgrario.Mapper;
#nullable disable
namespace Infra.MarcoLista.Output.Adapter
{
    public class GeneralAdapter : IGeneralPort
    {
        private readonly IGeneralRepository _generalRepository;
        private readonly IMapper _mapper;
        public GeneralAdapter(IGeneralRepository generalRepository, IMapper mapper)
        {
            _generalRepository = generalRepository;
            _mapper = mapper;
        }

        public async Task<List<UbigeoModel>> GetDepartamentos(int idTipo, string idUbigeo)
        {
            var ubigeoEntity = await _generalRepository.GetDepartamentos(idTipo, idUbigeo);

            if (ubigeoEntity != null)
            {
                return ubigeoEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<TipoOrganizacionModel>> GetTipoOrganizacion()
        {
            var tipoorganizacionEntity = await _generalRepository.GetTipoOrganizacion();

            if (tipoorganizacionEntity != null)
            {
                return _mapper.Map<List<TipoOrganizacionModel>>(tipoorganizacionEntity);
            }
            else
            {
                return null;
            }
        }
    }
}
