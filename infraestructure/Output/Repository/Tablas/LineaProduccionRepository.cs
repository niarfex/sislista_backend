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
using System.Reflection.Metadata;
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace Infra.MarcoLista.Output.Repository
{

    public class LineaProduccionRepository: ILineaProduccionRepository
    {
        private MarcoListaContexto _db = new MarcoListaContexto();
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public LineaProduccionRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<LineaProduccionEntity>> GetAll(ParamBusqueda param)
        {
            return _db.LineaProduccion.ToList();
        }
        public async Task<LineaProduccionEntity> getLineaProduccion()
        {
            return null;
        }
        public async Task<LineaProduccionEntity> createLineaProduccion()
        {
            return null;
        }
        public async Task<LineaProduccionEntity> updateLineaProduccion()
        {
            return null;
        }
        public async Task<bool> deleteLineaProduccion()
        {
            return false;
        }
    }
}
