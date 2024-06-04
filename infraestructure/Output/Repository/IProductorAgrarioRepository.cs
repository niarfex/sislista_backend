using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IProductorAgrarioRepository
    {
        Task<ProductorAgrarioEntity> getByNrodoc(string nrodoc);
    }
}
