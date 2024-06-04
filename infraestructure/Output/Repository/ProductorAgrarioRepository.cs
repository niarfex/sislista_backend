using AutoMapper;
using Dapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Infra.MarcoLista.Output.Repository;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace Infra.MarcoLista.Output.Repository
{
    public class ProductorAgrarioRepository : IProductorAgrarioRepository
    {
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        public ProductorAgrarioRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }

        public async Task<ProductorAgrarioEntity> getByNrodoc(string nrodoc)
        {
            string strCon = _configuracion.GetSection("DatabaseSettings")["ConnectionString1"];
            var conn = new OracleConnection(strCon);
            await conn.OpenAsync();
            var sql = $"SELECT TXT_NRODOC AS Nrodoc,TXT_NOMBRES As Nombres, TXT_APELLIDOPATERNO AS Paterno,TXT_APELLIDOMATERNO AS Materno,TXT_DIRECCION As Direccion,TXT_CELULAR As Celular FROM SPA_TG_PERSONA WHERE TXT_NRODOC = '{nrodoc}'";
            var entity = await conn.QueryAsync<ProductorAgrarioEntity>(sql);
            conn.Close();
            if (entity.Count() != 0)
                return entity.ToList()[0];
            else return null;
        }
    }
}
