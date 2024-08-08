using Domain.Model;

namespace Application.Output
{
    public interface IReportePort
    {
        Task<ReporteModel> GetAll(string valCodigo);
        Task<List<ReporteModel>> GetReporteUsuarioList(string valCodigo, string param, long idPeriodo);
        Task<List<ReporteModel>> GetFlujoValidacionList(string valCodigo);
        Task<List<ReporteModel>> GetRankingRegCerradosList(string valCodigo);
        Task<List<ReporteModel>> GetMejorTiempoList(string valCodigo);

    }
}
