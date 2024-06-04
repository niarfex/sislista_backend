using AutoMapper;
using Dapper;
using domain.Model;
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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        private DBOracle dBOracle = new DBOracle();
        public UsuarioRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<UsuarioEntity>> getListUsuarios(ParamBusqueda parametros)
        {
            string strCon = _configuracion.GetSection("DatabaseSettings")["ConnectionString1"];
            var conn = new OracleConnection(strCon);




            List<UsuarioEntity> listUsuarios = new List<UsuarioEntity>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(conn, null, "Esquema.Aqui_va_el_SP", parametros))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                  
                            UsuarioEntity oCampos;
                            while (dr.Read())
                            {
                                oCampos = new UsuarioEntity();
                                oCampos.TokenReseteoClave = dr["TXT_TOKEN_RESETEO_CLAVE"]==null?null: int.Parse(dr["TXT_TOKEN_RESETEO_CLAVE"].ToString());
                             
                                listUsuarios.Add(oCampos);
                            }
                        }
                    }
                }
                return listUsuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }
    }
}
