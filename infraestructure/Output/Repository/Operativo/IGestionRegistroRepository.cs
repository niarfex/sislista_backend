using Domain.Model;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IGestionRegistroRepository
    {
        Task<List<GestionRegistroModel>> GetAll(string param, string uuid);
        Task<GestionRegistroEntity> GetGestionRegistroxUUID(string uuid);
        Task<GestionRegistroModel> GetUUIDCuestionario(string numDoc, long idPeriodo);
        Task<List<FundoModel>> GetFundosCuestionario(string uuid);
        Task<List<InformanteModel>> GetInformantesCuestionario(string uuid);
        Task<List<PecuarioModel>> GetPecuariosCuestionario(string uuid);
        Task<List<TrazabilidadModel>> GetObservacionesCuestionario(string uuid);
        Task<List<ArchivoModel>> GetArchivosCuestionario(string uuid);
        Task<string> CreateCuestionario(GestionRegistroModel model);
        Task<string> DesaprobarCuestionario(GestionRegistroModel model);
        Task<string> InvalidarCuestionario(GestionRegistroModel model);
        Task<string> AprobarCuestionarioxUUID(string uuid);
        Task<string> RatificarCuestionarioxUUID(string uuid);
        Task<string> DerivarCuestionarioxUUID(string uuid);
        Task<string> ValidarCuestionarioxUUID(string uuid);
        Task<string> DescartarCuestionarioxUUID(string uuid);
    }
}
