using Domain.Model;

namespace Application.Output
{
    public interface IUbigeoPort
    {
        Task<List<UbigeoModel>> GetAll(string param);
    }
}
