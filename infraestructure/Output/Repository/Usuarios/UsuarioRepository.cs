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
    public class UsuarioRepository : IUsuarioRepository
    {
        private MarcoListaContexto _db = new MarcoListaContexto();
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public UsuarioRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<UsuarioModel>> GetAll(string param)
        {
            var query = from u in _db.Usuario
                        join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                        join pf in _db.Perfil on up.IdPerfil equals pf.Id
                        join pe in _db.Persona on u.IdPersona equals pe.Id
                        where (u.Estado == 0 || u.Estado == 1) && (up.Estado == 0 || up.Estado == 1) 
                        && (pe.Estado == 0 || pe.Estado == 1) && (pf.Estado == 0 || pf.Estado == 1)
                        select new UsuarioModel
                        {
                           CodigoUUIDUsuario=u.CodigoUUID.ToString(),
                           Perfil=pf.Perfil,
                           NumeroDocumento=pe.NumeroDocumento,
                           //NombreCompleto=(pe.Nombre+" "+pe.ApellidoPaterno + " "+pe.ApellidoMaterno).ToString(),
                           CorreoElectronico=pe.CorreoElectronico,
                           Estado=u.Estado
                        };
            return query.ToList();
        }
        public async Task<UsuarioEntity> GetUsuarioxUUID(string uuid)
        {
            return _db.Usuario.Where(x => x.CodigoUUID.ToString() == uuid).FirstOrDefault();
        }
        public async Task<string> CreateUsuario(UsuarioModel model)
        {
            //Registramos o actualizamos los datos de la persona
            long personaId;
            var persona = _db.Persona.Where(x => (x.CodigoUUID.ToString() == model.CodigoUUIDPersona && model.CodigoUUIDPersona.Trim() != "")
            || (x.NumeroDocumento == model.NumeroDocumento && x.IdTipoDocumento == model.IdTipoDocumento && model.NumeroDocumento.Trim() != "")).FirstOrDefault();
            if (persona == null)
            {//Si la persona no existe                 
                var objPersona = new PersonaEntity()
                {
                    IdTipoDocumento = model.IdTipoDocumento,
                    NumeroDocumento = model.NumeroDocumento, 
                    Nombre = model.Nombre,
                    ApellidoPaterno = model.ApellidoPaterno,
                    ApellidoMaterno = model.ApellidoMaterno,        
                    Celular = model.Celular,
                    CorreoElectronico = model.CorreoElectronico,   
                    IdOrganizacion = model.IdOrganizacion,
                    OficinaArea = model.OficinaArea,
                    Cargo = model.Cargo,                    
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = ""
                };
                _db.Persona.Add(objPersona);
                _db.SaveChanges();
                personaId = objPersona.Id;
            }
            else
            {
            
                persona.IdTipoDocumento = model.IdTipoDocumento;
                persona.NumeroDocumento = model.NumeroDocumento;
                persona.Nombre = model.Nombre;
                persona.ApellidoPaterno = model.ApellidoPaterno;
                persona.ApellidoMaterno = model.ApellidoMaterno;
                persona.Celular = model.Celular;
                persona.CorreoElectronico = model.CorreoElectronico;
                persona.IdOrganizacion = model.IdOrganizacion;
                persona.OficinaArea = model.OficinaArea;
                persona.Cargo = model.Cargo;
                persona.FechaActualizacion = DateTime.Now;
                persona.UsuarioActualizacion = "";
                _db.Persona.Update(persona);
                _db.SaveChanges();
                personaId = persona.Id;
            }


            if (model.CodigoUUIDUsuario != null)
            {
                var objUsuario = _db.Usuario.Where(x => x.CodigoUUID.ToString() == model.CodigoUUIDUsuario).FirstOrDefault();
                objUsuario.IdPersona = personaId;     
                
                objUsuario.FechaActualizacion = DateTime.Now;
                objUsuario.UsuarioActualizacion = "";
                _db.Usuario.Update(objUsuario);
                _db.SaveChanges();

                var objUsuarioPerfil = _db.UsuarioPerfil.Where(x => x.IdUsuario == objUsuario.Id).FirstOrDefault();
                objUsuarioPerfil.IdPerfil = model.IdPerfil;
                objUsuarioPerfil.FechaActualizacion = DateTime.Now;
                objUsuarioPerfil.UsuarioActualizacion = "";
                _db.UsuarioPerfil.Update(objUsuarioPerfil);
                _db.SaveChanges();

                return objUsuario.CodigoUUID.ToString();
            }
            else
            {
                var objUsuario = new UsuarioEntity()
                {
                    IdPersona = personaId,

                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = ""
                };
                _db.Usuario.Add(objUsuario);
                _db.SaveChanges();

                var objUsuarioPerfil = new UsuarioPerfilEntity()
                {
                    IdUsuario = objUsuario.Id,
                    IdPerfil = model.IdPerfil,
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = ""
                };
                _db.UsuarioPerfil.Add(objUsuarioPerfil);
                _db.SaveChanges();

                return objUsuario.CodigoUUID.ToString();
            }


        }
        public async Task<string> DeleteUsuarioxUUID(string uuid)
        {
            var objUsuario = _db.Usuario.Where(x => x.CodigoUUID.ToString() == uuid).FirstOrDefault();
            objUsuario.Estado = 2;
            objUsuario.FechaActualizacion = DateTime.Now;
            objUsuario.UsuarioActualizacion = "";
            _db.Usuario.Update(objUsuario);
            _db.SaveChanges();
            return objUsuario.CodigoUUID.ToString();
        }

        public async Task<string> ActivarUsuarioxUUID(string uuid)
        {
            var objUsuario = _db.Usuario.Where(x => x.CodigoUUID.ToString() == uuid).FirstOrDefault();
            objUsuario.Estado = 1;
            objUsuario.FechaActualizacion = DateTime.Now;
            objUsuario.UsuarioActualizacion = "";
            _db.Usuario.Update(objUsuario);
            _db.SaveChanges();
            return objUsuario.CodigoUUID.ToString();
        }

        public async Task<string> DesactivarUsuarioxUUID(string uuid)
        {
            var objUsuario = _db.Usuario.Where(x => x.CodigoUUID.ToString() == uuid).FirstOrDefault();
            objUsuario.Estado = 0;
            objUsuario.FechaActualizacion = DateTime.Now;
            objUsuario.UsuarioActualizacion = "";
            _db.Usuario.Update(objUsuario);
            _db.SaveChanges();
            return objUsuario.CodigoUUID.ToString();
        }
    }
}
