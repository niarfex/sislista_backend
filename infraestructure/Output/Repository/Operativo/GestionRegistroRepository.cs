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

namespace Infra.MarcoLista.Output.Repository
{
    public class GestionRegistroRepository: IGestionRegistroRepository
    {
        private MarcoListaContexto _db;
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private DBOracle dBOracle = new DBOracle();
        public GestionRegistroRepository(IConfiguration configuracion, 
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _configuracion = configuracion;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _db = new MarcoListaContexto(_configuracion[$"DatabaseSettings:ConnectionString1"]);
        }
        public async Task<List<GestionRegistroModel>> GetAll(string param,string uuid)
        {
            List<GestionRegistroModel> listaCuestionarios = new List<GestionRegistroModel>();
            /*var queryUsu = from u in _db.Usuario
                           join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                           join p in _db.Perfil on up.IdPerfil equals p.Id
                           where u.CodigoUUID.ToString() == uuid
                           select p;
            var codPerfil = queryUsu.FirstOrDefault().CodigoPerfil;*/

            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];


            if (usuario.CodigoPerfil == "PERFILADM") {
                var query = from u in _db.Usuario
                            join um in _db.UsuarioMarcoLista on u.Id equals um.IdUsuario
                            join m in _db.MarcoLista on um.IdMarcoLista equals m.Id
                            join pe in _db.Persona on m.IdPersona equals pe.Id
                            join a in _db.Anio on m.IdAnio equals a.Id
                            join te in _db.TipoExplotacion on m.IdTipoExplotacion equals te.Id
                            from cu in _db.GestionRegistro.Where(x => x.IdMarcoLista == m.Id).DefaultIfEmpty()
                            from info in _db.Informante.Where(x => x.IdCuestionario == m.Id).DefaultIfEmpty()
                            from eEnt in _db.Estado.Where(x => x.Id == info.IdEstado).DefaultIfEmpty()
                            from eSup in _db.Estado.Where(x => x.Id==cu.EstadoSupervision).DefaultIfEmpty()
                            from eVal in _db.Estado.Where(x => x.Id == cu.EstadoValidacion).DefaultIfEmpty()
                            from eReg in _db.Estado.Where(x => x.Id == cu.EstadoRegistro).DefaultIfEmpty()
                            where pe.NumeroDocumento.Contains(param.Trim().ToUpper()) ||
                            pe.RazonSocial.ToUpper().Contains(param.Trim().ToUpper()) ||
                            pe.Nombre.ToUpper().Contains(param.Trim().ToUpper()) ||
                            pe.ApellidoPaterno.ToUpper().Contains(param.Trim().ToUpper()) ||
                            pe.ApellidoMaterno.ToUpper().Contains(param.Trim().ToUpper())                             
                            select new GestionRegistroModel
                            {
                                CodigoUUID = cu.CodigoUUID,
                                IdPeriodo = a.Id,
                                Periodo = a.Anio,
                                NombreCompleto = pe.RazonSocial.IsNullOrEmpty() ? (pe.Nombre + " " + pe.ApellidoPaterno + " " + pe.ApellidoMaterno) : pe.RazonSocial,
                                NumeroDocumento = pe.NumeroDocumento,
                                TipoExplotacion = te.TipoExplotacion,
                                UsuarioCreacion = cu != null ? cu.UsuarioCreacion : "",
                                FechaRegistro = cu != null ? cu.FechaRegistro : null,
                                UsuarioActualizacion = cu != null ? cu.UsuarioActualizacion : "",
                                FechaActualizacion = cu != null ? cu.FechaActualizacion : null,
                                CodigoEstadoEntrevista = eEnt != null ? eEnt.CodigoEstado : null,
                                CodigoEstadoSupervision =  eSup !=null?eSup.CodigoEstado:null,
                                CodigoEstadoValidacion = eVal != null ? eVal.CodigoEstado : null,
                                CodigoEstadoRegistro = eReg != null ? eReg.CodigoEstado : null,
                                NombreEstadoEntrevista = eEnt != null ? eEnt.TipoEstado : null,
                                NombreEstadoSupervision = eSup != null ? eSup.TipoEstado : null,
                                NombreEstadoValidacion = eVal != null ? eVal.TipoEstado : null,
                                NombreEstadoRegistro = eReg != null ? eReg.TipoEstado : "Por registrar",
                                Clasificacion = ""                                
                            };
                listaCuestionarios = query.ToList();
            }
            else if (usuario.CodigoPerfil == "PERFILEMP" ||
                usuario.CodigoPerfil == "PERFILSUP" ||
                usuario.CodigoPerfil == "PERFILESP") {
                var query = from u in _db.Usuario
                            join um in _db.UsuarioMarcoLista on u.Id equals um.IdUsuario
                            join m in _db.MarcoLista on um.IdMarcoLista equals m.Id
                            join pe in _db.Persona on m.IdPersona equals pe.Id
                            join a in _db.Anio on m.IdAnio equals a.Id
                            join te in _db.TipoExplotacion on m.IdTipoExplotacion equals te.Id
                            from cu in _db.GestionRegistro.Where(x => x.IdMarcoLista == m.Id).DefaultIfEmpty()
                            from info in _db.Informante.Where(x => x.IdCuestionario == m.Id).DefaultIfEmpty()
                            from eEnt in _db.Estado.Where(x => x.Id == info.IdEstado).DefaultIfEmpty()
                            from eSup in _db.Estado.Where(x => x.Id == cu.EstadoSupervision).DefaultIfEmpty()
                            from eVal in _db.Estado.Where(x => x.Id == cu.EstadoValidacion).DefaultIfEmpty()
                            from eReg in _db.Estado.Where(x => x.Id == cu.EstadoRegistro).DefaultIfEmpty()
                            where u.CodigoUUID.ToString() == uuid || 
                            pe.NumeroDocumento.Contains(param.Trim().ToUpper()) ||
                            pe.RazonSocial.ToUpper().Contains(param.Trim().ToUpper()) ||
                            pe.Nombre.ToUpper().Contains(param.Trim().ToUpper()) ||
                            pe.ApellidoPaterno.ToUpper().Contains(param.Trim().ToUpper()) ||
                            pe.ApellidoMaterno.ToUpper().Contains(param.Trim().ToUpper()) ||
                            te.TipoExplotacion.ToUpper().Contains(param.Trim().ToUpper())                            
                            select new GestionRegistroModel
                            {
                                CodigoUUID = cu.CodigoUUID,
                                IdPeriodo = a.Id,
                                Periodo = a.Anio,
                                NombreCompleto = pe.RazonSocial.IsNullOrEmpty() ? (pe.Nombre + " " + pe.ApellidoPaterno + " " + pe.ApellidoMaterno) : pe.RazonSocial,
                                NumeroDocumento = pe.NumeroDocumento,
                                TipoExplotacion = te.TipoExplotacion,
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
                                NombreEstadoRegistro = eReg != null ? eReg.TipoEstado : " POR REGISTRAR",
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
            var query = from c in _db.GestionRegistro
                        join m in _db.MarcoLista on c.IdMarcoLista equals m.Id
                        join p in _db.Persona on m.IdPersona equals p.Id
                        where c.NumeroDocumento == numDoc && m.IdAnio == idPeriodo
                        select new GestionRegistroModel
                        {
                            Id = c.Id,
                            IdPeriodo = m.IdAnio,
                            CodigoUUID = c.CodigoUUID,
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
                            FechaActualizacion=c.FechaActualizacion
                            
                        };

            if (query.FirstOrDefault() == null)
            {
                var queryML = from m in _db.MarcoLista 
                            join p in _db.Persona on m.IdPersona equals p.Id
                            where p.NumeroDocumento == numDoc && m.IdAnio == idPeriodo
                            select new GestionRegistroModel
                            {
                                Id = 0,
                                CodigoUUID = "",
                                IdPeriodo=m.IdAnio,
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
                                FechaActualizacion=null
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
                           where c.CodigoUUID.ToString() == uuid
                           select new ArchivoModel { 
                           Id=ar.Id,
                           NombreArchivo=ar.NombreArchivo,
                           DescripcionArchivo=ar.DescripcionArchivo,
                           TipoInformacion=tp.TipoInformacion,
                           Peso=ar.Peso
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
                objCuestionario.PaginaWeb=model.PaginaWeb;
                objCuestionario.NombreRepLegal = model.NombreRepLegal;
                objCuestionario.CorreoRepLegal = model.CorreoRepLegal;
                objCuestionario.CelularRepLegal = model.CelularRepLegal;
                objCuestionario.CantidadFundo = model.CantidadFundo;
                objCuestionario.TieneRuc=model.TieneRuc;

                
                objCuestionario.EstadoRegistro = (int)idEstado;               
                objCuestionario.FechaActualizacion = DateTime.Now;
                objCuestionario.UsuarioActualizacion = usuario.Usuario;
                _db.GestionRegistro.Update(objCuestionario);
                _db.SaveChanges();
                
                return objCuestionario.CodigoUUID.ToString();
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
                    EstadoSupervision=null,
                    EstadoValidacion=null,
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = usuario.Usuario
                };
                _db.GestionRegistro.Add(objCuestionario);
                _db.SaveChanges();

                //Registro de Fundos

                foreach (var fundo in model.ListFundos)
                {

                    var objFundo = new FundoEntity()
                    {
                        IdCuestionario=objCuestionario.Id,
                        Fundo=fundo.Fundo,
                        IdUbigeo=fundo.IdUbigeo,
                        Observacion=fundo.Observacion,
                        SuperficieTotal=fundo.SuperficieTotal,
                        SuperficieAgricola=fundo.SuperficieAgricola,
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
                            IdFundo=objFundo.Id,
                            Campo=campo.Campo,
                            IdTenencia=campo.IdTenencia==0?null: campo.IdTenencia,
                            IdUsoTierra=campo.IdUsoTierra == 0 ? null : campo.IdUsoTierra,
                            IdCultivo=campo.IdCultivo == 0 ? null : campo.IdCultivo,
                            IdUsoNoAgricola=campo.IdUsoNoAgricola == 0 ? null : campo.IdUsoNoAgricola,
                            Observacion=campo.Observacion,
                            Superficie=campo.Superficie,
                            SuperficieCultivada=campo.SuperficieCultivada,
                            Estado = 1,
                            FechaRegistro = DateTime.Now,
                            UsuarioCreacion = usuario.Usuario
                        };
                        _db.Campo.Add(objCampo);
                        _db.SaveChanges();
                    }
                }

                //Registro de Pecuarios

                var filasPecuario = from inf in _db.Pecuario
                            join cam in _db.Campo on inf.IdCampo equals cam.Id
                            join fun in _db.Fundo on cam.IdFundo equals fun.Id
                            where fun.IdCuestionario == objCuestionario.Id
                            select inf;
                _db.Pecuario.RemoveRange(filasPecuario);
                _db.SaveChanges();

                foreach (var pecu in model.ListPecuarios)
                {                    

                    var objPecuario = new PecuarioEntity()
                    {
                        IdFundo=null,
                        IdCampo=null,
                        IdSistemaPecuario=pecu.SistemaPecuario== "LÍNEA DE PRODUCCIÓN"?1:(pecu.SistemaPecuario == "ESPECIE" ? 2 :null),
                        IdLineaProduccion=pecu.IdLineaProduccion,
                        IdEspecie=pecu.IdEspecie,
                        Cantidad=pecu.Cantidad,
                        Estado = 1,
                        FechaRegistro = DateTime.Now,
                        UsuarioCreacion = usuario.Usuario
                    };
                    _db.Pecuario.Add(objPecuario);
                    _db.SaveChanges();
                }

                //Registro de Archivos

                foreach (var arch in model.ListArchivos)
                {

                    var objArchivo = new ArchivoEntity()
                    {
                        IdCuestionario=objCuestionario.Id,
                        NombreArchivo=arch.NombreArchivo,
                        Archivo=arch.Archivo,
                        DescripcionArchivo=arch.DescripcionArchivo,
                        CuestionarioPrincipal=arch.CuestionarioPrincipal,
                        IdTipoInformacion=arch.IdTipoInformacion,
                        Peso=arch.Peso,
                        Estado = 1,
                        FechaRegistro = DateTime.Now,
                        UsuarioCreacion = usuario.Usuario
                    };
                    _db.Archivo.Add(objArchivo);
                    _db.SaveChanges();
                }

                //Registro de Informantes

                var filasInfo = from inf in _db.Informante
                            where inf.IdCuestionario==objCuestionario.Id
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
                        IdCuestionario=objCuestionario.Id,
                        IdPersona=personaId,
                        IdEstado=info.IdEstado,
                        Observacion=info.Observacion,
                        Direccion=info.Direccion,
                        CoordenadaEste=info.CoordenadaEste,
                        CoordenadaNorte=info.CoordenadaNorte,
                        SistemaCoordenada=info.SistemaCoordenada,
                        Estado = 1,
                        FechaRegistro = DateTime.Now,
                        UsuarioCreacion = usuario.Usuario
                    };
                    _db.Informante.Add(objInformante);
                    _db.SaveChanges();
                }

                return objCuestionario.CodigoUUID.ToString();
            }
        }

    }
}
