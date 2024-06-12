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
    public class MarcoListaRepository: IMarcoListaRepository
    {
        private MarcoListaContexto _db = new MarcoListaContexto();
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public MarcoListaRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<MarcoListaEntity>> GetAll(ParamBusqueda param)
        {
            return _db.MarcoLista.ToList();
        }
        public async Task<MarcoListaEntity> getMarcoListaxUUID()
        {
            return null;
        }
        public async Task<MarcoListaEntity> createMarcoListaxUUID()
        {
            return null;
        }
        public async Task<MarcoListaEntity> updateMarcoListaxUUID()
        {
            return null;
        }
        public async Task<bool> deleteMarcoListaxUUID()
        {
            return false;
        }
    }
}
