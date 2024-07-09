using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class MarcoListaService : IMarcoListaService
    {
        private readonly IMarcoListaPort _marcolistaPort;
        private readonly ICondicionJuridicaPort _condicionjuridicaPort;
        private readonly IGeneralPort _generalPort;
        public MarcoListaService(IMarcoListaPort marcolistaPort
            , ICondicionJuridicaPort condicionjuridicaPort
            , IGeneralPort generalPort)
        {
            _marcolistaPort = marcolistaPort ?? throw new ArgumentNullException(nameof(marcolistaPort));
            _condicionjuridicaPort = condicionjuridicaPort ?? throw new ArgumentNullException(nameof(condicionjuridicaPort));
            _generalPort = generalPort ?? throw new ArgumentNullException(nameof(generalPort));
        }
        public async Task<List<MarcoListaModel>> GetAll(string param)
        {
            var marcolistas = await _marcolistaPort.GetAll(param);
            var departamentos = await _generalPort.GetDepartamentos(1,"");
            if (marcolistas == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            var query = from m in marcolistas
                        from d in departamentos.Where(x => x.Id == m.IdDepartamento).DefaultIfEmpty()
                        select new MarcoListaModel
                        {
                            Id = m.Id,
                            NumeroDocumento = m.NumeroDocumento,
                            NombreCompleto = m.NombreCompleto,
                            CondicionJuridica = m.CondicionJuridica,
                            NombreRepLegal = m.NombreRepLegal,
                            IdDepartamento = d != null ? m.IdDepartamento : null,                            
                            Departamento = d != null ? d.Departamento: null,
                            Estado = m.Estado
                        };

            return query.ToList();
        }
        public async Task<MarcoListaModel> GetMarcoListaxId(long id)
        {
            var marcolista = await _marcolistaPort.GetMarcoListaxId(id);           

            if (marcolista == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return marcolista;
        }
        public async Task<long> CreateMarcoLista(MarcoListaModel model)
        {
            var id = await _marcolistaPort.CreateMarcoLista(model);
            if (id == null)
            {
                throw new NotDataFoundException("No se registraron los datos");

            }
            return id;
        }
        public async Task<long> DeleteMarcoListaxId(long id)
        {
            var marcolista = await _marcolistaPort.DeleteMarcoListaxId(id);

            if (marcolista == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return marcolista;
        }
        public async Task<long> ActivarMarcoListaxId(long id)
        {
            var marcolista = await _marcolistaPort.ActivarMarcoListaxId(id);

            if (marcolista == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return marcolista;
        }
        public async Task<long> DesactivarMarcoListaxId(long id)
        {
            var marcolista = await _marcolistaPort.DesactivarMarcoListaxId(id);

            if (marcolista == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return marcolista;
        }
    }
}
