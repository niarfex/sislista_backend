using AutoMapper;
using Dapper;
using Domain.Model;
using Infra.MarcoLista.Contextos;
using Infra.MarcoLista.GeneralSQL;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Infra.MarcoLista.Output.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Reflection.Metadata;
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace Infra.MarcoLista.Output.Repository
{
    public class GestionRegistroRepository: IGestionRegistroRepository
    {
        private MarcoListaContexto _db;
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        private DBOracle dBOracle = new DBOracle();
        public GestionRegistroRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
            _db = new MarcoListaContexto(_configuracion[$"DatabaseSettings:ConnectionString1"]);
        }
        public async Task<List<GestionRegistroModel>> GetAll(string param,string uuid)
        {
            List<GestionRegistroModel> listaCuestionarios = new List<GestionRegistroModel>();
            var queryUsu = from u in _db.Usuario
                           join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                           join p in _db.Perfil on up.IdPerfil equals p.Id
                           where u.CodigoUUID.ToString() == uuid
                           select p;
            var codPerfil = queryUsu.FirstOrDefault().CodigoPerfil;

            if (codPerfil == "PERFILADM") {
                var query = from u in _db.Usuario
                            join um in _db.UsuarioMarcoLista on u.Id equals um.IdUsuario
                            join m in _db.MarcoLista on um.IdMarcoLista equals m.Id
                            join pe in _db.Persona on m.IdPersona equals pe.Id
                            join a in _db.Anio on m.IdAnio equals a.Id
                            join te in _db.TipoExplotacion on m.IdTipoExplotacion equals te.Id
                            from cu in _db.GestionRegistro.Where(x => x.IdMarcoLista == m.Id).DefaultIfEmpty()
                            select new GestionRegistroModel
                            {
                                CodigoUUID = cu.CodigoUUID,
                                IdPeriodo = a.Id,
                                Periodo = a.Anio,
                                NombreCompleto = pe.RazonSocial.IsNullOrEmpty() ? (pe.Nombre + " " + pe.ApellidoPaterno + " " + pe.ApellidoMaterno) : pe.RazonSocial,
                                NumeroDocumento = pe.NumeroDocumento,
                                TipoExplotacion = te.TipoExplotacion,
                                EstadoEntrevista = cu != null ? 0 : 0,
                                EstadoSupervision = cu != null ? 0 : 0,
                                EstadoValidacion = cu != null ? 0 : 0,
                                EstadoRegistro = cu != null ? 0 : 0,
                                Clasificacion = "",
                                UsuarioCreacion = cu != null ? cu.UsuarioCreacion : "",
                            };
                listaCuestionarios = query.ToList();
            }
            else if (codPerfil == "PERFILEMP" || codPerfil == "PERFILSUP" || codPerfil == "PERFILESP") {
                var query = from u in _db.Usuario
                            join um in _db.UsuarioMarcoLista on u.Id equals um.IdUsuario
                            join m in _db.MarcoLista on um.IdMarcoLista equals m.Id
                            join pe in _db.Persona on m.IdPersona equals pe.Id
                            join a in _db.Anio on m.IdAnio equals a.Id
                            join te in _db.TipoExplotacion on m.IdTipoExplotacion equals te.Id
                            from cu in _db.GestionRegistro.Where(x => x.IdMarcoLista == m.Id).DefaultIfEmpty()
                            where u.CodigoUUID.ToString() == uuid
                            select new GestionRegistroModel
                            {
                                CodigoUUID = cu.CodigoUUID,
                                IdPeriodo = a.Id,
                                Periodo = a.Anio,
                                NombreCompleto = pe.RazonSocial == "" ? (pe.Nombre + " " + pe.ApellidoPaterno + " " + pe.ApellidoMaterno) : pe.RazonSocial,
                                NumeroDocumento = pe.NumeroDocumento,
                                TipoExplotacion = te.TipoExplotacion,
                                EstadoEntrevista = cu != null ? 0 : 0,
                                EstadoSupervision = cu != null ? 0 : 0,
                                EstadoValidacion = cu != null ? 0 : 0,
                                EstadoRegistro = cu != null ? 0 : 0,
                                Clasificacion = "",
                                UsuarioCreacion = cu != null ? cu.UsuarioCreacion : "",
                            };
                listaCuestionarios = query.ToList();
            }
            return listaCuestionarios;
        }
        public async Task<GestionRegistroEntity> GetGestionRegistroxUUID(string uuid)
        {

            return _db.GestionRegistro.Where(x => x.CodigoUUID == uuid).FirstOrDefault();
        }
        public async Task<GestionRegistroModel> GetUUIDCuestionario(string numDoc, long idPeriodo)
        {
            var query = from c in _db.GestionRegistro
                        join m in _db.MarcoLista on c.IdMarcoLista equals m.Id
                        join p in _db.Persona on m.IdPersona equals p.Id
                        where c.NumeroDocumento == numDoc && m.IdAnio == idPeriodo
                        select new GestionRegistroModel
                        {
                            Id = c.Id,
                            IdPeriodo = m.IdAnio,
                            CodigoUUID = c.CodigoUUID,
                            IdMarcoLista = m.Id,
                            IdTipoExplotacion = m.IdTipoExplotacion,
                            Estado = m.Estado,
                            IdTipoDocumento = p.IdTipoDocumento,
                            IdCondicionJuridica = p.IdCondicionJuridica,
                            IdUbigeo = p.IdUbigeo,
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
                            TieneRuc = p.TieneRuc,
                            FechaActualizacion=c.FechaActualizacion
                            
                        };

            if (query.FirstOrDefault() == null)
            {
                var queryML = from m in _db.MarcoLista 
                            join p in _db.Persona on m.IdPersona equals p.Id
                            where p.NumeroDocumento == numDoc && m.IdAnio == idPeriodo
                            select new GestionRegistroModel
                            {
                                Id = 0,
                                CodigoUUID = "",
                                IdPeriodo=m.IdAnio,
                                IdMarcoLista = m.Id,
                                IdTipoExplotacion = m.IdTipoExplotacion,
                                Estado = m.Estado,
                                IdTipoDocumento = p.IdTipoDocumento,
                                IdCondicionJuridica = p.IdCondicionJuridica,
                                IdUbigeo = p.IdUbigeo,
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
                                TieneRuc = p.TieneRuc,
                                FechaActualizacion=null
                            };
                return queryML.FirstOrDefault();
            }
            else
            {
                return query.FirstOrDefault();
            }

        }
    }
}
