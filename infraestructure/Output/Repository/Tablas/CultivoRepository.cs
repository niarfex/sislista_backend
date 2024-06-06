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

    public class CultivoRepository: ICultivoRepository
    {
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        private DBOracle dBOracle = new DBOracle();
        public CultivoRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<CultivoEntity>> getCultivo(ParamBusqueda parametros)
        {
            List<CultivoEntity> listCultivo = new List<CultivoEntity>();
            try
            {
                return listCultivo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<CultivoEntity> getCultivoxUUID()
        {
            return null;
        }
        public async Task<CultivoEntity> createCultivo()
        {
            return null;
        }
        public async Task<CultivoEntity> updateCultivo()
        {
            return null;
        }
        public async Task<CultivoEntity> deleteCultivo()
        {
            return null;
        }
    }
}
