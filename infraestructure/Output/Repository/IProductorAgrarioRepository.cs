using Infra.ProductorAgrario.Output.Entity;

namespace Infra.ProductorAgrario.Output.Repository
{
    public interface IProductorAgrarioRepository
    {
        Task<ProductorAgrarioEntity> getByNrodoc(string nrodoc);
    }
}
