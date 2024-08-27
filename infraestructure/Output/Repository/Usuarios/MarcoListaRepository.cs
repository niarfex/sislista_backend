using Application.Output;
using AutoMapper;
using Dapper;
using Domain.Exceptions;
using Domain.Model;
using Infra.MarcoLista.Contextos;
using Infra.MarcoLista.GeneralSQL;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Infra.MarcoLista.Output.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using NPOI.XSSF;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace Infra.MarcoLista.Output.Repository
{
    public class MarcoListaRepository: IMarcoListaRepository
    {
        private MarcoListaContexto _db;
        private readonly IConfiguration _configuracion;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public MarcoListaRepository(IConfiguration configuracion,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _configuracion = configuracion;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _db = new MarcoListaContexto(_configuracion[$"DatabaseSettings:ConnectionSISLISTA"]);
        }
        public async Task<List<MarcoListaModel>> GetAll(string param)
        {
            var query = from m in _db.MarcoLista
                        join p in _db.Persona on m.IdPersona equals p.Id
                        join c in _db.CondicionJuridica on p.IdCondicionJuridica equals c.Id
                        where (m.Estado == 0 || m.Estado == 1) && (p.Estado == 0 || p.Estado == 1)
                        && (p.NumeroDocumento.Contains(param.Trim().ToUpper()) || 
                        p.RazonSocial.ToUpper().Contains(param.Trim().ToUpper()) ||
                        p.Nombre.ToUpper().Contains(param.Trim().ToUpper()) ||
                        p.ApellidoPaterno.ToUpper().Contains(param.Trim().ToUpper()) ||
                        p.ApellidoMaterno.ToUpper().Contains(param.Trim().ToUpper())                        
                        ) orderby m.FechaActualizacion.HasValue?m.FechaActualizacion:m.FechaRegistro descending
                        select new MarcoListaModel
                        { 
                            Id=m.Id,
                            NumeroDocumento=p.NumeroDocumento,
                            NombreCompleto= p.RazonSocial.IsNullOrEmpty()?(p.Nombre+" "+p.ApellidoPaterno+" "+p.ApellidoMaterno):p.RazonSocial,
                            CondicionJuridica=c.CondicionJuridica,
                            NombreRepLegal=p.NombreRepLegal,  
                            IdDepartamento=m.IdDepartamento,  
                            IdUbigeo=p.IdUbigeo,
                            IdAnio=m.IdAnio,
                            Estado=m.Estado
                        };
            return query.ToList();
        }
        public async Task<List<MarcoListaModel>> GetMarcoListasinAginarxPerfil(long idPerfil)
        {
            List<MarcoListaModel> resultado = new List<MarcoListaModel>();
            var listML = (from m in _db.MarcoLista
                        join p in _db.Persona on m.IdPersona equals p.Id
                        join c in _db.CondicionJuridica on p.IdCondicionJuridica equals c.Id
                        where  m.Estado == 1 && p.Estado == 1                        
                        select new MarcoListaModel
                        {
                            Id = m.Id,
                            NumeroDocumento = p.NumeroDocumento,
                            NombreCompleto = p.RazonSocial.IsNullOrEmpty() ? (p.Nombre + " " + p.ApellidoPaterno + " " + p.ApellidoMaterno) : p.RazonSocial,
                            CondicionJuridica = c.CondicionJuridica,
                            NombreRepLegal = p.NombreRepLegal,
                            IdDepartamento = m.IdDepartamento,
                            IdUbigeo = p.IdUbigeo,
                            IdAnio = m.IdAnio,
                            Estado = m.Estado
                        }).ToList();

            var listMLAsig = (from m in _db.MarcoLista
                          join pe in _db.Persona on m.IdPersona equals pe.Id
                          join c in _db.CondicionJuridica on pe.IdCondicionJuridica equals c.Id
                          join um in _db.UsuarioMarcoLista on m.Id equals um.IdMarcoLista
                          join u in _db.Usuario on um.IdUsuario equals u.Id
                          join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                          join p in _db.Perfil on up.IdPerfil equals p.Id
                          where m.Estado == 1 && pe.Estado == 1 && u.Estado == 1 
                          && p.Estado == 1 && um.Estado==1 && up.Estado==1
                          && p.Id==idPerfil
                          select new MarcoListaModel
                          {
                              Id = m.Id,
                              NumeroDocumento = pe.NumeroDocumento,
                              NombreCompleto = pe.RazonSocial.IsNullOrEmpty() ? (pe.Nombre + " " + pe.ApellidoPaterno + " " + pe.ApellidoMaterno) : pe.RazonSocial,
                              CondicionJuridica = c.CondicionJuridica,
                              NombreRepLegal = pe.NombreRepLegal,
                              IdDepartamento = m.IdDepartamento,
                              IdUbigeo = pe.IdUbigeo,
                              IdAnio = m.IdAnio,
                              Estado = m.Estado
                          }).ToList();

            foreach (var ml in listML) {
                if (listMLAsig.FindAll(x=> x.Id==ml.Id).Count()==0) {
                    resultado.Add(ml);
                }
            }

            return resultado;
        }
        public async Task<MarcoListaModel> GetMarcoListaxId(long id)
        {      

            var query = from m in _db.MarcoLista
                        join p in _db.Persona on m.IdPersona equals p.Id 
                        where (m.Estado == 0 || m.Estado == 1) && (p.Estado == 0 || p.Estado == 1) && m.Id == id
                        select new MarcoListaModel
                        {
                            Id = m.Id,
                            IdPersona = m.IdPersona,
                            IdTipoExplotacion = m.IdTipoExplotacion,
                            Direccion = m.Direccion,
                            IdDepartamento = m.IdDepartamento,
                            Estado = m.Estado,
                            IdTipoDocumento = p.IdTipoDocumento,
                            IdCondicionJuridica = p.IdCondicionJuridica,
                            IdCondicionJuridicaOtros = p.IdCondicionJuridicaOtros,
                            IdUbigeo = p.IdUbigeo,
                            IdAnio = m.IdAnio,
                            CodigoUUIDPersona = p.CodigoUUID.ToString(),
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
                            TieneRuc = p.TieneRuc
                        };

            return query.FirstOrDefault();




        }
        public async Task<long> CreateMarcoLista(MarcoListaModel model)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            //Registramos o actualizamos los datos de la persona
            long personaId;
            if (model.CodigoUUIDPersona == null) { model.CodigoUUIDPersona = ""; }
            var persona = _db.Persona.Where(x => (x.CodigoUUID.ToString() == model.CodigoUUIDPersona && model.CodigoUUIDPersona.Trim() != "") 
            || (x.NumeroDocumento==model.NumeroDocumento && x.IdTipoDocumento==model.IdTipoDocumento && model.NumeroDocumento.Trim() != "")).FirstOrDefault();
            if (persona == null) {//Si la persona no existe                 
                var objPersona = new PersonaEntity()
                {
                    CodigoUUID = Guid.NewGuid().ToString(),
                    IdTipoDocumento = model.IdTipoDocumento,
                    NumeroDocumento = model.NumeroDocumento,
                    IdCondicionJuridica = model.IdCondicionJuridica,
                    IdCondicionJuridicaOtros = model.IdCondicionJuridicaOtros,
                    Nombre = model.Nombre,
                    ApellidoPaterno = model.ApellidoPaterno,
                    ApellidoMaterno = model.ApellidoMaterno,
                    TieneRuc = model.TieneRuc,
                    DireccionFiscalDomicilio = model.DireccionFiscalDomicilio,
                    IdUbigeo = model.IdUbigeo,
                    Telefono = model.Telefono,
                    Celular = model.Celular,
                    CorreoElectronico = model.CorreoElectronico,
                    PaginaWeb = model.PaginaWeb,
                    RazonSocial = model.RazonSocial,
                    NombreRepLegal = model.NombreRepLegal,
                    CelularRepLegal = model.CelularRepLegal,
                    CorreoRepLegal = model.CorreoRepLegal,
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = usuario.Usuario,
                };
                _db.Persona.Add(objPersona);
                _db.SaveChanges();
                personaId = objPersona.Id;
            }
            else {                
                persona.IdTipoDocumento = model.IdTipoDocumento;
                persona.NumeroDocumento = model.NumeroDocumento;
                persona.IdCondicionJuridica = model.IdCondicionJuridica;
                persona.IdCondicionJuridicaOtros = model.IdCondicionJuridicaOtros;
                persona.Nombre = model.Nombre;
                persona.ApellidoPaterno = model.ApellidoPaterno;
                persona.ApellidoMaterno = model.ApellidoMaterno;
                persona.TieneRuc = model.TieneRuc;
                persona.DireccionFiscalDomicilio = model.DireccionFiscalDomicilio;
                persona.IdUbigeo = model.IdUbigeo;
                persona.Telefono = model.Telefono;
                persona.Celular = model.Celular;   
                persona.CorreoElectronico = model.CorreoElectronico;
                persona.PaginaWeb = model.PaginaWeb;
                persona.RazonSocial = model.RazonSocial;
                persona.NombreRepLegal = model.NombreRepLegal;
                persona.CelularRepLegal = model.CelularRepLegal;
                persona.CorreoRepLegal = model.CorreoRepLegal;
                persona.FechaActualizacion = DateTime.Now;
                persona.UsuarioActualizacion = usuario.Usuario; ;
                _db.Persona.Update(persona);
                _db.SaveChanges();
                personaId = persona.Id;
            }
            //Registrammos el Marco Lista
            if (model.Id > 0)
            {
                var objMarcoLista = _db.MarcoLista.Where(x => x.Id == model.Id).FirstOrDefault();
                objMarcoLista.IdTipoExplotacion = model.IdTipoExplotacion;       
                objMarcoLista.IdDepartamento = model.IdDepartamento;
                objMarcoLista.IdAnio = model.IdAnio;
                objMarcoLista.IdPersona = personaId;
                objMarcoLista.Direccion = model.Direccion;
                objMarcoLista.FechaActualizacion = DateTime.Now;
                objMarcoLista.UsuarioActualizacion = usuario.Usuario; ;
                _db.MarcoLista.Update(objMarcoLista);
                _db.SaveChanges();
                return objMarcoLista.Id;
            }
            else
            {
                var objMarcoLista = new MarcoListaEntity()
                {
                    IdTipoExplotacion = model.IdTipoExplotacion,
                    IdDepartamento = model.IdDepartamento,
                    IdAnio = model.IdAnio,
                    IdPersona = personaId,
                    Direccion = model.Direccion,               
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = usuario.Usuario,
                };
                _db.MarcoLista.Add(objMarcoLista);
                _db.SaveChanges();
                return objMarcoLista.Id;
            }
        }
        
        public async Task<long> DeleteMarcoListaxId(long id)
        {
            var objMLUsuarios = _db.UsuarioMarcoLista.Where(x => x.IdMarcoLista == id).ToList();
            if (objMLUsuarios.Count()>0)
            {
                throw new RelatedDataFoundException("No se puede eliminar el Marco de Lista porque existen registros de usuarios asociados al marco de lista");
            }
            var objMLCuestionarios = _db.GestionRegistro.Where(x => x.IdMarcoLista == id).ToList();
            if (objMLCuestionarios.Count() > 0)
            {
                throw new RelatedDataFoundException("No se puede eliminar el Marco de Lista porque existen registros de cuestionarios asociados al marco de lista");
            }

            var objMarcoLista = _db.MarcoLista.Where(x => x.Id == id).FirstOrDefault();
            _db.MarcoLista.Remove(objMarcoLista);
            _db.MarcoLista.Update(objMarcoLista);
            _db.SaveChanges();
            return objMarcoLista.Id;
        }

        public async Task<long> ActivarMarcoListaxId(long id)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objMarcoLista = _db.MarcoLista.Where(x => x.Id == id).FirstOrDefault();
            objMarcoLista.Estado = 1;
            objMarcoLista.FechaActualizacion = DateTime.Now;
            objMarcoLista.UsuarioActualizacion = usuario.Usuario; 
            _db.MarcoLista.Update(objMarcoLista);
            _db.SaveChanges();
            return objMarcoLista.Id;
        }

        public async Task<long> DesactivarMarcoListaxId(long id)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objMarcoLista = _db.MarcoLista.Where(x => x.Id == id).FirstOrDefault();
            objMarcoLista.Estado = 0;
            objMarcoLista.FechaActualizacion = DateTime.Now;
            objMarcoLista.UsuarioActualizacion = usuario.Usuario; 
            _db.MarcoLista.Update(objMarcoLista);
            _db.SaveChanges();
            return objMarcoLista.Id;
        }
    }
}
