using Domain.Model;

namespace Application.Output
{
    public interface IReportePort
    {
        Task<ReporteModel> GetAll(string valCodigo);
        Task<List<ReporteModel>> GetReporteUsuarioList(string valCodigo);
        Task<List<ReporteModel>> GetFlujoValidacionList(string valCodigo);
        Task<List<ReporteModel>> GetRankingRegCerradosList(string valCodigo);
        Task<List<ReporteModel>> GetMejorTiempoList(string valCodigo);

    }
}
