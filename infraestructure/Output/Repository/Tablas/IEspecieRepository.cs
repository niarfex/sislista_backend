using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{ 
    public interface IEspecieRepository
    {
        Task<List<EspecieEntity>> GetAll(ParamBusqueda param);
        Task<EspecieEntity> getEspecie();
        Task<EspecieEntity> createEspecie();
        Task<EspecieEntity> updateEspecie();
        Task<bool> deleteEspecie();
    }
}
