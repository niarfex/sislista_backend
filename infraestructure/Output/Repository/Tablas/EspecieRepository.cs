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

    public class EspecieRepository: IEspecieRepository
    {
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        private DBOracle dBOracle = new DBOracle();
        public EspecieRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<EspecieEntity>> getEspecie(ParamBusqueda parametros)
        {
            List<EspecieEntity> listEspecie = new List<EspecieEntity>();
            try
            {
                return listEspecie;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<EspecieEntity> getEspeciexUUID()
        {
            return null;
        }
        public async Task<EspecieEntity> createEspecie()
        {
            return null;
        }
        public async Task<EspecieEntity> updateEspecie()
        {
            return null;
        }
        public async Task<EspecieEntity> deleteEspecie()
        {
            return null;
        }
    }
}
