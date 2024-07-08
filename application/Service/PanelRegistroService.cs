using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class PanelRegistroService : IPanelRegistroService
    {
        private readonly IPanelRegistroPort _panelregistroPort;
        private readonly IGeneralPort _generalPort;

        public PanelRegistroService(IPanelRegistroPort panelregistroPort
            , IGeneralPort generalPort)
        {
            _panelregistroPort = panelregistroPort ?? throw new ArgumentNullException(nameof(panelregistroPort));
            _generalPort = generalPort ?? throw new ArgumentNullException(nameof(generalPort));
        }
        public async Task<List<PanelRegistroModel>> GetAll(string param)
        {
            var panelregistros = await _panelregistroPort.GetAll(param);
            var periodos = await _generalPort.GetPeriodos();
      
            if (panelregistros == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            var query = from o in panelregistros
                        join p in periodos on o.IdAnio equals p.Id           
                        where o.Estado == 0 || o.Estado == 1 || o.Estado == 2
                        select new PanelRegistroModel
                        {
                            Id = o.Id,
                            Periodo = p.Anio,
                            ProgramacionRegistro = o.ProgramacionRegistro,
                            FechaInicio = o.FechaInicio,
                            FechaFin = o.FechaFin,
                            EstadoProgramacion = o.EstadoProgramacion
                        };
            return query.ToList();
        }
        public async Task<PanelRegistroModel> GetPanelRegistroxId(long id)
        {
            var panelregistro = await _panelregistroPort.GetPanelRegistroxId(id);

            if (panelregistro == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return panelregistro;
        }
        public async Task<long> CreatePanelRegistro(PanelRegistroModel model)
        {
            var id = await _panelregistroPort.CreatePanelRegistro(model);
            if (id == null)
            {
                throw new NotDataFoundException("No se registraron los datos");

            }
            return id;
        }
        public async Task<long> DeletePanelRegistroxId(long id)
        {
            var panelregistro = await _panelregistroPort.DeletePanelRegistroxId(id);

            if (panelregistro == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return panelregistro;
        }
        public async Task<long> PublicarPanelRegistroxId(long id)
        {
            var panelregistro = await _panelregistroPort.PublicarPanelRegistroxId(id);

            if (panelregistro == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return panelregistro;
        }
        public async Task<long> PausarPanelRegistroxId(long id)
        {
            var panelregistro = await _panelregistroPort.PausarPanelRegistroxId(id);

            if (panelregistro == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return panelregistro;
        }
        public async Task<long> ReiniciarPanelRegistroxId(long id)
        {
            var panelregistro = await _panelregistroPort.ReiniciarPanelRegistroxId(id);

            if (panelregistro == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return panelregistro;
        }
    }
}
