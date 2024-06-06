using Domain.Model;

namespace Application.Output
{
    public interface IProductorAgrarioPort
    {
        Task<ProductorAgrario> getByNrodoc(String nrodoc);
        //Task<List<ProductorAgrario>> getAll();
    }
}
