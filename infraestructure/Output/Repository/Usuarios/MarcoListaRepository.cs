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
    public class MarcoListaRepository: IMarcoListaRepository
    {
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        private DBOracle dBOracle = new DBOracle();
        public MarcoListaRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<MarcoListaEntity>> getListMarcoLista(ParamBusqueda parametros)
        {
            List<MarcoListaEntity> listMarcoLista = new List<MarcoListaEntity>();
            try
            {
                return listMarcoLista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<MarcoListaEntity> getOrganizacionxUUID()
        {
            return null;
        }
        public async Task<MarcoListaEntity> createOrganizacion()
        {
            return null;
        }
        public async Task<MarcoListaEntity> updateOrganizacion()
        {
            return null;
        }
        public async Task<MarcoListaEntity> deleteOrganizacion()
        {
            return null;
        }
    }
}
