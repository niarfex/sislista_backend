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
    public class CondicionJuridicaRepository: ICondicionJuridicaRepository
    {
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        private DBOracle dBOracle = new DBOracle();
        public CondicionJuridicaRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<CondicionJuridicaEntity>> getCondicionjuridica(ParamBusqueda parametros)
        {
            List<CondicionJuridicaEntity> listCondicionjuridica = new List<CondicionJuridicaEntity>();
            try
            {
                return listCondicionjuridica;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<CondicionJuridicaEntity> getCondicionjuridicaxUUID()
        {
            return null;
        }
        public async Task<CondicionJuridicaEntity> createCondicionjuridica()
        {
            return null;
        }
        public async Task<CondicionJuridicaEntity> updateCondicionjuridica()
        {
            return null;
        }
        public async Task<CondicionJuridicaEntity> deleteCondicionjuridica()
        {
            return null;
        }
    }
}
