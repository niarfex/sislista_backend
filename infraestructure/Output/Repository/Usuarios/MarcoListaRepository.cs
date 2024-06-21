using Application.Output;
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
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace Infra.MarcoLista.Output.Repository
{
    public class MarcoListaRepository: IMarcoListaRepository
    {
        private MarcoListaContexto _db = new MarcoListaContexto();
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public MarcoListaRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<MarcoListaModel>> GetAll(string param)
        {
            var query = from m in _db.MarcoLista
                        join p in _db.Persona on m.IdPersona equals p.Id
                        join c in _db.CondicionJuridica on p.IdCondicionJuridica equals c.Id
                        where (m.Estado == 0 || m.Estado == 1) && (p.Estado == 0 || p.Estado == 1)
                        select new MarcoListaModel
                        { 
                            Id=m.Id,
                            NumeroDocumento=p.NumeroDocumento,
                            NombreCompleto= p.RazonSocial==""?(p.Nombre+" "+p.ApellidoPaterno+" "+p.ApellidoMaterno):p.RazonSocial,
                            CondicionJuridica=c.CondicionJuridica,
                            NombreRepLegal=p.NombreRepLegal,   
                            Estado=m.Estado
                        };
            return query.ToList();
        }
        public async Task<MarcoListaModel> GetMarcoListaxId(long id)
        {      

            var query = from m in _db.MarcoLista
                        join p in _db.Persona on m.IdPersona equals p.Id 
                        where (m.Estado == 0 || m.Estado == 1) && (p.Estado == 0 || p.Estado == 1)
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
            //Registramos o actualizamos los datos de la persona
            long personaId;
            var persona = _db.Persona.Where(x => (x.CodigoUUID.ToString() == model.CodigoUUIDPersona && model.CodigoUUIDPersona.Trim() != "") 
            || (x.NumeroDocumento==model.NumeroDocumento && x.IdTipoDocumento==model.IdTipoDocumento && model.NumeroDocumento.Trim() != "")).FirstOrDefault();
            if (persona == null) {//Si la persona no existe                 
                var objPersona = new PersonaEntity()
                {            
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
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = ""
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
                persona.FechaActualizacion = DateTime.Now;
                persona.UsuarioActualizacion = "";
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
                objMarcoLista.IdPersona = personaId;
                objMarcoLista.Direccion = model.Direccion;
                objMarcoLista.FechaActualizacion = DateTime.Now;
                objMarcoLista.UsuarioActualizacion = "";
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
                    IdPersona = personaId,
                    Direccion = model.Direccion,               
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = ""
                };
                _db.MarcoLista.Add(objMarcoLista);
                _db.SaveChanges();
                return objMarcoLista.Id;
            }
        }
        public async Task<long> DeleteMarcoListaxId(long id)
        {
            var objMarcoLista = _db.MarcoLista.Where(x => x.Id == id).FirstOrDefault();
            objMarcoLista.Estado = 2;
            objMarcoLista.FechaActualizacion = DateTime.Now;
            objMarcoLista.UsuarioActualizacion = "";
            _db.MarcoLista.Update(objMarcoLista);
            _db.SaveChanges();
            return objMarcoLista.Id;
        }

        public async Task<long> ActivarMarcoListaxId(long id)
        {
            var objMarcoLista = _db.MarcoLista.Where(x => x.Id == id).FirstOrDefault();
            objMarcoLista.Estado = 1;
            objMarcoLista.FechaActualizacion = DateTime.Now;
            objMarcoLista.UsuarioActualizacion = "";
            _db.MarcoLista.Update(objMarcoLista);
            _db.SaveChanges();
            return objMarcoLista.Id;
        }

        public async Task<long> DesactivarMarcoListaxId(long id)
        {
            var objMarcoLista = _db.MarcoLista.Where(x => x.Id == id).FirstOrDefault();
            objMarcoLista.Estado = 0;
            objMarcoLista.FechaActualizacion = DateTime.Now;
            objMarcoLista.UsuarioActualizacion = "";
            _db.MarcoLista.Update(objMarcoLista);
            _db.SaveChanges();
            return objMarcoLista.Id;
        }
    }
}
