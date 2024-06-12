using AutoMapper;
using Dapper;
using Domain.Model;
using Infra.MarcoLista.Contextos;
using Infra.MarcoLista.GeneralSQL;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Infra.MarcoLista.Output.Repository;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace Infra.MarcoLista.Output.Repository
{
    public class OrganizacionRepository : IOrganizacionRepository
    {
        private MarcoListaContexto _db = new MarcoListaContexto();
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public OrganizacionRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<OrganizacionEntity>> GetAll(ParamBusqueda param)
        {
            return _db.Organizacion.ToList();
        }
        public async Task<OrganizacionEntity> getOrganizacion()
        {
            return null;
        }
        public async Task<OrganizacionEntity> createOrganizacion()
        {
            return null;
        }
        public async Task<OrganizacionEntity> updateOrganizacion()
        {
            return null;
        }
        public async Task<bool> deleteOrganizacion()
        {
            return false;
        }
    }
}
