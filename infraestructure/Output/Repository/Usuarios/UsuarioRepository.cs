using AutoMapper;
using Dapper;
using Domain.Model;
using Infra.MarcoLista.Contextos;
using Infra.MarcoLista.GeneralSQL;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Infra.MarcoLista.Output.Repository;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace Infra.MarcoLista.Output.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private MarcoListaContexto _db = new MarcoListaContexto();
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        private DBOracle dBOracle = new DBOracle();
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
                        where (u.Usuario.ToUpper().Trim().Contains(param.ToUpper().Trim()) || pf.Perfil.ToUpper().Trim().Contains(param.ToUpper().Trim()) || 
                        pe.Nombre.ToUpper().Trim().Contains(param.ToUpper().Trim()) || pe.ApellidoMaterno.ToUpper().Trim().Contains(param.ToUpper().Trim()) || 
                        pe.ApellidoPaterno.ToUpper().Trim().Contains(param.ToUpper().Trim()))
                        select new UsuarioModel
                        {
                            Id = u.Id,
                            CodigoUUIDUsuario = u.CodigoUUID.ToString(),
                            Perfil = pf.Perfil,
                            NumeroDocumento = pe.NumeroDocumento,
                            NombreCompleto = pe.Nombre + " " + pe.ApellidoPaterno + " " + pe.ApellidoMaterno,
                            CorreoElectronico = pe.CorreoElectronico,
                            IdOrganizacion = pe.IdOrganizacion,
                            Estado = u.Estado
                        };
            return query.ToList();
        }
        public async Task<UsuarioModel> GetUsuarioxUUID(string uuid)
        {
            var query = from u in _db.Usuario
                        join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                        join pe in _db.Persona on u.IdPersona equals pe.Id
                        where (u.Estado == 0 || u.Estado == 1) && (up.Estado == 0 || up.Estado == 1)
                        && (pe.Estado == 0 || pe.Estado == 1) && u.CodigoUUID == uuid
                        select new UsuarioModel
                        {
                            Id = u.Id,
                            CodigoUUIDUsuario = u.CodigoUUID.ToString(),
                            Usuario = u.Usuario,
                            //ClaveAlmacenada= u.Clave, //GetClaveDesencriptada(u.Clave).ToString(),
                            IdPerfil = up.IdPerfil,
                            IdTipoDocumento = pe.IdTipoDocumento,
                            NumeroDocumento = pe.NumeroDocumento,
                            Nombre = pe.Nombre,
                            ApellidoPaterno = pe.ApellidoPaterno,
                            ApellidoMaterno = pe.ApellidoMaterno,
                            IdOrganizacion = pe.IdOrganizacion,
                            OficinaArea = pe.OficinaArea,
                            Cargo = pe.Cargo,
                            Celular = pe.Celular,
                            CorreoElectronico = pe.CorreoElectronico,
                            Estado=u.Estado
                        };

            var objUsuario= query.FirstOrDefault();
            objUsuario.Clave = await GetClaveUsuario(objUsuario.Id);         
            return objUsuario;
        }
        public async Task<LoginModel> GetUsuarioLoginxUUID(string uuid)
        {
            var query = from u in _db.Usuario
                        join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                        join p in _db.Perfil on up.IdPerfil equals p.Id
                        join pe in _db.Persona on u.IdPersona equals pe.Id
                        where (u.Estado == 0 || u.Estado == 1) && (up.Estado == 0 || up.Estado == 1)
                        && (pe.Estado == 0 || pe.Estado == 1) && u.CodigoUUID == uuid
                        select new LoginModel
                        {                          
                            CodigoUUID = u.CodigoUUID.ToString(),
                            Usuario = u.Usuario,
                            IdPerfil = up.IdPerfil,   
                            CodigoPerfil = p.CodigoPerfil,
                            Perfil = p.Perfil,
                            NumeroDocumento = pe.NumeroDocumento,
                            Nombre = pe.Nombre,
                            ApellidoPaterno = pe.ApellidoPaterno,
                            ApellidoMaterno = pe.ApellidoMaterno                            
                        };
      
            return query.FirstOrDefault();
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
                registrarMarcoListaAsignado(objUsuario,model);
                return objUsuario.CodigoUUID.ToString();
            }
            else
            {
                var clave = GetRandomPassword(12);
                var claveCifrada = await GetClaveEncriptada(clave);

                var objUsuario = new UsuarioEntity()
                {
                    IdPersona = personaId,
                    Usuario = model.NumeroDocumento,
                    Clave = claveCifrada,
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
                registrarMarcoListaAsignado(objUsuario,model);
                return objUsuario.CodigoUUID.ToString();
            }
        }
        private void registrarMarcoListaAsignado(UsuarioEntity objUsuario,UsuarioModel model)
        {
            var filas = from mu in _db.UsuarioMarcoLista
                        where mu.IdUsuario == objUsuario.Id
                        select mu;

            _db.UsuarioMarcoLista.RemoveRange(filas);
            _db.SaveChanges();
            foreach (var marco in model.ListMarcoListaAsignados) {
                var objMarcoUsuario = new UsuarioMarcoListaEntity()
                {
                    IdUsuario = objUsuario.Id,
                    IdMarcoLista = marco.Id,
                    Estado=1,
                    FechaRegistro=DateTime.Now,
                    UsuarioCreacion=""
                };
                _db.UsuarioMarcoLista.Add(objMarcoUsuario);
                _db.SaveChanges();
            }
        }       
        private static string GetRandomPassword(int length)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!¡#$%&()=¿?";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
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
        public async Task<List<UsuarioModel>> GetCorreosUsuariosxPerfil(long idPerfil) {
            if (idPerfil == 0) {
                var usuarios = from u in _db.Usuario
                               join p in _db.Persona on u.IdPersona equals p.Id
                               join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                               where u.Estado == 1
                               select new UsuarioModel
                               {
                                   CodigoUUIDPersona = p.CodigoUUID,
                                   Nombre = p.Nombre,
                                   ApellidoPaterno = p.ApellidoPaterno,
                                   ApellidoMaterno = p.ApellidoMaterno,
                                   CorreoElectronico = p.CorreoElectronico
                               };
                return usuarios.ToList();
            }
            else {
                var usuarios = from u in _db.Usuario
                               join p in _db.Persona on u.IdPersona equals p.Id
                               join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                               where up.IdPerfil == idPerfil
                               where u.Estado == 1
                               select new UsuarioModel
                               {
                                   CodigoUUIDPersona = p.CodigoUUID,
                                   Nombre = p.Nombre,
                                   ApellidoPaterno = p.ApellidoPaterno,
                                   ApellidoMaterno = p.ApellidoMaterno,
                                   CorreoElectronico = p.CorreoElectronico
                               };
                return usuarios.ToList();
            }
            
        }
        public async Task<bool> ActualizarRefreshToken(string uuid, DateTime expiracion, string refreshToken) {

            var objUsuario = _db.Usuario.Where(x => x.CodigoUUID.ToString() == uuid).FirstOrDefault();
            objUsuario.refreshToken=refreshToken;
            objUsuario.FechaRefreshTokenExpiracion = expiracion;
            _db.Usuario.Update(objUsuario);
            _db.SaveChanges();
            return true;
        }
        public async Task<List<MarcoListaModel>> GetUsuarioMarcoLista(string uuid)
        {
            var query = from u in _db.Usuario 
                        join um in _db.UsuarioMarcoLista on u.Id equals um.IdUsuario
                        join m in _db.MarcoLista on um.IdMarcoLista equals m.Id
                        join p in _db.Persona on m.IdPersona equals p.Id
                        join c in _db.CondicionJuridica on p.IdCondicionJuridica equals c.Id
                        where (m.Estado == 0 || m.Estado == 1) && (p.Estado == 0 || p.Estado == 1)
                        && u.CodigoUUID==uuid                        
                        select new MarcoListaModel
                        {
                            Id = m.Id,
                            NumeroDocumento = p.NumeroDocumento,
                            NombreCompleto = p.RazonSocial.IsNullOrEmpty() ? (p.Nombre + " " + p.ApellidoPaterno + " " + p.ApellidoMaterno) : p.RazonSocial,
                            CondicionJuridica = c.CondicionJuridica,
                            NombreRepLegal = p.NombreRepLegal,
                            IdDepartamento = m.IdDepartamento,
                            Estado = m.Estado
                        };
            return query.ToList();
        }
        public async Task<byte[]> GetClaveEncriptada(string clave)
        {
            OracleTransaction tr = null; 
            string strCon = _configuracion.GetSection("DatabaseSettings")["ConnectionString1"];
            byte[] claveEncriptada;
            var conn = new OracleConnection(strCon);
            await conn.OpenAsync();
            
            CifradoClave objClave = new CifradoClave();
            try
            {
                objClave.Clave = clave;        
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(conn, null, "PKG_SEGURIDAD.SP_R_ENCRIPTAR", objClave))
                {
                    cmd.ExecuteNonQuery();
                    //claveEncriptada = System.Text.Encoding.UTF32.GetString((byte[])cmd.Parameters["P_TXT_CLAVE_ENCRIPTADA"].Value);
                    claveEncriptada = (byte[])cmd.Parameters["P_TXT_CLAVE_ENCRIPTADA"].Value;
                }            
                conn.Close();
                return claveEncriptada;               

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> GetClaveDesencriptada(string claveEncriptada)
        {
            //return _db.Ubigeo.ToList().FindAll(x => x.Id.ToUpper().Contains(param.ToUpper()) || x.Departamento.ToUpper().Contains(param.ToUpper()) || x.Provincia.ToUpper().Contains(param.ToUpper()) || x.Distrito.ToUpper().Contains(param.ToUpper()));
            string strCon = _configuracion.GetSection("DatabaseSettings")["ConnectionString1"];
            var conn = new OracleConnection(strCon);
            await conn.OpenAsync();
            CifradoClave objClave = new CifradoClave();
            try
            {
                //objClave.ClaveEncriptada = Encoding.UTF32.GetBytes(claveEncriptada);
                objClave.ClaveEncriptada = claveEncriptada;
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(conn, null, "PKG_SEGURIDAD.SP_R_DESENCRIPTAR_CLAVE", objClave))
                {
                    cmd.ExecuteNonQuery();
                    objClave.Clave = (String)cmd.Parameters["P_TXT_CLAVE"].Value;
                }
                conn.Close();
                return objClave.Clave;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> GetClaveUsuario(long idUsuario)
        {
            //return _db.Ubigeo.ToList().FindAll(x => x.Id.ToUpper().Contains(param.ToUpper()) || x.Departamento.ToUpper().Contains(param.ToUpper()) || x.Provincia.ToUpper().Contains(param.ToUpper()) || x.Distrito.ToUpper().Contains(param.ToUpper()));
            string strCon = _configuracion.GetSection("DatabaseSettings")["ConnectionString1"];
            var conn = new OracleConnection(strCon);
            await conn.OpenAsync();
            try
            {
                GetClave param = new GetClave();
                param.IdUsuario = idUsuario;
                string clave = "";
                using (OracleDataReader dr = dBOracle.SelDrdResult(conn, null, "PKG_SEGURIDAD.SP_R_CLAVE_USUARIO", param))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {                
                            while (dr.Read())
                            {                     
                                clave= dr["TXT_CLAVE"].ToString();                       
                            }
                        }
                    }
                }
                conn.Close();
                return clave;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<LoginModel> datosInicioSesion(AuthModel auth)
        {
            //return _db.Ubigeo.ToList().FindAll(x => x.Id.ToUpper().Contains(param.ToUpper()) || x.Departamento.ToUpper().Contains(param.ToUpper()) || x.Provincia.ToUpper().Contains(param.ToUpper()) || x.Distrito.ToUpper().Contains(param.ToUpper()));
            string strCon = _configuracion.GetSection("DatabaseSettings")["ConnectionString1"];
            var conn = new OracleConnection(strCon);
            await conn.OpenAsync();
            try
            {
                LoginModel login = new LoginModel();
                using (OracleDataReader dr = dBOracle.SelDrdResult(conn, null, "PKG_SEGURIDAD.SP_R_INICIAR_SESION", auth))
                {
                    if (dr != null)
                    {
                        login = new LoginModel();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                login.CodigoUUID = dr["TXT_CODIGO_UUID"].ToString();
                                login.Usuario = dr["TXT_USUARIO"].ToString();
                                login.NumeroDocumento = dr["TXT_NUMERO_DOCUMENTO"].ToString();
                                login.Nombre = dr["TXT_NOMBRE"].ToString();            
                                login.ApellidoPaterno = dr["TXT_APELLIDO_PATERNO"].ToString();
                                login.ApellidoMaterno = dr["TXT_APELLIDO_MATERNO"].ToString();
                                login.IdPerfil = long.Parse(dr["IDE_PERFIL"].ToString());
                                login.CodigoPerfil = dr["TXT_CODIGO_PERFIL"].ToString();
                                login.Perfil = dr["TXT_PERFIL"].ToString();
                            }
                        }
                    }
                }
                conn.Close();
                return login;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
