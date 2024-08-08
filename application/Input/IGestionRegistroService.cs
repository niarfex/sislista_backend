using Domain.Model;

namespace Application.Input
{
    public interface IGestionRegistroService
    {
        Task<List<GestionRegistroModel>> GetAll(string param, string uuid);
        Task<GestionRegistroModel> GetGestionRegistroxUUID(string uuid);
        Task<GestionRegistroModel> GetUUIDCuestionario(string numDoc, long idPeriodo);
        Task<List<ArchivoModel>> GetArchivosCuestionario(string uuid);
        Task<List<FundoModel>> GetFundosCuestionario(string uuid);
        Task<List<InformanteModel>> GetInformantesCuestionario(string uuid);
        Task<List<PecuarioModel>> GetPecuariosCuestionario(string uuid);
        Task<List<TrazabilidadModel>> GetObservacionesCuestionario(string uuid);
        Task<string> CreateCuestionario(GestionRegistroModel model);
        Task<string> DesaprobarCuestionario(GestionRegistroModel model);
        Task<string> InvalidarCuestionario(GestionRegistroModel model);
        Task<string> AprobarCuestionarioxUUID(string uuid, DateTime fechaInicio);
        Task<string> RatificarCuestionarioxUUID(string uuid, DateTime fechaInicio);
        Task<string> DerivarCuestionarioxUUID(string uuid, DateTime fechaInicio);
        Task<string> ValidarCuestionarioxUUID(string uuid, DateTime fechaInicio);
        Task<string> DescartarCuestionarioxUUID(string uuid, DateTime fechaInicio);
    }
}
