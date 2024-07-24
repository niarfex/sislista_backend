using Application.Output;
using AutoMapper;
using Domain.Model;
using Infra.MarcoLista.Output.Repository;

namespace Infra.MarcoLista.Output.Adapter
{
    public class ReporteAdapter : IReportePort
    {
        private readonly IReporteRepository _reporteRepository;
        private readonly IMapper _mapper;
        public ReporteAdapter(IReporteRepository reporteRepository, IMapper mapper)
        {
            _reporteRepository = reporteRepository;
            _mapper = mapper;
        }
        public async Task<ReporteModel> GetAll(string valCodigo)
        {
            var reporteEntity = await _reporteRepository.GetAll(valCodigo);

            if (reporteEntity != null)
            {
                return reporteEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<ReporteModel>> GetReporteUsuarioList(string valCodigo)
        {
            var reporteEntity = await _reporteRepository.GetReporteUsuarioList(valCodigo);

            if (reporteEntity != null)
            {
                return reporteEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<ReporteModel>> GetFlujoValidacionList(string valCodigo)
        {
            var reporteEntity = await _reporteRepository.GetFlujoValidacionList(valCodigo);

            if (reporteEntity != null)
            {
                return reporteEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<ReporteModel>> GetRankingRegCerradosList(string valCodigo)
        {
            var reporteEntity = await _reporteRepository.GetRankingRegCerradosList(valCodigo);

            if (reporteEntity != null)
            {
                return reporteEntity;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<ReporteModel>> GetMejorTiempoList(string valCodigo)
        {
            var reporteEntity = await _reporteRepository.GetMejorTiempoList(valCodigo);

            if (reporteEntity != null)
            {
                return reporteEntity;
            }
            else
            {
                return null;
            }
        }
    }
}
