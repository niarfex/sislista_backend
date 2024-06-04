using Application.Output;
using Infra.MarcoLista.Output.Repository;
using Domain.Model;
using AutoMapper;
using Infra.MarcoLista.Input.Dto;
//using Infra.ProductorAgrario.Mapper;
#nullable disable
namespace Infra.MarcoLista.Output.Adapter
{
    public class ProductorAgrarioAdapter : IProductorAgrarioPort
    {
        private readonly IProductorAgrarioRepository _productorAgrarioRepository;
        private readonly IMapper _mapper;
        public ProductorAgrarioAdapter(IProductorAgrarioRepository productorAgrarioRepository, IMapper mapper)
        {
            _productorAgrarioRepository = productorAgrarioRepository;
            _mapper = mapper;
        }

        public async Task<Domain.Model.ProductorAgrario> getByNrodoc(string nrodoc)
        {
            var productorAgrarioEntity = await _productorAgrarioRepository.getByNrodoc(nrodoc);

            if (productorAgrarioEntity != null)
            {
                return _mapper.Map<Domain.Model.ProductorAgrario>(productorAgrarioEntity);
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Domain.Model.ProductorAgrario>> getAll()
        {
            throw new System.NotImplementedException("Unimplemented method 'GetAll'");
        }
    }
}
