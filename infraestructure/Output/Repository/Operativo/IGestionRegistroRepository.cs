using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IGestionRegistroRepository
    {
        Task<List<GestionRegistroModel>> GetAll(string param, string uuid);
        Task<GestionRegistroEntity> GetGestionRegistroxUUID(string uuid);
        Task<GestionRegistroModel> GetUUIDCuestionario(string numDoc, long idPeriodo);
    }
}
