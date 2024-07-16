using Domain.Model;

namespace Application.Input
{
    public interface IGestionRegistroService
    {
        Task<List<GestionRegistroModel>> GetAll(string param, string uuid);
        Task<GestionRegistroModel> GetGestionRegistroxUUID(string uuid);
        Task<GestionRegistroModel> GetUUIDCuestionario(string numDoc, long idPeriodo);
        Task<List<ArchivoModel>> GetArchivosCuestionario(string uuid);
    }
}
