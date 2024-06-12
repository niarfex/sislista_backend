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

    public class EspecieRepository: IEspecieRepository
    {
        private MarcoListaContexto _db = new MarcoListaContexto();
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public EspecieRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<EspecieEntity>> GetAll(ParamBusqueda param)
        {
            return _db.Especie.ToList();
        }
        public async Task<EspecieEntity> getEspecie()
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
        public async Task<bool> deleteEspecie()
        {
            return false;
        }
    }
}
