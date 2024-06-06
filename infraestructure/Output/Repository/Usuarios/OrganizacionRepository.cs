using AutoMapper;
using Dapper;
using Domain.Model;
using GeneralSQL;
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
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        private DBOracle dBOracle = new DBOracle();
        public OrganizacionRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<OrganizacionEntity>> getListOrganizaciones(ParamBusqueda parametros)
        {
            List<OrganizacionEntity> listOrganizaciones = new List<OrganizacionEntity>();
            try
            {
                return listOrganizaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<UsuarioEntity> getOrganizacionxUUID()
        {
            return null;
        }
        public async Task<UsuarioEntity> createOrganizacion()
        {
            return null;
        }
        public async Task<UsuarioEntity> updateOrganizacion()
        {
            return null;
        }
        public async Task<UsuarioEntity> deleteOrganizacion()
        {
            return null;
        }
    }
}
