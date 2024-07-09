using AutoMapper;
using Dapper;
using Domain.Model;
using Infra.MarcoLista.Contextos;
using Infra.MarcoLista.GeneralSQL;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Infra.MarcoLista.Output.Repository;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Reflection.Metadata;
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace Infra.MarcoLista.Output.Repository
{
    public class GeneralRepository:IGeneralRepository
    {
        private MarcoListaContexto _db;
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        private DBOracle dBOracle = new DBOracle();
        public GeneralRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
            _db = new MarcoListaContexto(_configuracion[$"DatabaseSettings:ConnectionString1"]);
        }
        public async Task<List<CultivoModel>> GetAllCultivos()
        {
            //return _db.Ubigeo.ToList().FindAll(x => x.Id.ToUpper().Contains(param.ToUpper()) || x.Departamento.ToUpper().Contains(param.ToUpper()) || x.Provincia.ToUpper().Contains(param.ToUpper()) || x.Distrito.ToUpper().Contains(param.ToUpper()));
            string strCon = _configuracion.GetSection("DatabaseSettings")["ConnectionString1"];
            var conn = new OracleConnection(strCon);
            await conn.OpenAsync();
            List<CultivoModel> listCultivos = new List<CultivoModel>();
            try
            {
                CultivoFiltro cultivoFiltro = new CultivoFiltro();
                
                using (OracleDataReader dr = dBOracle.SelDrdResult(conn, null, "PKG_MANTENIMIENTO.SP_R_LISTAR_TG_CULTIVO", cultivoFiltro))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CultivoModel oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CultivoModel();
                                oCampos.Id = dr["IDE_CULTIVO"].ToString();
                                oCampos.Cultivo = dr["TXT_CULTIVO"].ToString();
                                listCultivos.Add(oCampos);
                            }
                        }
                    }
                }
                conn.Close();
                return listCultivos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<UbigeoModel>> GetAllUbigeo(int idTipo, string idUbigeo)
        {
            //return _db.Ubigeo.ToList().FindAll(x => x.Id.ToUpper().Contains(param.ToUpper()) || x.Departamento.ToUpper().Contains(param.ToUpper()) || x.Provincia.ToUpper().Contains(param.ToUpper()) || x.Distrito.ToUpper().Contains(param.ToUpper()));
            string strCon = _configuracion.GetSection("DatabaseSettings")["ConnectionString1"];
            var conn = new OracleConnection(strCon);
            await conn.OpenAsync();
            List<UbigeoModel> listUbigeos = new List<UbigeoModel>();
            try
            {
                UbigeoFiltro ubigeoFiltro = new UbigeoFiltro();
                ubigeoFiltro.TipoUbigeo = 4;
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
                                oCampos.Id = dr["IDE_DISTRITO"].ToString();
                                oCampos.Departamento = dr["TXT_DEPARTAMENTO"].ToString();
                                oCampos.Provincia = dr["TXT_PROVINCIA"].ToString();
                                oCampos.Distrito = dr["TXT_DISTRITO"].ToString();
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
        public async Task<List<UbigeoModel>> GetProvincias(int idTipo, string idUbigeo)
        {
            //return _db.Ubigeo.ToList().FindAll(x => x.Id.ToUpper().Contains(param.ToUpper()) || x.Departamento.ToUpper().Contains(param.ToUpper()) || x.Provincia.ToUpper().Contains(param.ToUpper()) || x.Distrito.ToUpper().Contains(param.ToUpper()));
            string strCon = _configuracion.GetSection("DatabaseSettings")["ConnectionString1"];
            var conn = new OracleConnection(strCon);
            await conn.OpenAsync();
            List<UbigeoModel> listUbigeos = new List<UbigeoModel>();
            try
            {
                UbigeoFiltro ubigeoFiltro = new UbigeoFiltro();
                ubigeoFiltro.TipoUbigeo = 2;
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
                                oCampos.Id = dr["IDE_PROVINCIA"].ToString();
                                oCampos.Provincia = dr["TXT_PROVINCIA"].ToString();
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
        public async Task<List<UbigeoModel>> GetDistritos(int idTipo, string idUbigeo)
        {
            //return _db.Ubigeo.ToList().FindAll(x => x.Id.ToUpper().Contains(param.ToUpper()) || x.Departamento.ToUpper().Contains(param.ToUpper()) || x.Provincia.ToUpper().Contains(param.ToUpper()) || x.Distrito.ToUpper().Contains(param.ToUpper()));
            string strCon = _configuracion.GetSection("DatabaseSettings")["ConnectionString1"];
            var conn = new OracleConnection(strCon);
            await conn.OpenAsync();
            List<UbigeoModel> listUbigeos = new List<UbigeoModel>();
            try
            {
                UbigeoFiltro ubigeoFiltro = new UbigeoFiltro();
                ubigeoFiltro.TipoUbigeo = 3;
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
                                oCampos.Id = dr["IDE_DISTRITO"].ToString();
                                oCampos.Distrito = dr["TXT_DISTRITO"].ToString();
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

        public async Task<List<TipoDocumentoEntity>> GetTipoDocumento()
        {
            return _db.TipoDocumento.ToList();
        }
        public async Task<PersonaEntity> GetPersonaxId(long id)
        {
            return _db.Persona.Where(x=> x.Id==id && (x.Estado==0 || x.Estado == 1)).FirstOrDefault() ;
        }
        public async Task<List<PerfilEntity>> GetPerfiles()
        {
            return _db.Perfil.Where(x => (x.Estado == 0 || x.Estado == 1) && x.CodigoPerfil != "PERFILTODOS").ToList();
        }
        public async Task<List<PerfilEntity>> GetPerfilesTodos()
        {
            return _db.Perfil.Where(x => x.Estado == 0 || x.Estado == 1).ToList();
        }
        public async Task<List<AnioEntity>> GetPeriodos()
        {
            return _db.Anio.Where(x => x.Estado == 0 || x.Estado == 1).OrderByDescending(x => x.Anio).ToList();
        }
        public async Task<List<PlantillaEntity>> GetPlantillasActivas()
        {
            return _db.Plantilla.Where(x =>  x.Estado == 1).ToList();
        }
        public async Task<List<FrecuenciaEntity>> GetFrecuencias()
        {
            return _db.Frecuencia.Where(x => x.Estado == 0 || x.Estado == 1).ToList();
        }
        public async Task<List<PanelRegistroEntity>> GetProgramacionesVigentes()
        {
            return _db.PanelRegistro.Where(x => x.Estado == 1 && (x.EstadoProgramacion ==1 || x.EstadoProgramacion == 2)).ToList();
        }
        public async Task<List<EtapaEntity>> GetEtapas()
        {
            return _db.Etapa.Where(x => x.Estado == 1).ToList();
        }
        public async Task<List<TenenciaEntity>> GetTenencias()
        {
            return _db.Tenencia.Where(x => x.Estado == 1).ToList();
        }
        public async Task<List<UsoTierraEntity>> GetUsoTierras()
        {
            return _db.UsoTierra.Where(x => x.Estado == 1).ToList();
        }
        public async Task<List<UsoNoAgricolaEntity>> GetUsoNoAgricolas()
        {
            return _db.UsoNoAgricola.Where(x => x.Estado == 1).ToList();
        }
        public async Task<List<EstadoEntity>> GetEstadoEntrevista()
        {
            return _db.Estado.Where(x => x.Estado == 1 && x.CodigoEstadoPadre== "ESTADOENTREVISTA").ToList();
        }
        public async Task<List<TipoInformacionEntity>> GetTipoInformacion()
        {
            return _db.TipoInformacion.Where(x => x.Estado == 1).ToList();
        }
    }
}
