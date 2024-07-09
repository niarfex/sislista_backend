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
    public class CondicionJuridicaRepository: ICondicionJuridicaRepository
    {
        private MarcoListaContexto _db;
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public CondicionJuridicaRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
            _db = new MarcoListaContexto(_configuracion[$"DatabaseSettings:ConnectionString1"]);
        }
        public async Task<List<CondicionJuridicaEntity>> GetAll(string param)
        {
            return _db.CondicionJuridica.Where(x => (x.Estado==1 || x.Estado==0) && (x.CondicionJuridica.ToUpper().Contains(param.Trim().ToUpper())
            || x.CodigoCondicionJuridica.ToUpper().Contains(param.Trim().ToUpper())
            || x.DescripcionCondicionJuridica.ToUpper().Contains(param.Trim().ToUpper()))).ToList();
        }
        public async Task<CondicionJuridicaEntity> GetCondicionJuridicaxId(long id)
        {
            return _db.CondicionJuridica.Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task<long> CreateCondicionJuridica(CondicionJuridicaModel model)
        {
            if (model.Id > 0)
            {
                var objCondicionJuridica = _db.CondicionJuridica.Where(x => x.Id == model.Id).FirstOrDefault();
                objCondicionJuridica.CodigoCondicionJuridica = model.CodigoCondicionJuridica;
                objCondicionJuridica.CondicionJuridica = model.CondicionJuridica;
                objCondicionJuridica.DescripcionCondicionJuridica = model.DescripcionCondicionJuridica;
                objCondicionJuridica.Otros = model.Otros;
                objCondicionJuridica.FechaActualizacion = DateTime.Now;
                objCondicionJuridica.UsuarioActualizacion = "";
                _db.CondicionJuridica.Update(objCondicionJuridica);
                _db.SaveChanges();
                return objCondicionJuridica.Id;
            }
            else
            {
                var objCondicionJuridica = new CondicionJuridicaEntity()
                {
                    CodigoCondicionJuridica = model.CodigoCondicionJuridica,
                    CondicionJuridica = model.CondicionJuridica,
                    DescripcionCondicionJuridica = model.DescripcionCondicionJuridica,
                    Otros = model.Otros,
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = ""
                };
                _db.CondicionJuridica.Add(objCondicionJuridica);
                _db.SaveChanges();
                return objCondicionJuridica.Id;
            }


        }
        public async Task<long> DeleteCondicionJuridicaxId(long id)
        {
            var objCondicionJuridica = _db.CondicionJuridica.Where(x => x.Id == id).FirstOrDefault();
            objCondicionJuridica.Estado = 2;
            objCondicionJuridica.FechaActualizacion = DateTime.Now;
            objCondicionJuridica.UsuarioActualizacion = "";
            _db.CondicionJuridica.Update(objCondicionJuridica);
            _db.SaveChanges();
            return objCondicionJuridica.Id;
        }

        public async Task<long> ActivarCondicionJuridicaxId(long id)
        {
            var objCondicionJuridica = _db.CondicionJuridica.Where(x => x.Id == id).FirstOrDefault();
            objCondicionJuridica.Estado = 1;
            objCondicionJuridica.FechaActualizacion = DateTime.Now;
            objCondicionJuridica.UsuarioActualizacion = "";
            _db.CondicionJuridica.Update(objCondicionJuridica);
            _db.SaveChanges();
            return objCondicionJuridica.Id;
        }

        public async Task<long> DesactivarCondicionJuridicaxId(long id)
        {
            var objCondicionJuridica = _db.CondicionJuridica.Where(x => x.Id == id).FirstOrDefault();
            objCondicionJuridica.Estado = 0;
            objCondicionJuridica.FechaActualizacion = DateTime.Now;
            objCondicionJuridica.UsuarioActualizacion = "";
            _db.CondicionJuridica.Update(objCondicionJuridica);
            _db.SaveChanges();
            return objCondicionJuridica.Id;
        }
    }
}
