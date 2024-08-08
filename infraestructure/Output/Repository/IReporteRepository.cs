using Domain.Model;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;

namespace Infra.MarcoLista.Output.Repository
{
    public interface IReporteRepository
    {
        Task<ReporteModel> GetAll(string valCodigo);
        Task<List<ReporteModel>> GetReporteUsuarioList(string valCodigo, string param, long idPeriodo);
        Task<List<ReporteModel>> GetFlujoValidacionList(string valCodigo);
        Task<List<ReporteModel>> GetRankingRegCerradosList(string valCodigo);
        Task<List<ReporteModel>> GetMejorTiempoList(string valCodigo);
    }
}
