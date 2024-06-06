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

    public class LineaProduccionRepository: ILineaProduccionRepository
    {
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        private DBOracle dBOracle = new DBOracle();
        public LineaProduccionRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<LineaProduccionEntity>> getLineaproduccion(ParamBusqueda parametros)
        {
            List<LineaProduccionEntity> listLineaproduccion = new List<LineaProduccionEntity>();
            try
            {
                return listLineaproduccion;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<LineaProduccionEntity> getLineaproduccionxUUID()
        {
            return null;
        }
        public async Task<LineaProduccionEntity> createLineaproduccion()
        {
            return null;
        }
        public async Task<LineaProduccionEntity> updateLineaproduccion()
        {
            return null;
        }
        public async Task<LineaProduccionEntity> deleteLineaproduccion()
        {
            return null;
        }
    }
}
