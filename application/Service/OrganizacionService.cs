using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class OrganizacionService : IOrganizacionService
    {
        private readonly IOrganizacionPort _organizacionPort;
        private readonly IUsuarioPort _usuarioPort;
        private readonly IGeneralPort _generalPort;

        public OrganizacionService(IOrganizacionPort organizacionPort,
            IUsuarioPort usuarioPort,
            IGeneralPort generalPort)
        {
            _organizacionPort = organizacionPort ?? throw new ArgumentNullException(nameof(organizacionPort));
            _usuarioPort = usuarioPort ?? throw new ArgumentNullException(nameof(usuarioPort));
            _generalPort = generalPort ?? throw new ArgumentNullException(nameof(generalPort));
        }
        public async Task<List<OrganizacionModel>> GetAll(string param)
        {
            var organizacions = await _organizacionPort.GetAll(param);
            var tipoOrganizacion = await _generalPort.GetTipoOrganizacion();
            var departamentos = await _generalPort.GetDepartamentos(1, "");
            if (organizacions == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            var usuarios = await _usuarioPort.GetAll("");
            var queryUsuarios = from o in organizacions
                                join u in usuarios on o.Id equals u.IdOrganizacion
                                where u.Estado == 1
                                select o;

            var query = from o in organizacions
                        join t in tipoOrganizacion on o.IdTipoOrganizacion equals t.Id
                        join d in departamentos on o.IdDepartamento equals d.Id
                        where o.Estado == 0 || o.Estado == 1
                        select new OrganizacionModel
                        {
                            Id = o.Id,
                            TipoOrganizacion = t.TipOrganizacion,
                            NumeroDocumento = o.NumeroDocumento,
                            Organizacion = o.Organizacion,
                            Departamento = d.Departamento,
                            Usuarios = (queryUsuarios.Where(x => x.Id==o.Id).Count()),
                            Estado = o.Estado
                        };
            return query.ToList();
        }
        public async Task<OrganizacionModel> GetOrganizacionxId(long id)
        {
            var organizacion = await _organizacionPort.GetOrganizacionxId(id);

            if (organizacion == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }           
            return organizacion;
        }
        public async Task<long> CreateOrganizacion(OrganizacionModel model)
        {
            var id = await _organizacionPort.CreateOrganizacion(model);
            if (id == null)
            {
                throw new NotDataFoundException("No se registraron los datos");

            }
            return id;
        }
        public async Task<long> DeleteOrganizacionxId(long id)
        {
            var organizacion = await _organizacionPort.DeleteOrganizacionxId(id);

            if (organizacion == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return organizacion;
        }
        public async Task<long> ActivarOrganizacionxId(long id)
        {
            var organizacion = await _organizacionPort.ActivarOrganizacionxId(id);

            if (organizacion == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return organizacion;
        }
        public async Task<long> DesactivarOrganizacionxId(long id)
        {
            var organizacion = await _organizacionPort.DesactivarOrganizacionxId(id);

            if (organizacion == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return organizacion;
        }
    }
}
