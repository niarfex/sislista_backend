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

    public class LineaProduccionRepository: ILineaProduccionRepository
    {
        private MarcoListaContexto _db = new MarcoListaContexto();
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public LineaProduccionRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<LineaProduccionEntity>> GetAll(string param)
        {
            return _db.LineaProduccion.Where(x => x.LineaProduccion.ToUpper().Contains(param.Trim().ToUpper())
            || x.CodigoLineaProduccion.ToUpper().Contains(param.Trim().ToUpper())
            || x.DescripcionLineaProduccion.ToUpper().Contains(param.Trim().ToUpper())).ToList();
        }
        public async Task<LineaProduccionEntity> GetLineaProduccionxId(long id)
        {
            return _db.LineaProduccion.Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task<long> CreateLineaProduccion(LineaProduccionModel model)
        {
            if (model.Id > 0)
            {
                var objLineaProduccion = _db.LineaProduccion.Where(x => x.Id == model.Id).FirstOrDefault();
                objLineaProduccion.CodigoLineaProduccion = model.CodigoLineaProduccion;
                objLineaProduccion.LineaProduccion = model.LineaProduccion;
                objLineaProduccion.DescripcionLineaProduccion = model.DescripcionLineaProduccion;               
                objLineaProduccion.FechaActualizacion = DateTime.Now;
                objLineaProduccion.UsuarioActualizacion = "";
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
                    UsuarioCreacion = ""
                };
                _db.LineaProduccion.Add(objLineaProduccion);
                _db.SaveChanges();
                return objLineaProduccion.Id;
            }


        }
        public async Task<long> DeleteLineaProduccionxId(long id)
        {
            var objLineaProduccion = _db.LineaProduccion.Where(x => x.Id == id).FirstOrDefault();
            objLineaProduccion.Estado = 2;
            objLineaProduccion.FechaActualizacion = DateTime.Now;
            objLineaProduccion.UsuarioActualizacion = "";
            _db.LineaProduccion.Update(objLineaProduccion);
            _db.SaveChanges();
            return objLineaProduccion.Id;
        }

        public async Task<long> ActivarLineaProduccionxId(long id)
        {
            var objLineaProduccion = _db.LineaProduccion.Where(x => x.Id == id).FirstOrDefault();
            objLineaProduccion.Estado = 1;
            objLineaProduccion.FechaActualizacion = DateTime.Now;
            objLineaProduccion.UsuarioActualizacion = "";
            _db.LineaProduccion.Update(objLineaProduccion);
            _db.SaveChanges();
            return objLineaProduccion.Id;
        }

        public async Task<long> DesactivarLineaProduccionxId(long id)
        {
            var objLineaProduccion = _db.LineaProduccion.Where(x => x.Id == id).FirstOrDefault();
            objLineaProduccion.Estado = 0;
            objLineaProduccion.FechaActualizacion = DateTime.Now;
            objLineaProduccion.UsuarioActualizacion = "";
            _db.LineaProduccion.Update(objLineaProduccion);
            _db.SaveChanges();
            return objLineaProduccion.Id;
        }
    }
}
