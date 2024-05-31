using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class ProductorAgrarioService : IProductorAgrarioService
    {
        private readonly IProductorAgrarioPort _productorAgrarioPort;

        public ProductorAgrarioService(IProductorAgrarioPort productorAgrarioPort)
        {
            _productorAgrarioPort = productorAgrarioPort ?? throw new ArgumentNullException(nameof(productorAgrarioPort));
        }

        public async Task<ProductorAgrario> getByNrodoc(string nrodoc)
        {
            var productorAgrario = await _productorAgrarioPort.getByNrodoc(nrodoc);
            if (productorAgrario == null)
            {
                throw new NotDataFoundException("Número de documento de identidad no encontrado");
            }

            return productorAgrario;
        }

        public async Task<List<ProductorAgrario>> getAll()
        {
            throw new NotImplementedException("Unimplemented method 'getAll'");
        }

    }
}
