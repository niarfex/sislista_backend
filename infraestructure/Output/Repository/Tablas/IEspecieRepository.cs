using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IEspecieRepository
    {
        Task<List<EspecieEntity>> GetAll(string param);
        Task<EspecieEntity> GetEspeciexId(long id);
        Task<long> CreateEspecie(EspecieModel model);
        Task<long> DeleteEspeciexId(long id);
        Task<long> ActivarEspeciexId(long id);
        Task<long> DesactivarEspeciexId(long id);
    }
}
