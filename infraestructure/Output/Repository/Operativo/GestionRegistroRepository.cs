using AutoMapper;
using Dapper;
using Domain.Model;
using Infra.MarcoLista.Contextos;
using Infra.MarcoLista.GeneralSQL;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Infra.MarcoLista.Output.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Reflection.Metadata;
using System.Xml.Linq;
using static Dapper.SqlMapper;
using com.openkm.sdk4csharp;
using com.openkm.sdk4csharp.bean;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infra.MarcoLista.Output.Repository
{
    public class GestionRegistroRepository : IGestionRegistroRepository
    {
        private MarcoListaContexto _db;
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private DBOracle dBOracle = new DBOracle();
        private readonly string _archivosDirectory;
        private readonly string _hostOKM;
        private readonly string _userOKM;
        private readonly string _passOKM;
        public GestionRegistroRepository(IConfiguration configuracion,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _configuracion = configuracion;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _db = new MarcoListaContexto(_configuracion[$"DatabaseSettings:ConnectionSISLISTA"]);
            _archivosDirectory = _configuracion[$"openKMconf:rutaCarpeta"];
            _hostOKM = _configuracion[$"openKMconf:rutaServer"];
            _userOKM = _configuracion[$"openKMconf:usuario"];
            _passOKM = _configuracion[$"openKMconf:clave"];
        }
        public async Task<List<GestionRegistroModel>> GetAll(string param, string uuid)
        {
            List<GestionRegistroModel> listaCuestionarios = new List<GestionRegistroModel>();
            /*var queryUsu = from u in _db.Usuario
                           join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                           join p in _db.Perfil on up.IdPerfil equals p.Id
                           where u.CodigoUUID.ToString() == uuid
                           select p;
            var codPerfil = queryUsu.FirstOrDefault().CodigoPerfil;*/

            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];


            if (usuario.CodigoPerfil == "PERFILADM")
            {
                var query = from u in _db.Usuario
                            join um in _db.UsuarioMarcoLista on u.Id equals um.IdUsuario
                            join m in _db.MarcoLista on um.IdMarcoLista equals m.Id
                            join pe in _db.Persona on m.IdPersona equals pe.Id
                            join a in _db.Anio on m.IdAnio equals a.Id
                            join te in _db.TipoExplotacion on m.IdTipoExplotacion equals te.Id
                            from cu in _db.GestionRegistro.Where(x => x.IdMarcoLista == m.Id).DefaultIfEmpty()
                            from tec in _db.TipoExplotacion.Where(x => x.Id == cu.IdTipoExplotacion).DefaultIfEmpty()
                            from info in _db.Informante.Where(x => x.IdCuestionario == cu.Id).DefaultIfEmpty()
                            from eEnt in _db.Estado.Where(x => x.Id == info.IdEstado).DefaultIfEmpty()
                            from eSup in _db.Estado.Where(x => x.Id == cu.EstadoSupervision).DefaultIfEmpty()
                            from eVal in _db.Estado.Where(x => x.Id == cu.EstadoValidacion).DefaultIfEmpty()
                            from eReg in _db.Estado.Where(x => x.Id == cu.EstadoRegistro).DefaultIfEmpty()
                            where pe.NumeroDocumento.Contains(param.Trim().ToUpper()) ||
                            pe.RazonSocial.ToUpper().Contains(param.Trim().ToUpper()) ||
                            pe.Nombre.ToUpper().Contains(param.Trim().ToUpper()) ||
                            pe.ApellidoPaterno.ToUpper().Contains(param.Trim().ToUpper()) ||
                            pe.ApellidoMaterno.ToUpper().Contains(param.Trim().ToUpper())
                            orderby (cu.FechaRegistro == null ? m.FechaRegistro : cu.FechaRegistro) descending
                            select new GestionRegistroModel
                            {
                                CodigoUUID = cu.CodigoUUID,
                                IdPeriodo = a.Id,
                                Periodo = a.Anio,
                                NombreCompleto = pe.RazonSocial.IsNullOrEmpty() ? (pe.Nombre + " " + pe.ApellidoPaterno + " " + pe.ApellidoMaterno) : pe.RazonSocial,
                                NumeroDocumento = pe.NumeroDocumento,
                                TipoExplotacion = tec.TipoExplotacion==null?te.TipoExplotacion: tec.TipoExplotacion,
                                UsuarioCreacion = cu != null ? cu.UsuarioCreacion : "",
                                FechaRegistro = cu != null ? cu.FechaRegistro : null,
                                UsuarioActualizacion = cu != null ? cu.UsuarioActualizacion : "",
                                FechaActualizacion = cu != null ? cu.FechaActualizacion : null,
                                CodigoEstadoEntrevista = eEnt != null ? eEnt.CodigoEstado : null,
                                CodigoEstadoSupervision = eSup != null ? eSup.CodigoEstado : null,
                                CodigoEstadoValidacion = eVal != null ? eVal.CodigoEstado : null,
                                CodigoEstadoRegistro = eReg != null ? eReg.CodigoEstado : null,
                                NombreEstadoEntrevista = eEnt != null ? eEnt.TipoEstado : null,
                                NombreEstadoSupervision = eSup != null ? eSup.TipoEstado : null,
                                NombreEstadoValidacion = eVal != null ? eVal.TipoEstado : null,
                                NombreEstadoRegistro = eReg != null ? eReg.TipoEstado : "POR REGISTRAR",
                                Clasificacion = ""
                            };
                listaCuestionarios = query.ToList();
            }
            else if (usuario.CodigoPerfil == "PERFILEMP" ||
                usuario.CodigoPerfil == "PERFILSUP" ||
                usuario.CodigoPerfil == "PERFILESP")
            {
                var query = from u in _db.Usuario
                            join um in _db.UsuarioMarcoLista on u.Id equals um.IdUsuario
                            join m in _db.MarcoLista on um.IdMarcoLista equals m.Id
                            join pe in _db.Persona on m.IdPersona equals pe.Id
                            join a in _db.Anio on m.IdAnio equals a.Id
                            from te in _db.TipoExplotacion.Where(x => x.Id == m.IdTipoExplotacion).DefaultIfEmpty()
                            from cu in _db.GestionRegistro.Where(x => x.IdMarcoLista == m.Id).DefaultIfEmpty()
                            from info in _db.Informante.Where(x => x.IdCuestionario == cu.Id).DefaultIfEmpty()
                            from eEnt in _db.Estado.Where(x => x.Id == info.IdEstado).DefaultIfEmpty()
                            from eSup in _db.Estado.Where(x => x.Id == cu.EstadoSupervision).DefaultIfEmpty()
                            from eVal in _db.Estado.Where(x => x.Id == cu.EstadoValidacion).DefaultIfEmpty()
                            from eReg in _db.Estado.Where(x => x.Id == cu.EstadoRegistro).DefaultIfEmpty()
                            where u.CodigoUUID.ToString() == uuid && (
                            pe.NumeroDocumento.Contains(param.Trim().ToUpper()) ||
                            pe.RazonSocial.ToUpper().Contains(param.Trim().ToUpper()) ||
                            pe.Nombre.ToUpper().Contains(param.Trim().ToUpper()) ||
                            pe.ApellidoPaterno.ToUpper().Contains(param.Trim().ToUpper()) ||
                            pe.ApellidoMaterno.ToUpper().Contains(param.Trim().ToUpper()) ||
                            te.TipoExplotacion.ToUpper().Contains(param.Trim().ToUpper()))
                            orderby (cu.FechaRegistro == null ? m.FechaRegistro : cu.FechaRegistro) descending
                            select new GestionRegistroModel
                            {
                                CodigoUUID = cu.CodigoUUID,
                                IdPeriodo = a.Id,
                                Periodo = a.Anio,
                                NombreCompleto = pe.RazonSocial.IsNullOrEmpty() ? (pe.Nombre + " " + pe.ApellidoPaterno + " " + pe.ApellidoMaterno) : pe.RazonSocial,
                                NumeroDocumento = pe.NumeroDocumento,
                                TipoExplotacion = te != null ? te.TipoExplotacion : "",
                                UsuarioCreacion = cu != null ? cu.UsuarioCreacion : "",
                                FechaRegistro = cu != null ? cu.FechaRegistro : null,
                                UsuarioActualizacion = cu != null ? cu.UsuarioActualizacion : "",
                                FechaActualizacion = cu != null ? cu.FechaActualizacion : null,
                                CodigoEstadoEntrevista = eEnt != null ? eEnt.CodigoEstado : null,
                                CodigoEstadoSupervision = eSup != null ? eSup.CodigoEstado : null,
                                CodigoEstadoValidacion = eVal != null ? eVal.CodigoEstado : null,
                                CodigoEstadoRegistro = eReg != null ? eReg.CodigoEstado : null,
                                NombreEstadoEntrevista = eEnt != null ? eEnt.TipoEstado : null,
                                NombreEstadoSupervision = eSup != null ? eSup.TipoEstado : null,
                                NombreEstadoValidacion = eVal != null ? eVal.TipoEstado : null,
                                NombreEstadoRegistro = eReg != null ? eReg.TipoEstado : "POR REGISTRAR",
                                Clasificacion = ""
                            };
                listaCuestionarios = query.ToList();
            }
            return listaCuestionarios;
        }
        public async Task<GestionRegistroEntity> GetGestionRegistroxUUID(string uuid)
        {

            return _db.GestionRegistro.Where(x => x.CodigoUUID == uuid).FirstOrDefault();
        }
        public async Task<GestionRegistroModel> GetUUIDCuestionario(string numDoc, long idPeriodo)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];

            var query = from c in _db.GestionRegistro
                        join m in _db.MarcoLista on c.IdMarcoLista equals m.Id
                        join p in _db.Persona on m.IdPersona equals p.Id
                        from eSup in _db.Estado.Where(x => x.Id == c.EstadoSupervision).DefaultIfEmpty()
                        from eVal in _db.Estado.Where(x => x.Id == c.EstadoValidacion).DefaultIfEmpty()
                        from eReg in _db.Estado.Where(x => x.Id == c.EstadoRegistro).DefaultIfEmpty()
                        where c.NumeroDocumento == numDoc && m.IdAnio == idPeriodo
                        select new GestionRegistroModel
                        {
                            Id = c.Id,
                            IdPeriodo = m.IdAnio,
                            CodigoUUID = c.CodigoUUID,
                            IdMarcoLista = m.Id,
                            IdTipoExplotacion = c.IdTipoExplotacion,
                            Estado = c.Estado,
                            IdTipoDocumento = p.IdTipoDocumento,
                            IdCondicionJuridica = p.IdCondicionJuridica,
                            IdUbigeo = c.IdUbigeo,
                            NumeroDocumento = p.NumeroDocumento,
                            Nombre = p.Nombre,
                            ApellidoPaterno = p.ApellidoPaterno,
                            ApellidoMaterno = p.ApellidoMaterno,
                            RazonSocial = p.RazonSocial,
                            Celular = c.Celular,
                            Telefono = c.Telefono,
                            CorreoElectronico = c.CorreoElectronico,
                            PaginaWeb = c.PaginaWeb,
                            DireccionFiscalDomicilio = c.DireccionFiscalDomicilio,
                            NombreRepLegal = c.NombreRepLegal,
                            CorreoRepLegal = c.CorreoRepLegal,
                            CelularRepLegal = c.CelularRepLegal,
                            TieneRuc = c.TieneRuc,
                            FechaActualizacion = c.FechaActualizacion,
                            CodigoEstadoSupervision = eSup != null ? eSup.CodigoEstado : null,
                            CodigoEstadoValidacion = eVal != null ? eVal.CodigoEstado : null,
                            CodigoEstadoRegistro = eReg != null ? eReg.CodigoEstado : null
                        };

            if (query.FirstOrDefault() == null)
            {
                var queryML = from m in _db.MarcoLista
                              join um in _db.UsuarioMarcoLista on m.Id equals um.IdMarcoLista
                              join u in _db.Usuario on um.IdUsuario equals u.Id
                              join p in _db.Persona on m.IdPersona equals p.Id
                              where p.NumeroDocumento == numDoc && m.IdAnio == idPeriodo
                              && u.CodigoUUID == usuario.CodigoUUID
                              select new GestionRegistroModel
                              {
                                  Id = 0,
                                  CodigoUUID = "",
                                  IdPeriodo = m.IdAnio,
                                  IdMarcoLista = m.Id,
                                  IdTipoExplotacion = m.IdTipoExplotacion,
                                  Estado = m.Estado,
                                  IdTipoDocumento = p.IdTipoDocumento,
                                  IdCondicionJuridica = p.IdCondicionJuridica,
                                  IdUbigeo = p.IdUbigeo,
                                  NumeroDocumento = p.NumeroDocumento,
                                  Nombre = p.Nombre,
                                  ApellidoPaterno = p.ApellidoPaterno,
                                  ApellidoMaterno = p.ApellidoMaterno,
                                  RazonSocial = p.RazonSocial,
                                  Celular = p.Celular,
                                  Telefono = p.Telefono,
                                  CorreoElectronico = p.CorreoElectronico,
                                  PaginaWeb = p.PaginaWeb,
                                  DireccionFiscalDomicilio = p.DireccionFiscalDomicilio,
                                  NombreRepLegal = p.NombreRepLegal,
                                  CorreoRepLegal = p.CorreoRepLegal,
                                  CelularRepLegal = p.CelularRepLegal,
                                  TieneRuc = p.TieneRuc,
                                  FechaActualizacion = null,
                                  CodigoEstadoSupervision = null,
                                  CodigoEstadoValidacion = null,
                                  CodigoEstadoRegistro = null,
                              };
                return queryML.FirstOrDefault();
            }
            else
            {
                return query.FirstOrDefault();
            }

        }
        public async Task<List<ArchivoModel>> GetArchivosCuestionario(string uuid)
        {
            List<GestionRegistroModel> listaCuestionarios = new List<GestionRegistroModel>();
            var query = from c in _db.GestionRegistro
                        join ar in _db.Archivo on c.Id equals ar.IdCuestionario
                        join tp in _db.TipoInformacion on ar.IdTipoInformacion equals tp.Id
                        where c.CodigoUUID.ToString() == uuid && ar.Estado==1
                        select new ArchivoModel
                        {
                            Id = ar.Id,
                            NombreArchivo = ar.NombreArchivo,
                            DescripcionArchivo = ar.DescripcionArchivo,
                            TipoInformacion = tp.TipoInformacion,
                            Peso = ar.Peso
                        };

            return query.ToList();
        }
        public async Task<List<FundoModel>> GetFundosCuestionario(string uuid)
        {
            var query = from c in _db.GestionRegistro
                        join f in _db.Fundo on c.Id equals f.IdCuestionario
                        where c.CodigoUUID == uuid && f.Estado==1
                        select new FundoModel
                        {
                            Id=f.Id,
                            Fundo=f.Fundo,
                            SuperficieTotal=f.SuperficieTotal,
                            SuperficieAgricola=f.SuperficieAgricola,
                            IdUbigeo=f.IdUbigeo,
                            Observacion=f.Observacion,
                            ListCampos=(from ca in _db.Campo where ca.IdFundo==f.Id
                                        select new CampoModel {
                                        Id=ca.Id,
                                        Campo=ca.Campo,
                                        IdTenencia=ca.IdTenencia==null?0: ca.IdTenencia,
                                        Superficie=ca.Superficie,
                                        IdUsoTierra=ca.IdUsoTierra == null ? 0 : ca.IdUsoTierra,
                                        IdCultivo=ca.IdCultivo == null ? 0 : ca.IdCultivo,
                                        SuperficieCultivada=ca.SuperficieCultivada,
                                        IdUsoNoAgricola=ca.IdUsoNoAgricola == null ? 0 : ca.IdUsoNoAgricola,
                                        Observacion=ca.Observacion,
                                        }).ToList()
                        };
            return query.ToList();
        }
        public async Task<List<InformanteModel>> GetInformantesCuestionario(string uuid)
        {
            var query = from inf in _db.Informante
                        join pe in _db.Persona on inf.IdPersona equals pe.Id
                        join e in _db.Estado on inf.IdEstado equals e.Id
                        join cu in _db.GestionRegistro on inf.IdCuestionario equals cu.Id
                        where inf.Estado == 1 && cu.CodigoUUID==uuid
                        select new InformanteModel
                        {
                            Id=inf.Id,
                            Nombre=pe.Nombre,
                            ApellidoPaterno=pe.ApellidoPaterno,
                            ApellidoMaterno=pe.ApellidoMaterno,
                            NombreCompleto=pe.Nombre + " " +pe.ApellidoPaterno+" "+pe.ApellidoMaterno,
                            Cargo=pe.Cargo,
                            Correo=pe.CorreoElectronico,
                            Celular=pe.Celular,
                            Telefono=pe.Telefono,
                            IdEstado=inf.IdEstado,
                            EstadoEntrevista=e.TipoEstado,
                            Observacion=inf.Observacion,
                            Direccion=inf.Direccion,
                            CoordenadaEste=inf.CoordenadaEste,
                            CoordenadaNorte=inf.CoordenadaNorte
                        };
            return query.ToList();
        }
        public async Task<List<PecuarioModel>> GetPecuariosCuestionario(string uuid)
        {
            var query = from p in _db.Pecuario
                        join c in _db.Campo on p.IdCampo equals c.Id
                        join f in _db.Fundo on c.IdFundo equals f.Id
                        join sp in _db.SistemaPecuario on p.IdSistemaPecuario equals sp.Id
                        join cu in _db.GestionRegistro on f.IdCuestionario equals cu.Id
                        from lp in _db.LineaProduccion.Where(x => x.Id == p.IdLineaProduccion).DefaultIfEmpty()
                        from esp in _db.Especie.Where(x => x.Id == p.IdEspecie).DefaultIfEmpty()
                        where p.Estado == 1 && cu.CodigoUUID == uuid
                        select new PecuarioModel { 
                        Id=p.Id,
                        IdFundo=f.Id,
                        IdCampo=c.Id,
                        Campo=c.Campo,
                        IdSistemaPecuario=p.IdSistemaPecuario,
                        SistemaPecuario=sp.SistemaPecuario,
                        IdLineaProduccion=p.IdLineaProduccion,
                        IdEspecie=p.IdEspecie,
                        Animal=(lp!=null?lp.DescripcionLineaProduccion:(esp!=null?esp.DescripcionEspecie:"")),
                        Cantidad=p.Cantidad
                        };
            return query.ToList();

        }
        public async Task<List<TrazabilidadModel>> GetObservacionesCuestionario(string uuid)
        {
            var query = from cu in _db.GestionRegistro
                        join t in _db.Trazabilidad on cu.Id equals t.IdCuestionario
                        join s in _db.Seccion on t.IdSeccion equals s.Id
                        where t.Estado == 1 && cu.CodigoUUID == uuid
                        select new TrazabilidadModel { 
                        Id=t.Id,
                        IdSeccion=s.Id,
                        Seccion=s.Seccion,
                        Observacion=t.Observacion,
                        Perfil=t.Perfil
                        };
            return query.ToList();
        }
        public async Task<string> CreateCuestionario(GestionRegistroModel model)
        {
            GestionRegistroEntity objCuestionario = new GestionRegistroEntity();
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            string estadoRegistro = "";

            var codEntrevista = (from ent in _db.Estado.Where(x => x.Id == model.ListInformantes.FirstOrDefault().IdEstado)
                                 select ent).FirstOrDefault().CodigoEstado;
            if (codEntrevista == "ESTADOENTREVISTACOMPLETO")
            {
                estadoRegistro = "PARAREVISAR";
                //Como resultado se debe notificar al supervisor
            }
            else if (codEntrevista == "ESTADOENTREVISTAINCOMPLETO")
            {
                estadoRegistro = "TRABAJOGABINETE";
            }
            else if (codEntrevista == "ESTADOENTREVISTAAUSENTE" || codEntrevista == "ESTADOENTREVISTARECHAZO")
            {
                estadoRegistro = "ENALERTA";
            }
            var idEstado = (from ent in _db.Estado.Where(x => x.CodigoEstado == estadoRegistro)
                            select ent).FirstOrDefault().Id;

            if (model.CodigoUUID != null)
            {
                objCuestionario = _db.GestionRegistro.Where(x => x.CodigoUUID.ToString() == model.CodigoUUID).FirstOrDefault();

                /* Estos campos no se modifican porque ayudan a identificar al cuestionario y al elemento del marco de lista
                 * 
                objCuestionario.IdPPA = model.IdPPA;
                objCuestionario.IdMarcoLista = model.IdMarcoLista;
                objCuestionario.IdCondicionJuridica = model.IdCondicionJuridica;
                objCuestionario.IdTipoDocumento = model.IdTipoDocumento;
                objCuestionario.CodigoIdentificacion = model.CodigoIdentificacion;
                objCuestionario.NumeroDocumento = model.NumeroDocumento;
                */
                objCuestionario.Nombre = model.Nombre;
                objCuestionario.ApellidoPaterno = model.ApellidoPaterno;
                objCuestionario.ApellidoMaterno = model.ApellidoMaterno;
                objCuestionario.RazonSocial = model.RazonSocial;
                objCuestionario.DireccionFiscalDomicilio = model.DireccionFiscalDomicilio;
                objCuestionario.IdUbigeo = model.IdUbigeo;
                objCuestionario.IdTipoExplotacion = model.IdTipoExplotacion;
                objCuestionario.Telefono = model.Telefono;
                objCuestionario.Celular = model.Celular;
                objCuestionario.CorreoElectronico = model.CorreoElectronico;
                objCuestionario.PaginaWeb = model.PaginaWeb;
                objCuestionario.NombreRepLegal = model.NombreRepLegal;
                objCuestionario.CorreoRepLegal = model.CorreoRepLegal;
                objCuestionario.CelularRepLegal = model.CelularRepLegal;
                objCuestionario.CantidadFundo = model.CantidadFundo;
                objCuestionario.TieneRuc = model.TieneRuc;


                objCuestionario.EstadoRegistro = (int)idEstado;
                objCuestionario.FechaActualizacion = DateTime.Now;
                objCuestionario.UsuarioActualizacion = usuario.Usuario;
                _db.GestionRegistro.Update(objCuestionario);
                _db.SaveChanges();

                //return objCuestionario.CodigoUUID.ToString();
            }
            else
            {
                objCuestionario = new GestionRegistroEntity()
                {
                    CodigoUUID = Guid.NewGuid().ToString(),
                    IdPPA = model.IdPPA,
                    IdMarcoLista = model.IdMarcoLista,
                    IdCondicionJuridica = model.IdCondicionJuridica,
                    IdTipoDocumento = model.IdTipoDocumento,
                    CodigoIdentificacion = model.CodigoIdentificacion,
                    NumeroDocumento = model.NumeroDocumento,
                    Nombre = model.Nombre,
                    ApellidoPaterno = model.ApellidoPaterno,
                    ApellidoMaterno = model.ApellidoMaterno,
                    RazonSocial = model.RazonSocial,
                    DireccionFiscalDomicilio = model.DireccionFiscalDomicilio,
                    IdUbigeo = model.IdUbigeo,
                    IdTipoExplotacion = model.IdTipoExplotacion,
                    Telefono = model.Telefono,
                    Celular = model.Celular,
                    CorreoElectronico = model.CorreoElectronico,
                    PaginaWeb = model.PaginaWeb,
                    NombreRepLegal = model.NombreRepLegal,
                    CorreoRepLegal = model.CorreoRepLegal,
                    CelularRepLegal = model.CelularRepLegal,
                    CantidadFundo = model.CantidadFundo,
                    TieneRuc = model.TieneRuc,
                    EstadoRegistro = idEstado,
                    EstadoSupervision = null,
                    EstadoValidacion = null,
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = usuario.Usuario
                };
                _db.GestionRegistro.Add(objCuestionario);
                _db.SaveChanges();
            }
            //Registro de Fundos

            //Registro de Pecuarios dentro del registro de Campos de los Fundos

            var filasPecuario = from inf in _db.Pecuario
                                join cam in _db.Campo on inf.IdCampo equals cam.Id
                                join fun in _db.Fundo on cam.IdFundo equals fun.Id
                                where fun.IdCuestionario == objCuestionario.Id
                                select inf;
            _db.Pecuario.RemoveRange(filasPecuario);
            _db.SaveChanges();

            foreach (var fundo in model.ListFundos)
            {
                if (fundo.Id > 0)
                {
                    var objFundo = _db.Fundo.Where(x => x.Id == fundo.Id).FirstOrDefault();
                    objFundo.Fundo = fundo.Fundo;
                    objFundo.IdUbigeo = fundo.IdUbigeo;
                    objFundo.Observacion = fundo.Observacion;
                    objFundo.SuperficieAgricola = fundo.SuperficieAgricola;
                    objFundo.SuperficieTotal = fundo.SuperficieTotal;
                    objFundo.FechaActualizacion = DateTime.Now;
                    objFundo.UsuarioActualizacion = usuario.Usuario;
                    _db.Fundo.Update(objFundo);
                    _db.SaveChanges();

                    foreach (var campo in fundo.ListCampos)
                    {
                        if (campo.Id > 0)
                        {
                            var objCampo = _db.Campo.Where(x => x.Id == campo.Id).FirstOrDefault();
                            objCampo.Campo = campo.Campo;
                            objCampo.IdTenencia = campo.IdTenencia == 0 ? null : campo.IdTenencia;
                            objCampo.IdUsoTierra = campo.IdUsoTierra == 0 ? null : campo.IdUsoTierra;
                            objCampo.IdCultivo = campo.IdCultivo == 0 ? null : campo.IdCultivo;
                            objCampo.IdUsoNoAgricola = campo.IdUsoNoAgricola == 0 ? null : campo.IdUsoNoAgricola;
                            objCampo.Observacion = campo.Observacion;
                            objCampo.Superficie = campo.Superficie;
                            objCampo.SuperficieCultivada = campo.SuperficieCultivada;
                            objCampo.FechaActualizacion = DateTime.Now;
                            objCampo.UsuarioActualizacion = usuario.Usuario;
                        }
                        else
                        {
                            var objCampo = new CampoEntity()
                            {
                                IdFundo = objFundo.Id,
                                Campo = campo.Campo,
                                IdTenencia = campo.IdTenencia == 0 ? null : campo.IdTenencia,
                                IdUsoTierra = campo.IdUsoTierra == 0 ? null : campo.IdUsoTierra,
                                IdCultivo = campo.IdCultivo == 0 ? null : campo.IdCultivo,
                                IdUsoNoAgricola = campo.IdUsoNoAgricola == 0 ? null : campo.IdUsoNoAgricola,
                                Observacion = campo.Observacion,
                                Superficie = campo.Superficie,
                                SuperficieCultivada = campo.SuperficieCultivada,
                                Estado = 1,
                                FechaRegistro = DateTime.Now,
                                UsuarioCreacion = usuario.Usuario
                            };
                            _db.Campo.Add(objCampo);
                            _db.SaveChanges();
                        }
                    }

                }
                else
                {
                    var objFundo = new FundoEntity()
                    {
                        IdCuestionario = objCuestionario.Id,
                        Fundo = fundo.Fundo,
                        IdUbigeo = fundo.IdUbigeo,
                        Observacion = fundo.Observacion,
                        SuperficieTotal = fundo.SuperficieTotal,
                        SuperficieAgricola = fundo.SuperficieAgricola,
                        Estado = 1,
                        FechaRegistro = DateTime.Now,
                        UsuarioCreacion = usuario.Usuario
                    };
                    _db.Fundo.Add(objFundo);
                    _db.SaveChanges();

                    foreach (var campo in fundo.ListCampos)
                    {
                        var objCampo = new CampoEntity()
                        {
                            IdFundo = objFundo.Id,
                            Campo = campo.Campo,
                            IdTenencia = campo.IdTenencia == 0 ? null : campo.IdTenencia,
                            IdUsoTierra = campo.IdUsoTierra == 0 ? null : campo.IdUsoTierra,
                            IdCultivo = campo.IdCultivo == 0 ? null : campo.IdCultivo,
                            IdUsoNoAgricola = campo.IdUsoNoAgricola == 0 ? null : campo.IdUsoNoAgricola,
                            Observacion = campo.Observacion,
                            Superficie = campo.Superficie,
                            SuperficieCultivada = campo.SuperficieCultivada,
                            Estado = 1,
                            FechaRegistro = DateTime.Now,
                            UsuarioCreacion = usuario.Usuario
                        };
                        _db.Campo.Add(objCampo);
                        _db.SaveChanges();

                        //Registrar los Pecuarios
                        foreach (var pecu in model.ListPecuarios.FindAll(x => x.OrdenFundo == fundo.Orden && x.OrdenCampo == campo.Orden))
                        {
                            var objPecuario = new PecuarioEntity()
                            {
                                IdFundo = objFundo.Id,
                                IdCampo = objCampo.Id,
                                IdSistemaPecuario = pecu.SistemaPecuario == "LÍNEA DE PRODUCCIÓN" ? 1 : (pecu.SistemaPecuario == "ESPECIE" ? 2 : null),
                                IdLineaProduccion = pecu.IdLineaProduccion==0?null: pecu.IdLineaProduccion,
                                IdEspecie = pecu.IdEspecie==0?null: pecu.IdEspecie,
                                Cantidad = pecu.Cantidad,
                                Estado = 1,
                                FechaRegistro = DateTime.Now,
                                UsuarioCreacion = usuario.Usuario
                            };
                            _db.Pecuario.Add(objPecuario);
                            _db.SaveChanges();
                        }

                    }
                }

            }

            //Registro de Archivos
            var filasArch = from inf in _db.Archivo
                            where inf.IdCuestionario == objCuestionario.Id
                            select inf;

            _db.Archivo.RemoveRange(filasArch);
            _db.SaveChanges();

            foreach (var arch in model.ListArchivos)
            {
                var objArchivo = new ArchivoEntity()
                {
                    IdCuestionario = objCuestionario.Id,
                    NombreArchivo = arch.NombreArchivo,
                    Archivo = arch.Archivo,
                    DescripcionArchivo = arch.DescripcionArchivo,
                    CuestionarioPrincipal = arch.CuestionarioPrincipal,
                    IdTipoInformacion = arch.IdTipoInformacion,
                    Peso = arch.Peso,
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = usuario.Usuario
                };
                _db.Archivo.Add(objArchivo);
                _db.SaveChanges();

                if (arch.Id == 0) {

                    //Registro de archivos
                    OKMWebservice ws = OKMWebservicesFactory.newInstance(_hostOKM, _userOKM, _passOKM);

                    var filepathsrc = Path.Combine(Directory.GetCurrentDirectory(), "Temp", model.NumeroDocumento + "-" + model.IdPeriodo.ToString());
                    //filepath = filepath + "\\" + updateEntity.txt_nrodoc;
                    var filepath = _archivosDirectory + model.NumeroDocumento + "-" + model.IdPeriodo.ToString();

                    QueryParams qParamsF = new QueryParams();
                    qParamsF.domain = QueryParams.FOLDER;
                    qParamsF.name = "SISLISTA";
                    if (ws.find(qParamsF).Count() == 0)
                    {
                        ws.createFolderSimple("/okm:root/SISLISTA");
                    }
                    qParamsF.domain = QueryParams.FOLDER;
                    qParamsF.name = model.NumeroDocumento + "-" + model.IdPeriodo.ToString();
                    if (ws.find(qParamsF).FindAll(p => p.node.path.Contains(_archivosDirectory)).Count() == 0)
                    {
                        ws.createFolderSimple(filepath);
                    }
                    if (arch != null)
                    {
                        string src = filepathsrc + "\\" + arch.NombreArchivo;
                        string dest = _archivosDirectory + model.NumeroDocumento + "-" + model.IdPeriodo.ToString() + "/" + arch.NombreArchivo;

                        FileStream fileStream = new FileStream(src, FileMode.Open);

                        QueryParams qParams = new QueryParams();
                        qParams.domain = QueryParams.DOCUMENT;
                        qParams.name = arch.NombreArchivo;
                        if (ws.find(qParams).FindAll(p => p.node.path.Contains(_archivosDirectory)).Count() > 0)
                        {
                            ws.deleteDocument(dest);
                        }
                        ws.createDocumentSimple(dest, fileStream);
                        fileStream.Dispose();
                        System.IO.File.Delete(src);
                    }
                    //Registro de archivos
                }

            }

            //Registro de Informantes
            var filasInfo = from inf in _db.Informante
                            where inf.IdCuestionario == objCuestionario.Id
                            select inf;

            _db.Informante.RemoveRange(filasInfo);
            _db.SaveChanges();

            //Registramos el listado de entrevistas
            foreach (var info in model.ListInformantes)
            {
                //Registramos o actualizamos los datos de la persona
                long personaId;
                var persona = _db.Persona.Where(x => x.NumeroDocumento == info.NumeroDocumento && x.IdTipoDocumento == info.IdTipoDocumento && info.NumeroDocumento.Trim() != "").FirstOrDefault();
                if (persona == null)
                {//Si la persona no existe                 
                    var objPersona = new PersonaEntity()
                    {
                        CodigoUUID = Guid.NewGuid().ToString(),
                        IdTipoDocumento = info.IdTipoDocumento,
                        NumeroDocumento = info.NumeroDocumento,
                        Nombre = info.Nombre,
                        ApellidoPaterno = info.ApellidoPaterno,
                        ApellidoMaterno = info.ApellidoMaterno,
                        Celular = info.Celular,
                        CorreoElectronico = info.Correo,
                        Telefono = info.Telefono,
                        Cargo = info.Cargo,
                        Estado = 1,
                        FechaRegistro = DateTime.Now,
                        UsuarioCreacion = usuario.Usuario
                    };
                    _db.Persona.Add(objPersona);
                    _db.SaveChanges();
                    personaId = objPersona.Id;
                }
                else
                {

                    persona.IdTipoDocumento = info.IdTipoDocumento;
                    persona.NumeroDocumento = info.NumeroDocumento;
                    persona.Nombre = info.Nombre;
                    persona.ApellidoPaterno = info.ApellidoPaterno;
                    persona.ApellidoMaterno = info.ApellidoMaterno;
                    persona.Celular = info.Celular;
                    persona.CorreoElectronico = info.Correo;
                    persona.Cargo = info.Cargo;
                    persona.FechaActualizacion = DateTime.Now;
                    persona.UsuarioActualizacion = usuario.Usuario;
                    _db.Persona.Update(persona);
                    _db.SaveChanges();
                    personaId = persona.Id;
                }

                var objInformante = new InformanteEntity()
                {
                    IdCuestionario = objCuestionario.Id,
                    IdPersona = personaId,
                    IdEstado = info.IdEstado,
                    Observacion = info.Observacion,
                    Direccion = info.Direccion,
                    CoordenadaEste = info.CoordenadaEste,
                    CoordenadaNorte = info.CoordenadaNorte,
                    SistemaCoordenada = info.SistemaCoordenada,
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = usuario.Usuario
                };
                _db.Informante.Add(objInformante);
                _db.SaveChanges();
            }

            return objCuestionario.CodigoUUID.ToString();

        }
        public async Task<string> DesaprobarCuestionario(GestionRegistroModel model)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objCuestionario = _db.GestionRegistro.Where(x => x.CodigoUUID.ToString() == model.CodigoUUID).FirstOrDefault();
            var idEstadoReg = (from ent in _db.Estado.Where(x => x.CodigoEstado == "OBSERVADOSUPERVISOR")
                            select ent).FirstOrDefault().Id;
            var idEstadoSup = (from ent in _db.Estado.Where(x => x.CodigoEstado == "DESAPROBADO")
                               select ent).FirstOrDefault().Id;
            objCuestionario.EstadoRegistro = (int)idEstadoReg;
            objCuestionario.EstadoSupervision = (int)idEstadoSup;
            objCuestionario.FechaActualizacion = DateTime.Now;
            objCuestionario.UsuarioActualizacion = usuario.Usuario;
            _db.GestionRegistro.Update(objCuestionario);
            _db.SaveChanges();

            return objCuestionario.CodigoUUID.ToString();
        }
        public async Task<string> InvalidarCuestionario(GestionRegistroModel model)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objCuestionario = _db.GestionRegistro.Where(x => x.CodigoUUID.ToString() == model.CodigoUUID).FirstOrDefault();
            var idEstadoReg = (from ent in _db.Estado.Where(x => x.CodigoEstado == "OBSERVADOESPECIALISTA")
                               select ent).FirstOrDefault().Id;
            var idEstadoEsp = (from ent in _db.Estado.Where(x => x.CodigoEstado == "INVALIDO")
                               select ent).FirstOrDefault().Id;
            objCuestionario.EstadoRegistro = (int)idEstadoReg;
            objCuestionario.EstadoValidacion = (int)idEstadoEsp;
            objCuestionario.FechaActualizacion = DateTime.Now;
            objCuestionario.UsuarioActualizacion = usuario.Usuario;
            _db.GestionRegistro.Update(objCuestionario);
            _db.SaveChanges();

            return objCuestionario.CodigoUUID.ToString();
        }
        public async Task<string> AprobarCuestionarioxUUID(string uuid)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objCuestionario = _db.GestionRegistro.Where(x => x.CodigoUUID.ToString() == uuid).FirstOrDefault();
            var idEstadoReg = (from ent in _db.Estado.Where(x => x.CodigoEstado == "PARAVALIDAR")
                               select ent).FirstOrDefault().Id;
            var idEstadoSup = (from ent in _db.Estado.Where(x => x.CodigoEstado == "APROBADO")
                               select ent).FirstOrDefault().Id;
            objCuestionario.EstadoRegistro = (int)idEstadoReg;
            objCuestionario.EstadoSupervision = (int)idEstadoSup;
            objCuestionario.FechaActualizacion = DateTime.Now;
            objCuestionario.UsuarioActualizacion = usuario.Usuario;
            _db.GestionRegistro.Update(objCuestionario);
            _db.SaveChanges();

            return objCuestionario.CodigoUUID.ToString();
        }
        public async Task<string> RatificarCuestionarioxUUID(string uuid)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objCuestionario = _db.GestionRegistro.Where(x => x.CodigoUUID.ToString() == uuid).FirstOrDefault();
            var idEstadoReg = (from ent in _db.Estado.Where(x => x.CodigoEstado == "PARAREGISTRAR2")
                               select ent).FirstOrDefault().Id;
            var idEstadoSup = (from ent in _db.Estado.Where(x => x.CodigoEstado == "RATIFICADO")
                               select ent).FirstOrDefault().Id;
            objCuestionario.EstadoRegistro = (int)idEstadoReg;
            objCuestionario.EstadoSupervision = (int)idEstadoSup;
            objCuestionario.FechaActualizacion = DateTime.Now;
            objCuestionario.UsuarioActualizacion = usuario.Usuario;
            _db.GestionRegistro.Update(objCuestionario);
            _db.SaveChanges();

            return objCuestionario.CodigoUUID.ToString();
        }
        public async Task<string> DerivarCuestionarioxUUID(string uuid)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objCuestionario = _db.GestionRegistro.Where(x => x.CodigoUUID.ToString() == uuid).FirstOrDefault();
            var idEstadoReg = (from ent in _db.Estado.Where(x => x.CodigoEstado == "ARBITRAJE")
                               select ent).FirstOrDefault().Id;
            var idEstadoSup = (from ent in _db.Estado.Where(x => x.CodigoEstado == "DERIVADO")
                               select ent).FirstOrDefault().Id;
            objCuestionario.EstadoRegistro = (int)idEstadoReg;
            objCuestionario.EstadoSupervision = (int)idEstadoSup;
            objCuestionario.FechaActualizacion = DateTime.Now;
            objCuestionario.UsuarioActualizacion = usuario.Usuario;
            _db.GestionRegistro.Update(objCuestionario);
            _db.SaveChanges();

            return objCuestionario.CodigoUUID.ToString();
        }
        public async Task<string> ValidarCuestionarioxUUID(string uuid)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objCuestionario = _db.GestionRegistro.Where(x => x.CodigoUUID.ToString() == uuid).FirstOrDefault();
            var idEstadoReg = (from ent in _db.Estado.Where(x => x.CodigoEstado == "CERRADO")
                               select ent).FirstOrDefault().Id;
            var idEstadoEsp = (from ent in _db.Estado.Where(x => x.CodigoEstado == "VALIDO")
                               select ent).FirstOrDefault().Id;
            objCuestionario.EstadoRegistro = (int)idEstadoReg;
            objCuestionario.EstadoValidacion = (int)idEstadoEsp;
            objCuestionario.FechaActualizacion = DateTime.Now;
            objCuestionario.UsuarioActualizacion = usuario.Usuario;
            _db.GestionRegistro.Update(objCuestionario);
            _db.SaveChanges();

            return objCuestionario.CodigoUUID.ToString();
        }
        public async Task<string> DescartarCuestionarioxUUID(string uuid)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objCuestionario = _db.GestionRegistro.Where(x => x.CodigoUUID.ToString() == uuid).FirstOrDefault();
            var idEstadoReg = (from ent in _db.Estado.Where(x => x.CodigoEstado == "ELIMINADO")
                               select ent).FirstOrDefault().Id;
            var idEstadoEsp = (from ent in _db.Estado.Where(x => x.CodigoEstado == "DESCARTAR")
                               select ent).FirstOrDefault().Id;
            objCuestionario.EstadoRegistro = (int)idEstadoReg;
            objCuestionario.EstadoValidacion = (int)idEstadoEsp;
            objCuestionario.FechaActualizacion = DateTime.Now;
            objCuestionario.UsuarioActualizacion = usuario.Usuario;
            _db.GestionRegistro.Update(objCuestionario);
            _db.SaveChanges();

            return objCuestionario.CodigoUUID.ToString();
        }
    }
}
