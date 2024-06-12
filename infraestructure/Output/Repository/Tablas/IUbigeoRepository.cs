using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IUbigeoRepository
    {
        Task<List<UbigeoEntity>> GetAll(string param);
        Task<UbigeoEntity> getUbigeo();
        Task<UbigeoEntity> createUbigeo();
        Task<UbigeoEntity> updateUbigeo();
        Task<bool> deleteUbigeo();
    }
}
