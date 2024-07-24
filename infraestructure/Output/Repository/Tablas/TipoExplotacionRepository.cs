using AutoMapper;
using Dapper;
using Domain.Exceptions;
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

    public class TipoExplotacionRepository: ITipoExplotacionRepository
    {
        private MarcoListaContexto _db;
        private readonly IConfiguration _configuracion;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public TipoExplotacionRepository(IConfiguration configuracion,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _configuracion = configuracion;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _db = new MarcoListaContexto(_configuracion[$"DatabaseSettings:ConnectionString1"]);
        }
        public async Task<List<TipoExplotacionEntity>> GetAll(string param)
        {
            return _db.TipoExplotacion.Where(x => (x.Estado==0 || x.Estado==1) && (x.TipoExplotacion.ToUpper().Contains(param.Trim().ToUpper())
             || x.CodigoTipoExplotacion.ToUpper().Contains(param.Trim().ToUpper())
             || x.DescripcionTipoExplotacion.ToUpper().Contains(param.Trim().ToUpper()))).ToList();
        }
        public async Task<TipoExplotacionEntity> GetTipoExplotacionxId(long id)
        {
            return _db.TipoExplotacion.Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task<long> CreateTipoExplotacion(TipoExplotacionModel model)
        {
            var objRegistroCod = _db.TipoExplotacion.Where(x => x.TipoExplotacion == model.TipoExplotacion
            && model.TipoExplotacion != "" && x.Id != model.Id).FirstOrDefault();
            if (objRegistroCod != null)
            {
                throw new CodigoExistException("EL Código ya se encuentra registrado");
            }

            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            if (model.Id > 0)
            {
                var objTipoExplotacion = _db.TipoExplotacion.Where(x => x.Id == model.Id).FirstOrDefault();
                objTipoExplotacion.CodigoTipoExplotacion = model.CodigoTipoExplotacion;
                objTipoExplotacion.TipoExplotacion = model.TipoExplotacion;
                objTipoExplotacion.DescripcionTipoExplotacion = model.DescripcionTipoExplotacion;               
                objTipoExplotacion.FechaActualizacion = DateTime.Now;
                objTipoExplotacion.UsuarioActualizacion = usuario.Usuario;
                _db.TipoExplotacion.Update(objTipoExplotacion);
                _db.SaveChanges();
                return objTipoExplotacion.Id;
            }
            else
            {
                var objTipoExplotacion = new TipoExplotacionEntity()
                {
                    CodigoTipoExplotacion = model.CodigoTipoExplotacion,
                    TipoExplotacion = model.TipoExplotacion,
                    DescripcionTipoExplotacion = model.DescripcionTipoExplotacion,      
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = usuario.Usuario
                };
                _db.TipoExplotacion.Add(objTipoExplotacion);
                _db.SaveChanges();
                return objTipoExplotacion.Id;
            }


        }
        public async Task<long> DeleteTipoExplotacionxId(long id)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objTipoExplotacion = _db.TipoExplotacion.Where(x => x.Id == id).FirstOrDefault();
            objTipoExplotacion.Estado = 2;
            objTipoExplotacion.FechaActualizacion = DateTime.Now;
            objTipoExplotacion.UsuarioActualizacion = usuario.Usuario;
            _db.TipoExplotacion.Update(objTipoExplotacion);
            _db.SaveChanges();
            return objTipoExplotacion.Id;
        }

        public async Task<long> ActivarTipoExplotacionxId(long id)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objTipoExplotacion = _db.TipoExplotacion.Where(x => x.Id == id).FirstOrDefault();
            objTipoExplotacion.Estado = 1;
            objTipoExplotacion.FechaActualizacion = DateTime.Now;
            objTipoExplotacion.UsuarioActualizacion = usuario.Usuario;
            _db.TipoExplotacion.Update(objTipoExplotacion);
            _db.SaveChanges();
            return objTipoExplotacion.Id;
        }

        public async Task<long> DesactivarTipoExplotacionxId(long id)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objTipoExplotacion = _db.TipoExplotacion.Where(x => x.Id == id).FirstOrDefault();
            objTipoExplotacion.Estado = 0;
            objTipoExplotacion.FechaActualizacion = DateTime.Now;
            objTipoExplotacion.UsuarioActualizacion = usuario.Usuario;
            _db.TipoExplotacion.Update(objTipoExplotacion);
            _db.SaveChanges();
            return objTipoExplotacion.Id;
        }
    }
}
