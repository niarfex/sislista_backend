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
    public class PanelRegistroRepository: IPanelRegistroRepository
    {
        private MarcoListaContexto _db;
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public PanelRegistroRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
            _db = new MarcoListaContexto(_configuracion[$"DatabaseSettings:ConnectionString1"]);
        }
        public async Task<List<PanelRegistroEntity>> GetAll(string param)
        {
            return _db.PanelRegistro.Where(x => (x.Estado==0 || x.Estado==1 || x.Estado==2) 
            && (x.ProgramacionRegistro.ToUpper().Trim().Contains(param.ToUpper().Trim()))).ToList();
        }
        public async Task<PanelRegistroEntity> GetPanelRegistroxId(long id)
        {
            return _db.PanelRegistro.Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task<long> CreatePanelRegistro(PanelRegistroModel model)
        {
            if (model.Id > 0)
            {
                var objPanelRegistro = _db.PanelRegistro.Where(x => x.Id == model.Id).FirstOrDefault();
                objPanelRegistro.IdPlantilla = model.IdPlantilla;
                objPanelRegistro.IdAnio = model.IdAnio;
                objPanelRegistro.ProgramacionRegistro = model.ProgramacionRegistro;
                objPanelRegistro.FechaInicio = model.FechaInicio;
                objPanelRegistro.FechaFin=model.FechaFin;
                objPanelRegistro.DecretoNorma= model.DecretoNorma;
                objPanelRegistro.Objetivo = model.Objetivo;
                objPanelRegistro.EnteRector = model.EnteRector;
                objPanelRegistro.FechaActualizacion = DateTime.Now;
                objPanelRegistro.UsuarioActualizacion = "";
                _db.PanelRegistro.Update(objPanelRegistro);
                _db.SaveChanges();
                return objPanelRegistro.Id;
            }
            else
            {
                var objPanelRegistro = new PanelRegistroEntity()
                {
                    IdPlantilla = model.IdPlantilla,
                    IdAnio = model.IdAnio,
                    ProgramacionRegistro = model.ProgramacionRegistro,
                    FechaInicio = model.FechaInicio,
                    FechaFin = model.FechaFin,
                    DecretoNorma = model.DecretoNorma,
                    Objetivo = model.Objetivo,
                    EnteRector = model.EnteRector,
                    EstadoProgramacion=1,
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = ""
                };
                _db.PanelRegistro.Add(objPanelRegistro);
                _db.SaveChanges();
                return objPanelRegistro.Id;
            }


        }
        public async Task<long> DeletePanelRegistroxId(long id)
        {
            var objPanelRegistro = _db.PanelRegistro.Where(x => x.Id == id).FirstOrDefault();
            objPanelRegistro.Estado = 2;
            objPanelRegistro.EstadoProgramacion = 5;
            objPanelRegistro.FechaActualizacion = DateTime.Now;
            objPanelRegistro.UsuarioActualizacion = "";
            _db.PanelRegistro.Update(objPanelRegistro);
            _db.SaveChanges();
            return objPanelRegistro.Id;
        }
        public async Task<long> PublicarPanelRegistroxId(long id)
        {
            var objPanelRegistro = _db.PanelRegistro.Where(x => x.Id == id).FirstOrDefault();
            objPanelRegistro.EstadoProgramacion = 2;
            objPanelRegistro.FechaActualizacion = DateTime.Now;
            objPanelRegistro.UsuarioActualizacion = "";
            _db.PanelRegistro.Update(objPanelRegistro);
            _db.SaveChanges();
            return objPanelRegistro.Id;
        }
        public async Task<long> PausarPanelRegistroxId(long id)
        {
            var objPanelRegistro = _db.PanelRegistro.Where(x => x.Id == id).FirstOrDefault();
            objPanelRegistro.EstadoProgramacion=4;
            objPanelRegistro.FechaActualizacion = DateTime.Now;
            objPanelRegistro.UsuarioActualizacion = "";
            _db.PanelRegistro.Update(objPanelRegistro);
            _db.SaveChanges();
            return objPanelRegistro.Id;
        }
        public async Task<long> ReiniciarPanelRegistroxId(long id)
        {
            var objPanelRegistro = _db.PanelRegistro.Where(x => x.Id == id).FirstOrDefault();
            objPanelRegistro.EstadoProgramacion = 2;
            objPanelRegistro.FechaActualizacion = DateTime.Now;
            objPanelRegistro.UsuarioActualizacion = "";
            _db.PanelRegistro.Update(objPanelRegistro);
            _db.SaveChanges();
            return objPanelRegistro.Id;
        }
    }
}
