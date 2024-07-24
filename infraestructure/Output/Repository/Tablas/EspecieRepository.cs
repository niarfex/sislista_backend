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
    public class EspecieRepository : IEspecieRepository
    {
        private MarcoListaContexto _db;
        private readonly IConfiguration _configuracion;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public EspecieRepository(IConfiguration configuracion,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _configuracion = configuracion;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _db = new MarcoListaContexto(_configuracion[$"DatabaseSettings:ConnectionString1"]);
        }
        public async Task<List<EspecieEntity>> GetAll(string param)
        {
            return _db.Especie.Where(x => (x.Estado==0 || x.Estado==1) && (x.Especie.ToUpper().Contains(param.Trim().ToUpper())
            || x.CodigoEspecie.ToUpper().Contains(param.Trim().ToUpper())
            || x.DescripcionEspecie.ToUpper().Contains(param.Trim().ToUpper()))).ToList();
        }
        public async Task<EspecieEntity> GetEspeciexId(long id)
        {
            return _db.Especie.Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task<long> CreateEspecie(EspecieModel model)
        {
            var objRegistroCod = _db.Especie.Where(x => x.CodigoEspecie == model.CodigoEspecie
            && model.CodigoEspecie != "" && x.Id != model.Id).FirstOrDefault();
            if (objRegistroCod != null)
            {
                throw new CodigoExistException("EL Código ya se encuentra registrado");
            }

            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            if (model.Id > 0)
            {
                var objEspecie = _db.Especie.Where(x => x.Id == model.Id).FirstOrDefault();
                objEspecie.CodigoEspecie = model.CodigoEspecie;
                objEspecie.Especie = model.Especie;
                objEspecie.DescripcionEspecie = model.DescripcionEspecie;
                objEspecie.FechaActualizacion = DateTime.Now;
                objEspecie.UsuarioActualizacion = usuario.Usuario;
                _db.Especie.Update(objEspecie);
                _db.SaveChanges();
                return objEspecie.Id;
            }
            else
            {
                var objEspecie = new EspecieEntity()
                {
                    CodigoEspecie = model.CodigoEspecie,
                    Especie = model.Especie,
                    DescripcionEspecie = model.DescripcionEspecie,  
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = usuario.Usuario
                };
                _db.Especie.Add(objEspecie);
                _db.SaveChanges();
                return objEspecie.Id;
            }


        }
        public async Task<long> DeleteEspeciexId(long id)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objEspecie = _db.Especie.Where(x => x.Id == id).FirstOrDefault();
            objEspecie.Estado = 2;
            objEspecie.FechaActualizacion = DateTime.Now;
            objEspecie.UsuarioActualizacion = usuario.Usuario;
            _db.Especie.Update(objEspecie);
            _db.SaveChanges();
            return objEspecie.Id;
        }

        public async Task<long> ActivarEspeciexId(long id)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objEspecie = _db.Especie.Where(x => x.Id == id).FirstOrDefault();
            objEspecie.Estado = 1;
            objEspecie.FechaActualizacion = DateTime.Now;
            objEspecie.UsuarioActualizacion = usuario.Usuario;
            _db.Especie.Update(objEspecie);
            _db.SaveChanges();
            return objEspecie.Id;
        }

        public async Task<long> DesactivarEspeciexId(long id)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objEspecie = _db.Especie.Where(x => x.Id == id).FirstOrDefault();
            objEspecie.Estado = 0;
            objEspecie.FechaActualizacion = DateTime.Now;
            objEspecie.UsuarioActualizacion = usuario.Usuario;
            _db.Especie.Update(objEspecie);
            _db.SaveChanges();
            return objEspecie.Id;
        }
    }
}
