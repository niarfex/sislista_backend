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
    public class CondicionJuridicaRepository: ICondicionJuridicaRepository
    {
        private MarcoListaContexto _db = new MarcoListaContexto();
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public CondicionJuridicaRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<CondicionJuridicaEntity>> GetAll(ParamBusqueda param)
        {
            return _db.CondicionJuridica.ToList();
        }
        public async Task<CondicionJuridicaEntity> getCondicionJuridica()
        {
            return null;
        }
        public async Task<CondicionJuridicaEntity> createCondicionJuridica()
        {
            return null;
        }
        public async Task<CondicionJuridicaEntity> updateCondicionJuridica()
        {
            return null;
        }
        public async Task<bool> deleteCondicionJuridica()
        {
            return false;
        }
    }
}
