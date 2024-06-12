using Application.Output;
using Infra.MarcoLista.Output.Repository;
using Domain.Model;
using AutoMapper;
using Infra.MarcoLista.Input.Dto;
//using Infra.ProductorAgrario.Mapper;
#nullable disable
namespace Infra.MarcoLista.Output.Adapter
{
    public class UbigeoAdapter : IUbigeoPort
    {
        private readonly IUbigeoRepository _ubigeoRepository;
        private readonly IMapper _mapper;
        public UbigeoAdapter(IUbigeoRepository ubigeoRepository, IMapper mapper)
        {
            _ubigeoRepository = ubigeoRepository;
            _mapper = mapper;
        }

        public async Task<List<UbigeoModel>> GetAll(string param)
        {
            var ubigeoEntity = await _ubigeoRepository.GetAll(param);

            if (ubigeoEntity != null)
            {
                return _mapper.Map<List<UbigeoModel>>(ubigeoEntity);
            }
            else
            {
            return null;
            }
        }
    }
}
