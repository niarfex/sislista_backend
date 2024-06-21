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
        public async Task<List<CondicionJuridicaModel>> GetAll(string param)
        {
            var condicionjuridicas = await _condicionjuridicaPort.GetAll(param);         
            if (condicionjuridicas == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
          
            return condicionjuridicas;
        }
        public async Task<CondicionJuridicaModel> GetCondicionJuridicaxId(long id)
        {
            var condicionjuridica = await _condicionjuridicaPort.GetCondicionJuridicaxId(id);

            if (condicionjuridica == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return condicionjuridica;
        }
        public async Task<long> CreateCondicionJuridica(CondicionJuridicaModel model)
        {
            var id = await _condicionjuridicaPort.CreateCondicionJuridica(model);
            if (id == null)
            {
                throw new NotDataFoundException("No se registraron los datos");

            }
            return id;
        }
        public async Task<long> DeleteCondicionJuridicaxId(long id)
        {
            var condicionjuridica = await _condicionjuridicaPort.DeleteCondicionJuridicaxId(id);

            if (condicionjuridica == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return condicionjuridica;
        }
        public async Task<long> ActivarCondicionJuridicaxId(long id)
        {
            var condicionjuridica = await _condicionjuridicaPort.ActivarCondicionJuridicaxId(id);

            if (condicionjuridica == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return condicionjuridica;
        }
        public async Task<long> DesactivarCondicionJuridicaxId(long id)
        {
            var condicionjuridica = await _condicionjuridicaPort.DesactivarCondicionJuridicaxId(id);

            if (condicionjuridica == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return condicionjuridica;
        }
    }
}
