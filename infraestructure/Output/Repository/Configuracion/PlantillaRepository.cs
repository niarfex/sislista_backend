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
    public class PlantillaRepository:IPlantillaRepository
    {
        private MarcoListaContexto _db;
        private readonly IConfiguration _configuracion;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private DBOracle dBOracle = new DBOracle();
        public PlantillaRepository(IConfiguration configuracion,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _configuracion = configuracion;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _db = new MarcoListaContexto(_configuracion[$"DatabaseSettings:ConnectionSISLISTA"]);
        }
        public async Task<List<PlantillaEntity>> GetAll(string param)
        {
            return _db.Plantilla.Where(x=> (x.Estado==0 || x.Estado==1) && (x.Plantilla.ToUpper().Trim().Contains(param.ToUpper().Trim())))
                .OrderByDescending(x=>x.FechaActualizacion.HasValue?x.FechaActualizacion:x.FechaRegistro).ToList();
        }
        public async Task<PlantillaEntity> GetPlantillaxId(long id)
        {
            return _db.Plantilla.Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task<long> CreatePlantilla(PlantillaModel model)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            if (model.Id > 0)
            {
                var objPlantilla = _db.Plantilla.Where(x => x.Id == model.Id).FirstOrDefault();
                objPlantilla.Plantilla = model.Plantilla;
                objPlantilla.Descripcion = model.Descripcion;
                objPlantilla.NumCuestionario = model.NumCuestionario;
                objPlantilla.FechaActualizacion = DateTime.Now;
                objPlantilla.UsuarioActualizacion = usuario.Usuario;
                _db.Plantilla.Update(objPlantilla);
                _db.SaveChanges();
                return objPlantilla.Id;
            }
            else
            {
                var objPlantilla = new PlantillaEntity()
                {
                    Plantilla = model.Plantilla,
                    Descripcion = model.Descripcion,
                    NumCuestionario = model.NumCuestionario,
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = usuario.Usuario,
                };
                _db.Plantilla.Add(objPlantilla);
                _db.SaveChanges();
                return objPlantilla.Id;
            }


        }
        public async Task<long> DeletePlantillaxId(long id)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objPlantilla = _db.Plantilla.Where(x => x.Id == id).FirstOrDefault();
            objPlantilla.Estado = 2;
            objPlantilla.FechaActualizacion = DateTime.Now;
            objPlantilla.UsuarioActualizacion = usuario.Usuario; 
            _db.Plantilla.Update(objPlantilla);
            _db.SaveChanges();
            return objPlantilla.Id;
        }

        public async Task<long> ActivarPlantillaxId(long id)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objPlantilla = _db.Plantilla.Where(x => x.Id == id).FirstOrDefault();
            objPlantilla.Estado = 1;
            objPlantilla.FechaActualizacion = DateTime.Now;
            objPlantilla.UsuarioActualizacion = usuario.Usuario; 
            _db.Plantilla.Update(objPlantilla);
            _db.SaveChanges();
            return objPlantilla.Id;
        }

        public async Task<long> DesactivarPlantillaxId(long id)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objPlantilla = _db.Plantilla.Where(x => x.Id == id).FirstOrDefault();
            objPlantilla.Estado = 0;
            objPlantilla.FechaActualizacion = DateTime.Now;
            objPlantilla.UsuarioActualizacion = usuario.Usuario; 
            _db.Plantilla.Update(objPlantilla);
            _db.SaveChanges();
            return objPlantilla.Id;
        }
    }
}
