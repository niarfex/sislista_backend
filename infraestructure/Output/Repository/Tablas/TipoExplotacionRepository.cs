using AutoMapper;
using Dapper;
using Domain.Model;
using GeneralSQL;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Infra.MarcoLista.Output.Repository;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Reflection.Metadata;
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace Infra.MarcoLista.Output.Repository
{

    public class TipoExplotacionRepository: ITipoExplotacionRepository
    {
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        private DBOracle dBOracle = new DBOracle();
        public TipoExplotacionRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<TipoExplotacionEntity>> getListTipoexplotacion(ParamBusqueda parametros)
        {
            List<TipoExplotacionEntity> listTipoexplotacion = new List<TipoExplotacionEntity>();
            try
            {
                return listTipoexplotacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<TipoExplotacionEntity> getTipoexplotacionxUUID()
        {
            return null;
        }
        public async Task<TipoExplotacionEntity> createTipoexplotacion()
        {
            return null;
        }
        public async Task<TipoExplotacionEntity> updateTipoexplotacion()
        {
            return null;
        }
        public async Task<TipoExplotacionEntity> deleteTipoexplotacion()
        {
            return null;
        }
    }
}
