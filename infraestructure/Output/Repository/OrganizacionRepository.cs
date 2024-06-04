using AutoMapper;
using Dapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Infra.MarcoLista.Output.Repository;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace Infra.MarcoLista.Output.Repository
{
    public class OrganizacionRepository
    {
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        public OrganizacionRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
    }
}
