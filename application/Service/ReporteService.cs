using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class ReporteService : IReporteService
    {
        private readonly IReportePort _reportePort;

        public ReporteService(IReportePort reportePort)
        {
            _reportePort = reportePort ?? throw new ArgumentNullException(nameof(reportePort));
        }
        public async Task<ReporteModel> GetAll(string valCodigo)
        {
            var reportes = await _reportePort.GetAll(valCodigo);
            if (reportes == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }

            return reportes;
        }
        public async Task<List<ReporteModel>> GetReporteUsuarioList(string valCodigo)
        {
            var reportes = await _reportePort.GetReporteUsuarioList(valCodigo);
            if (reportes == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }

            return reportes;
        }
        public async Task<List<ReporteModel>> GetFlujoValidacionList(string valCodigo)
        {
            var reportes = await _reportePort.GetFlujoValidacionList(valCodigo);
            if (reportes == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }

            return reportes;
        }
        public async Task<List<ReporteModel>> GetRankingRegCerradosList(string valCodigo)
        {
            var reportes = await _reportePort.GetRankingRegCerradosList(valCodigo);
            if (reportes == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }

            return reportes;
        }
        public async Task<List<ReporteModel>> GetMejorTiempoList(string valCodigo)
        {
            var reportes = await _reportePort.GetMejorTiempoList(valCodigo);
            if (reportes == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }

            return reportes;
        }
    }
}
