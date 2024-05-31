using Domain.Model;

namespace Application.Input
{
    public interface IProductorAgrarioService
    {
        Task<ProductorAgrario> getByNrodoc(String nrodoc);
        Task<List<ProductorAgrario>> getAll();
    }
}
