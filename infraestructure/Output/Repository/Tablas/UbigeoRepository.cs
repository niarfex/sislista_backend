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

    public class UbigeoRepository: IUbigeoRepository
    {
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        private DBOracle dBOracle = new DBOracle();
        public UbigeoRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<UbigeoEntity>> getListUbigeos(ParamBusqueda parametros)
        {
            List<UbigeoEntity> listUbigeos = new List<UbigeoEntity>();
            try
            {
                return listUbigeos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<UbigeoEntity> getUbigeoxUUID()
        {
            return null;
        }
        public async Task<UbigeoEntity> createUbigeo()
        {
            return null;
        }
        public async Task<UbigeoEntity> updateUbigeo()
        {
            return null;
        }
        public async Task<UbigeoEntity> deleteUbigeo()
        {
            return null;
        }
    }
}
