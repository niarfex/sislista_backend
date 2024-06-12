using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class CondicionJuridicaService : ICondicionJuridicaService
    {
        private readonly ICondicionJuridicaPort _condicionjuridicaPort;

        public CondicionJuridicaService(ICondicionJuridicaPort condicionjuridicaPort)
        {
            _condicionjuridicaPort = condicionjuridicaPort ?? throw new ArgumentNullException(nameof(condicionjuridicaPort));
        }
        public async Task<List<CondicionJuridicaModel>> GetAll(ParamBusqueda param)
        {
            var condicionjuridicas = await _condicionjuridicaPort.GetAll(param);
            if (condicionjuridicas == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }

            return condicionjuridicas;
        }
    }
}
