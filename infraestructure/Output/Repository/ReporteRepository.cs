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
    public class ReporteRepository : IReporteRepository
    {
        private MarcoListaContexto _db;
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        public ReporteRepository(IConfiguration configuracion,
            IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
            _db = new MarcoListaContexto(_configuracion[$"DatabaseSettings:ConnectionSISLISTA"]);
        }
        public async Task<ReporteModel> GetAll(string valCodigo)
        {
            ReporteModel reporte = new ReporteModel();

            if (valCodigo == "PERFILADM")
            {
                reporte.CantEmpadronadores = (from u in _db.Usuario
                                              join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                                              join p in _db.Perfil on up.IdPerfil equals p.Id
                                              where p.CodigoPerfil == "PERFILEMP" &&
                                              p.Estado == 1 && up.Estado == 1 && u.Estado == 1
                                              select u).Count();
                reporte.CantSupervisores = (from u in _db.Usuario
                                            join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                                            join p in _db.Perfil on up.IdPerfil equals p.Id
                                            where p.CodigoPerfil == "PERFILSUP" &&
                                            p.Estado == 1 && up.Estado == 1 && u.Estado == 1
                                            select u).Count();
                reporte.CantEspecialistas = (from u in _db.Usuario
                                             join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                                             join p in _db.Perfil on up.IdPerfil equals p.Id
                                             where p.CodigoPerfil == "PERFILESP" &&
                                             p.Estado == 1 && up.Estado == 1 && u.Estado == 1
                                             select u).Count();

                reporte.CantCompletados = (from m in _db.MarcoLista
                                           from cu in _db.GestionRegistro.Where(x => x.IdMarcoLista == m.Id).DefaultIfEmpty()
                                           from e in _db.Estado.Where(x => x.Id == cu.EstadoRegistro).DefaultIfEmpty()
                                           where m.Estado == 1 && e.CodigoEstado == "CERRADO"
                                           select m).Count();
                reporte.CantEnProgreso = (from m in _db.MarcoLista
                                          from cu in _db.GestionRegistro.Where(x => x.IdMarcoLista == m.Id).DefaultIfEmpty()
                                          from e in _db.Estado.Where(x => x.Id == cu.EstadoRegistro).DefaultIfEmpty()
                                          where m.Estado == 1 && cu != null
                                          select m).Count();
                reporte.CantNoIniciado = (from m in _db.MarcoLista
                                          from cu in _db.GestionRegistro.Where(x => x.IdMarcoLista == m.Id).DefaultIfEmpty()
                                          from e in _db.Estado.Where(x => x.Id == cu.EstadoRegistro).DefaultIfEmpty()
                                          where m.Estado == 1 && cu == null
                                          select m).Count();

            }
            else if (valCodigo == "PERFILEMP")
            {
                reporte.CantParaRevisar = (from c in _db.GestionRegistro
                                           join e in _db.Estado on c.EstadoRegistro equals e.Id
                                           where c.Estado == 1 && e.CodigoEstado == "PARAREVISAR"
                                           select c).Count();
                reporte.CantTrabajoGabinete = (from c in _db.GestionRegistro
                                               join e in _db.Estado on c.EstadoRegistro equals e.Id
                                               where c.Estado == 1 && e.CodigoEstado == "TRABAJOGABINETE"
                                               select c).Count();
                reporte.CantEnAlerta = (from c in _db.GestionRegistro
                                        join e in _db.Estado on c.EstadoRegistro equals e.Id
                                        where c.Estado == 1 && e.CodigoEstado == "ENALERTA"
                                        select c).Count();


            }
            else if (valCodigo == "PERFILSUP")
            {
                reporte.CantParaValidar = (from c in _db.GestionRegistro
                                           join e in _db.Estado on c.EstadoRegistro equals e.Id
                                           where c.Estado == 1 && e.CodigoEstado == "PARAVALIDAR"
                                           select c).Count();
                reporte.CantObservadoSupervisor = (from c in _db.GestionRegistro
                                                   join e in _db.Estado on c.EstadoRegistro equals e.Id
                                                   where c.Estado == 1 && e.CodigoEstado == "OBSERVADOSUPERVISOR"
                                                   select c).Count();
                reporte.CantParaRegistrar = (from c in _db.GestionRegistro
                                             join e in _db.Estado on c.EstadoRegistro equals e.Id
                                             where c.Estado == 1 && e.CodigoEstado == "PARAREGISTRAR2"
                                             select c).Count();
                reporte.CantArbitraje = (from c in _db.GestionRegistro
                                         join e in _db.Estado on c.EstadoRegistro equals e.Id
                                         where c.Estado == 1 && e.CodigoEstado == "ARBITRAJE"
                                         select c).Count();


            }
            else if (valCodigo == "PERFILESP")
            {
                reporte.CantCerrado = (from c in _db.GestionRegistro
                                       join e in _db.Estado on c.EstadoRegistro equals e.Id
                                       where c.Estado == 1 && e.CodigoEstado == "CERRADO"
                                       select c).Count();
                reporte.CantObservadoEspecialista = (from c in _db.GestionRegistro
                                                     join e in _db.Estado on c.EstadoRegistro equals e.Id
                                                     where c.Estado == 1 && e.CodigoEstado == "OBSERVADOESPECIALISTA"
                                                     select c).Count();
                reporte.CantReemplazado = (from c in _db.GestionRegistro
                                           join e in _db.Estado on c.EstadoRegistro equals e.Id
                                           where c.Estado == 1 && e.CodigoEstado == "REEMPLAZADO"
                                           select c).Count();
                reporte.CantEliminado = (from c in _db.GestionRegistro
                                         join e in _db.Estado on c.EstadoRegistro equals e.Id
                                         where c.Estado == 1 && e.CodigoEstado == "ELIMINADO"
                                         select c).Count();



            }

            return reporte;

        }
        public async Task<List<ReporteModel>> GetReporteUsuarioList(string valCodigo)
        {
            List<ReporteModel> retorno = new List<ReporteModel>();
            if (valCodigo == "PERFILADM")
            {
                retorno = (from u in _db.Usuario
                           join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                           join p in _db.Perfil on up.IdPerfil equals p.Id
                           join pe in _db.Persona on u.IdPersona equals pe.Id
                           join um in _db.UsuarioMarcoLista on u.Id equals um.IdUsuario
                           join m in _db.MarcoLista on um.IdMarcoLista equals m.Id
                           where u.Estado == 1 && up.Estado == 1 && p.Estado == 1 && um.Estado == 1 && m.Estado == 1
                           select new ReporteModel
                           {
                               Usuario = pe.Nombre + " " + pe.ApellidoPaterno + " " + pe.ApellidoMaterno,
                               Avance = 0,
                               Cambio = 0,
                               CantMarcoLista = 0,
                               Perfil = p.Perfil,
                               RegCerrados = 0
                           })
                             .AsEnumerable()
                            .GroupBy(x => new { x.Usuario,x.Perfil })
                            .Select(x => new ReporteModel
                            {
                                Usuario = x.Key.Usuario,
                                Avance = 0,
                                Cambio = 0,
                                Perfil=x.Key.Perfil,
                                CantMarcoLista = x.Count(),
                                RegCerrados = 0
                            })
                                               .ToList();
            }
            else if (valCodigo == "PERFILEMP")
            {
                retorno = (from u in _db.Usuario
                           join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                           join p in _db.Perfil on up.IdPerfil equals p.Id
                           join pe in _db.Persona on u.IdPersona equals pe.Id
                           where u.Estado == 1 && up.Estado == 1 && p.Estado == 1
                           && p.CodigoPerfil == "PERFILEMP"
                           select new ReporteModel
                           {
                               Usuario = pe.Nombre + " " + pe.ApellidoPaterno + " " + pe.ApellidoMaterno,
                               Avance = 0,
                               Cambio = 0,
                               CantMarcoLista = 0,
                               Perfil = p.Perfil,
                               RegCerrados = 0
                           }).ToList();
            }
            else if (valCodigo == "PERFILSUP")
            {
                retorno = (from u in _db.Usuario
                           join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                           join p in _db.Perfil on up.IdPerfil equals p.Id
                           join pe in _db.Persona on u.IdPersona equals pe.Id
                           where u.Estado == 1 && up.Estado == 1 && p.Estado == 1
                           && p.CodigoPerfil == "PERFILSUP"
                           select new ReporteModel
                           {
                               Usuario = pe.Nombre + " " + pe.ApellidoPaterno + " " + pe.ApellidoMaterno,
                               Avance = 0,
                               Cambio = 0,
                               CantMarcoLista = 0,
                               Perfil = p.Perfil,
                               RegCerrados = 0
                           }).ToList();
            }
            else if (valCodigo == "PERFILESP")
            {
                retorno = (from u in _db.Usuario
                           join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                           join p in _db.Perfil on up.IdPerfil equals p.Id
                           join pe in _db.Persona on u.IdPersona equals pe.Id
                           where u.Estado == 1 && up.Estado == 1 && p.Estado == 1
                           && p.CodigoPerfil == "PERFILESP"
                           select new ReporteModel
                           {
                               Usuario = pe.Nombre + " " + pe.ApellidoPaterno + " " + pe.ApellidoMaterno,
                               Avance = 0,
                               Cambio = 0,
                               CantMarcoLista = 0,
                               Perfil = p.Perfil,
                               RegCerrados = 0
                           }).ToList();
            }
            return retorno;
        }
        public async Task<List<ReporteModel>> GetFlujoValidacionList(string valCodigo)
        {
            List<ReporteModel> retorno = new List<ReporteModel>();
            if (valCodigo == "PERFILADM")
            {
                retorno = (from c in _db.GestionRegistro
                           where c.Estado == 1
                           select new ReporteModel
                           {
                               Empresa = c.RazonSocial.IsNullOrEmpty() ? (c.Nombre + " " + c.ApellidoPaterno + " " + c.ApellidoMaterno) : c.RazonSocial,
                               Tiempo = "0 días",
                               NumTiempo = 0
                           }).ToList();
            }
            return retorno;
        }
        public async Task<List<ReporteModel>> GetRankingRegCerradosList(string valCodigo)
        {
            List<ReporteModel> retorno = new List<ReporteModel>();
            if (valCodigo == "PERFILEMP")
            {
                retorno = (from c in _db.GestionRegistro
                           join e in _db.Estado on c.EstadoRegistro equals e.Id
                           join m in _db.MarcoLista on c.IdMarcoLista equals m.Id
                           join um in _db.UsuarioMarcoLista on m.Id equals um.IdMarcoLista
                           join u in _db.Usuario on um.IdUsuario equals u.Id
                           join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                           join p in _db.Perfil on up.IdPerfil equals p.Id
                           join pe in _db.Persona on u.IdPersona equals pe.Id
                           where c.Estado == 1 && e.CodigoEstado == "CERRADO" && p.CodigoPerfil == "PERFILEMP"
                           && um.Estado == 1 && m.Estado == 1 && u.Estado == 1 && up.Estado == 1 && p.Estado == 1
                           select new ReporteModel
                           {
                               Usuario = pe.Nombre + " " + pe.ApellidoPaterno + " " + pe.ApellidoMaterno,
                               CantMarcoLista = 0,
                               Tiempo = "0 días",
                               NumTiempo = 0
                           }).ToList();
            }
            else if (valCodigo == "PERFILSUP")
            {
                retorno = (from c in _db.GestionRegistro
                           join e in _db.Estado on c.EstadoRegistro equals e.Id
                           join m in _db.MarcoLista on c.IdMarcoLista equals m.Id
                           join um in _db.UsuarioMarcoLista on m.Id equals um.IdMarcoLista
                           join u in _db.Usuario on um.IdUsuario equals u.Id
                           join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                           join p in _db.Perfil on up.IdPerfil equals p.Id
                           join pe in _db.Persona on u.IdPersona equals pe.Id
                           where c.Estado == 1 && e.CodigoEstado == "CERRADO" && p.CodigoPerfil == "PERFILSUP"
                           && um.Estado == 1 && m.Estado == 1 && u.Estado == 1 && up.Estado == 1 && p.Estado == 1
                           select new ReporteModel
                           {
                               Usuario = pe.Nombre + " " + pe.ApellidoPaterno + " " + pe.ApellidoMaterno,
                               CantMarcoLista = 0,
                               Tiempo = "0 días",
                               NumTiempo = 0
                           }).ToList();
            }
            else if (valCodigo == "PERFILESP")
            {
                retorno = (from c in _db.GestionRegistro
                           join e in _db.Estado on c.EstadoRegistro equals e.Id
                           join m in _db.MarcoLista on c.IdMarcoLista equals m.Id
                           join um in _db.UsuarioMarcoLista on m.Id equals um.IdMarcoLista
                           join u in _db.Usuario on um.IdUsuario equals u.Id
                           join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                           join p in _db.Perfil on up.IdPerfil equals p.Id
                           join pe in _db.Persona on u.IdPersona equals pe.Id
                           where c.Estado == 1 && e.CodigoEstado == "CERRADO" && p.CodigoPerfil == "PERFILESP"
                           && um.Estado == 1 && m.Estado == 1 && u.Estado == 1 && up.Estado == 1 && p.Estado == 1
                           select new ReporteModel
                           {
                               Usuario = pe.Nombre + " " + pe.ApellidoPaterno + " " + pe.ApellidoMaterno,
                               CantMarcoLista = 0,
                               Tiempo = "0 días",
                               NumTiempo = 0
                           }).ToList();
            }
            return retorno;
        }
        public async Task<List<ReporteModel>> GetMejorTiempoList(string valCodigo)
        {
            List<ReporteModel> retorno = new List<ReporteModel>();
            if (valCodigo == "PERFILEMP")
            {
                retorno = (from c in _db.GestionRegistro
                           join e in _db.Estado on c.EstadoRegistro equals e.Id
                           join m in _db.MarcoLista on c.IdMarcoLista equals m.Id
                           join um in _db.UsuarioMarcoLista on m.Id equals um.IdMarcoLista
                           join u in _db.Usuario on um.IdUsuario equals u.Id
                           join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                           join p in _db.Perfil on up.IdPerfil equals p.Id
                           join pe in _db.Persona on u.IdPersona equals pe.Id
                           where c.Estado == 1
                           && (e.CodigoEstado == "PARAREVISAR" || e.CodigoEstado == "OBSERVADOSUPERVISOR"
                           || e.CodigoEstado == "PARAVALIDAR")
                           && p.CodigoPerfil == "PERFILEMP"
                           && um.Estado == 1 && m.Estado == 1 && u.Estado == 1 && up.Estado == 1 && p.Estado == 1
                           select new ReporteModel
                           {
                               Empresa = c.RazonSocial.IsNullOrEmpty() ? (c.Nombre + " " + c.ApellidoPaterno + " " + c.ApellidoMaterno) : c.RazonSocial,
                               Usuario = pe.Nombre + " " + pe.ApellidoPaterno + " " + pe.ApellidoMaterno,
                               Tiempo = "0 días",
                               NumTiempo = 0
                           }).ToList();
            }
            else if (valCodigo == "PERFILSUP")
            {
                retorno = (from c in _db.GestionRegistro
                           join e in _db.Estado on c.EstadoRegistro equals e.Id
                           join m in _db.MarcoLista on c.IdMarcoLista equals m.Id
                           join um in _db.UsuarioMarcoLista on m.Id equals um.IdMarcoLista
                           join u in _db.Usuario on um.IdUsuario equals u.Id
                           join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                           join p in _db.Perfil on up.IdPerfil equals p.Id
                           join pe in _db.Persona on u.IdPersona equals pe.Id
                           where c.Estado == 1
                           && (e.CodigoEstado == "PARAREVISAR" || e.CodigoEstado == "OBSERVADOSUPERVISOR"
                           || e.CodigoEstado == "PARAVALIDAR")
                           && p.CodigoPerfil == "PERFILSUP"
                           && um.Estado == 1 && m.Estado == 1 && u.Estado == 1 && up.Estado == 1 && p.Estado == 1
                           select new ReporteModel
                           {
                               Empresa = c.RazonSocial.IsNullOrEmpty() ? (c.Nombre + " " + c.ApellidoPaterno + " " + c.ApellidoMaterno) : c.RazonSocial,
                               Usuario = pe.Nombre + " " + pe.ApellidoPaterno + " " + pe.ApellidoMaterno,
                               Tiempo = "0 días",
                               NumTiempo = 0
                           }).ToList();
            }
            else if (valCodigo == "PERFILESP")
            {
                retorno = (from c in _db.GestionRegistro
                           join e in _db.Estado on c.EstadoRegistro equals e.Id
                           join m in _db.MarcoLista on c.IdMarcoLista equals m.Id
                           join um in _db.UsuarioMarcoLista on m.Id equals um.IdMarcoLista
                           join u in _db.Usuario on um.IdUsuario equals u.Id
                           join up in _db.UsuarioPerfil on u.Id equals up.IdUsuario
                           join p in _db.Perfil on up.IdPerfil equals p.Id
                           join pe in _db.Persona on u.IdPersona equals pe.Id
                           where c.Estado == 1
                           && (e.CodigoEstado == "PARAREVISAR" || e.CodigoEstado == "OBSERVADOSUPERVISOR"
                           || e.CodigoEstado == "PARAVALIDAR")
                           && p.CodigoPerfil == "PERFILESP"
                           && um.Estado == 1 && m.Estado == 1 && u.Estado == 1 && up.Estado == 1 && p.Estado == 1
                           select new ReporteModel
                           {
                               Empresa = c.RazonSocial.IsNullOrEmpty() ? (c.Nombre + " " + c.ApellidoPaterno + " " + c.ApellidoMaterno) : c.RazonSocial,
                               Usuario = pe.Nombre + " " + pe.ApellidoPaterno + " " + pe.ApellidoMaterno,
                               Tiempo = "0 días",
                               NumTiempo = 0
                           }).ToList();
            }
            return retorno;
        }
    }
}
