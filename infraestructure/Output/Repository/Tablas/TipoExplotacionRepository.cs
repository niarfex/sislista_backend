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

    public class TipoExplotacionRepository: ITipoExplotacionRepository
    {
        private MarcoListaContexto _db = new MarcoListaContexto();
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public TipoExplotacionRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<TipoExplotacionEntity>> GetAll(ParamBusqueda param)
        {
            return _db.TipoExplotacion.ToList();
        }
        public async Task<TipoExplotacionEntity> getTipoExplotacion()
        {
            return null;
        }
        public async Task<TipoExplotacionEntity> createTipoExplotacion()
        {
            return null;
        }
        public async Task<TipoExplotacionEntity> updateTipoExplotacion()
        {
            return null;
        }
        public async Task<bool> deleteTipoExplotacion()
        {
            return false;
        }
    }
}
