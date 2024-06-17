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
    public class GeneralRepository:IGeneralRepository
    {
        private MarcoListaContexto _db = new MarcoListaContexto();
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        private DBOracle dBOracle = new DBOracle();

        public GeneralRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }

        public async Task<List<UbigeoModel>> GetDepartamentos(int idTipo,string idUbigeo)
        {
            //return _db.Ubigeo.ToList().FindAll(x => x.Id.ToUpper().Contains(param.ToUpper()) || x.Departamento.ToUpper().Contains(param.ToUpper()) || x.Provincia.ToUpper().Contains(param.ToUpper()) || x.Distrito.ToUpper().Contains(param.ToUpper()));
            string strCon = _configuracion.GetSection("DatabaseSettings")["ConnectionString1"];
            var conn = new OracleConnection(strCon);
            await conn.OpenAsync();
            List<UbigeoModel> listUbigeos = new List<UbigeoModel>();
            try
            {
                UbigeoFiltro ubigeoFiltro = new UbigeoFiltro();
                ubigeoFiltro.TipoUbigeo = 1;
                ubigeoFiltro.IdUbigeo = idUbigeo;
                using (OracleDataReader dr = dBOracle.SelDrdResult(conn, null, "PKG_MANTENIMIENTO.SP_R_LISTAR_TG_UBIGEO", ubigeoFiltro))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {

                            UbigeoModel oCampos;
                            while (dr.Read())
                            {
                                oCampos = new UbigeoModel();
                                oCampos.Id = dr["IDE_DEPARTAMENTO"].ToString();
                                oCampos.Departamento = dr["TXT_DEPARTAMENTO"].ToString();
                                listUbigeos.Add(oCampos);
                            }
                        }
                    }
                }
                conn.Close();
                return listUbigeos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<TipoOrganizacionEntity>> GetTipoOrganizacion()
        {
            return _db.TipoOrganizacion.ToList();
        }
    }
}
