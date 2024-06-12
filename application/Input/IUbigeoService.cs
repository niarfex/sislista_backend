using Domain.Model;

namespace Application.Input
{
    public interface IUbigeoService
    {
        Task<List<UbigeoModel>> GetAll(string param);
    }
}
