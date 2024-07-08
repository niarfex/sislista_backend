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
    public class EspecieRepository : IEspecieRepository
    {
        private MarcoListaContexto _db = new MarcoListaContexto();
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public EspecieRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<EspecieEntity>> GetAll(string param)
        {
            return _db.Especie.Where(x => x.Especie.ToUpper().Contains(param.Trim().ToUpper())
            || x.CodigoEspecie.ToUpper().Contains(param.Trim().ToUpper())
            || x.DescripcionEspecie.ToUpper().Contains(param.Trim().ToUpper())).ToList();
        }
        public async Task<EspecieEntity> GetEspeciexId(long id)
        {
            return _db.Especie.Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task<long> CreateEspecie(EspecieModel model)
        {
            if (model.Id > 0)
            {
                var objEspecie = _db.Especie.Where(x => x.Id == model.Id).FirstOrDefault();
                objEspecie.CodigoEspecie = model.CodigoEspecie;
                objEspecie.Especie = model.Especie;
                objEspecie.DescripcionEspecie = model.DescripcionEspecie;
                objEspecie.FechaActualizacion = DateTime.Now;
                objEspecie.UsuarioActualizacion = "";
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
                    UsuarioCreacion = ""
                };
                _db.Especie.Add(objEspecie);
                _db.SaveChanges();
                return objEspecie.Id;
            }


        }
        public async Task<long> DeleteEspeciexId(long id)
        {
            var objEspecie = _db.Especie.Where(x => x.Id == id).FirstOrDefault();
            objEspecie.Estado = 2;
            objEspecie.FechaActualizacion = DateTime.Now;
            objEspecie.UsuarioActualizacion = "";
            _db.Especie.Update(objEspecie);
            _db.SaveChanges();
            return objEspecie.Id;
        }

        public async Task<long> ActivarEspeciexId(long id)
        {
            var objEspecie = _db.Especie.Where(x => x.Id == id).FirstOrDefault();
            objEspecie.Estado = 1;
            objEspecie.FechaActualizacion = DateTime.Now;
            objEspecie.UsuarioActualizacion = "";
            _db.Especie.Update(objEspecie);
            _db.SaveChanges();
            return objEspecie.Id;
        }

        public async Task<long> DesactivarEspeciexId(long id)
        {
            var objEspecie = _db.Especie.Where(x => x.Id == id).FirstOrDefault();
            objEspecie.Estado = 0;
            objEspecie.FechaActualizacion = DateTime.Now;
            objEspecie.UsuarioActualizacion = "";
            _db.Especie.Update(objEspecie);
            _db.SaveChanges();
            return objEspecie.Id;
        }
    }
}
