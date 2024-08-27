using AutoMapper;
using Dapper;
using Domain.Model;
using Infra.MarcoLista.Contextos;
using Infra.MarcoLista.GeneralSQL;
using Infra.MarcoLista.Output.Entity;
using Infra.MarcoLista.Output.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Xml.Linq;
using static Dapper.SqlMapper;
using Domain.Exceptions;

namespace Infra.MarcoLista.Output.Repository
{
    public class OrganizacionRepository : IOrganizacionRepository
    {
        private MarcoListaContexto _db;
        private readonly IConfiguration _configuracion;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public OrganizacionRepository(IConfiguration configuracion,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _configuracion = configuracion;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _db = new MarcoListaContexto(_configuracion[$"DatabaseSettings:ConnectionSISLISTA"]);
        }
        public async Task<List<OrganizacionEntity>> GetAll(string param)
        {
            //var query = from o in _db.Organizacion select o;
            //return query.ToList();
            return _db.Organizacion.Where(x => x.Organizacion.ToUpper().Trim().Contains(param.ToUpper().Trim()) || 
            x.NumeroDocumento.Trim().Contains(param.Trim())).OrderByDescending(x=>x.FechaActualizacion.HasValue?x.FechaActualizacion:x.FechaRegistro).ToList();
        }
        public async Task<OrganizacionEntity> GetOrganizacionxId(long id)
        {
            return _db.Organizacion.Where(x => x.Id==id).FirstOrDefault();
        }
        public async Task<long> CreateOrganizacion(OrganizacionModel model)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];

            var objRegistroRUC = _db.Organizacion.Where(x => x.NumeroDocumento == model.NumeroDocumento &&  x.Id != model.Id).FirstOrDefault();
            if (objRegistroRUC != null)
            {
                throw new DocExistException("EL Número de RUC ya se encuentra registrado");
            }
            var objRegistroEmail = _db.Organizacion.Where(x => x.CorreoElectronico.ToUpper() == model.CorreoElectronico.ToUpper() && model.CorreoElectronico.ToUpper() != "" && x.Id != model.Id).FirstOrDefault();
            if (objRegistroEmail != null)
            {
                throw new EmailExistException("EL correo electrónico ya se encuentra registrado en otra organización");
            }

            if (model.Id > 0)
            {   
                var objOrganizacion = _db.Organizacion.Where(x => x.Id == model.Id).FirstOrDefault();
                objOrganizacion.IdTipoOrganizacion = model.IdTipoOrganizacion;
                objOrganizacion.NumeroDocumento = model.NumeroDocumento;
                objOrganizacion.Organizacion = model.Organizacion;
                objOrganizacion.DireccionFiscal = model.DireccionFiscal;
                objOrganizacion.IdDepartamento = model.IdDepartamento;
                objOrganizacion.Telefono = model.Telefono;
                objOrganizacion.PaginaWeb = model.PaginaWeb;
                objOrganizacion.CorreoElectronico = model.CorreoElectronico;
                objOrganizacion.FechaActualizacion = DateTime.Now;
                objOrganizacion.UsuarioActualizacion = usuario.Usuario;
                _db.Organizacion.Update(objOrganizacion);
                _db.SaveChanges();
                return objOrganizacion.Id;
            }
            else
            {       
                var objOrganizacion = new OrganizacionEntity()
                {
                    IdTipoOrganizacion = model.IdTipoOrganizacion,
                    NumeroDocumento = model.NumeroDocumento,
                    Organizacion = model.Organizacion,
                    DireccionFiscal = model.DireccionFiscal,
                    IdDepartamento = model.IdDepartamento,
                    Telefono = model.Telefono,
                    PaginaWeb = model.PaginaWeb,
                    CorreoElectronico = model.CorreoElectronico,
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = usuario.Usuario,
                };
                _db.Organizacion.Add(objOrganizacion);
                _db.SaveChanges();
                return objOrganizacion.Id;
            }
            
            
        }       
        public async Task<long> DeleteOrganizacionxId(long id)
        {
            var objOrgPers = _db.Persona.Where(x => x.IdOrganizacion == id).FirstOrDefault();

            if (objOrgPers != null) {
                throw new RelatedDataFoundException("No se puede eliminar la organización existen registros de usuarios asociados a esta organizacion");
            }

            var objOrganizacion = _db.Organizacion.Where(x => x.Id == id).FirstOrDefault();
            _db.Organizacion.Remove(objOrganizacion);   
            _db.SaveChanges();
            return objOrganizacion.Id;
        }

        public async Task<long> ActivarOrganizacionxId(long id)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objOrganizacion = _db.Organizacion.Where(x => x.Id == id).FirstOrDefault();
            objOrganizacion.Estado = 1;
            objOrganizacion.FechaActualizacion = DateTime.Now;
            objOrganizacion.UsuarioActualizacion = usuario.Usuario; 
            _db.Organizacion.Update(objOrganizacion);
            _db.SaveChanges();

            var objUsuarios = _db.Usuario.Where(x => x.DetallePersona.IdOrganizacion == id).ToList();
            foreach (var objUsu in objUsuarios)
            {
                objUsu.Estado = 1;
                objUsu.FechaActualizacion = DateTime.Now;
                objUsu.UsuarioActualizacion = usuario.Usuario; 
                _db.Usuario.Update(objUsu);
                _db.SaveChanges();
            }

            return objOrganizacion.Id;
        }

        public async Task<long> DesactivarOrganizacionxId(long id)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objOrganizacion = _db.Organizacion.Where(x => x.Id == id).FirstOrDefault();
            objOrganizacion.Estado = 0;
            objOrganizacion.FechaActualizacion = DateTime.Now;
            objOrganizacion.UsuarioActualizacion = usuario.Usuario; 
            _db.Organizacion.Update(objOrganizacion);
            _db.SaveChanges();

            var objUsuarios = _db.Usuario.Where(x => x.DetallePersona.IdOrganizacion == id).ToList();
            foreach (var objUsu in objUsuarios) {
                objUsu.Estado = 0;
                objUsu.FechaActualizacion = DateTime.Now;
                objUsu.UsuarioActualizacion = usuario.Usuario; 
                _db.Usuario.Update(objUsu);
                _db.SaveChanges();
            }

            return objOrganizacion.Id;
        }
    }
}
