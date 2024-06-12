using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class OrganizacionService : IOrganizacionService
    {
        private readonly IOrganizacionPort _organizacionPort;

        public OrganizacionService(IOrganizacionPort organizacionPort)
        {
            _organizacionPort = organizacionPort ?? throw new ArgumentNullException(nameof(organizacionPort));
        }
        public async Task<List<OrganizacionModel>> GetAll(ParamBusqueda param)
        {
            var organizacions = await _organizacionPort.GetAll(param);
            if (organizacions == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }

            return organizacions;
        }
    }
}
