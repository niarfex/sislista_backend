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

    public class LineaProduccionRepository: ILineaProduccionRepository
    {
        private MarcoListaContexto _db;
        private readonly IConfiguration _configuracion;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public LineaProduccionRepository(IConfiguration configuracion,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _configuracion = configuracion;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _db = new MarcoListaContexto(_configuracion[$"DatabaseSettings:ConnectionSISLISTA"]);
        }
        public async Task<List<LineaProduccionEntity>> GetAll(string param)
        {
            return _db.LineaProduccion.Where(x => (x.Estado==0 || x.Estado==1) && (x.LineaProduccion.ToUpper().Contains(param.Trim().ToUpper())
            || x.CodigoLineaProduccion.ToUpper().Contains(param.Trim().ToUpper())
            || x.DescripcionLineaProduccion.ToUpper().Contains(param.Trim().ToUpper()))).ToList();
        }
        public async Task<LineaProduccionEntity> GetLineaProduccionxId(long id)
        {
            return _db.LineaProduccion.Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task<long> CreateLineaProduccion(LineaProduccionModel model)
        {
            var objRegistroCod = _db.LineaProduccion.Where(x => x.CodigoLineaProduccion == model.CodigoLineaProduccion
            && model.CodigoLineaProduccion != "" && x.Id != model.Id).FirstOrDefault();
            if (objRegistroCod != null)
            {
                throw new CodigoExistException("EL Código ya se encuentra registrado");
            }

            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            if (model.Id > 0)
            {
                var objLineaProduccion = _db.LineaProduccion.Where(x => x.Id == model.Id).FirstOrDefault();
                objLineaProduccion.CodigoLineaProduccion = model.CodigoLineaProduccion;
                objLineaProduccion.LineaProduccion = model.LineaProduccion;
                objLineaProduccion.DescripcionLineaProduccion = model.DescripcionLineaProduccion;               
                objLineaProduccion.FechaActualizacion = DateTime.Now;
                objLineaProduccion.UsuarioActualizacion = usuario.Usuario;
                _db.LineaProduccion.Update(objLineaProduccion);
                _db.SaveChanges();
                return objLineaProduccion.Id;
            }
            else
            {
                var objLineaProduccion = new LineaProduccionEntity()
                {
                    CodigoLineaProduccion = model.CodigoLineaProduccion,
                    LineaProduccion = model.LineaProduccion,
                    DescripcionLineaProduccion = model.DescripcionLineaProduccion,                 
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = usuario.Usuario
                };
                _db.LineaProduccion.Add(objLineaProduccion);
                _db.SaveChanges();
                return objLineaProduccion.Id;
            }


        }
        public async Task<long> DeleteLineaProduccionxId(long id)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objLineaProduccion = _db.LineaProduccion.Where(x => x.Id == id).FirstOrDefault();
            objLineaProduccion.Estado = 2;
            objLineaProduccion.FechaActualizacion = DateTime.Now;
            objLineaProduccion.UsuarioActualizacion = usuario.Usuario;
            _db.LineaProduccion.Update(objLineaProduccion);
            _db.SaveChanges();
            return objLineaProduccion.Id;
        }

        public async Task<long> ActivarLineaProduccionxId(long id)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objLineaProduccion = _db.LineaProduccion.Where(x => x.Id == id).FirstOrDefault();
            objLineaProduccion.Estado = 1;
            objLineaProduccion.FechaActualizacion = DateTime.Now;
            objLineaProduccion.UsuarioActualizacion = usuario.Usuario;
            _db.LineaProduccion.Update(objLineaProduccion);
            _db.SaveChanges();
            return objLineaProduccion.Id;
        }

        public async Task<long> DesactivarLineaProduccionxId(long id)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objLineaProduccion = _db.LineaProduccion.Where(x => x.Id == id).FirstOrDefault();
            objLineaProduccion.Estado = 0;
            objLineaProduccion.FechaActualizacion = DateTime.Now;
            objLineaProduccion.UsuarioActualizacion = usuario.Usuario;
            _db.LineaProduccion.Update(objLineaProduccion);
            _db.SaveChanges();
            return objLineaProduccion.Id;
        }
    }
}
