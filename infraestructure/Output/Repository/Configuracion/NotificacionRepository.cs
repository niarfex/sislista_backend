﻿using AutoMapper;
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
    public class NotificacionRepository:INotificacionRepository
    {
        private MarcoListaContexto _db;
        private readonly IConfiguration _configuracion;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public NotificacionRepository(IConfiguration configuracion,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _configuracion = configuracion;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _db = new MarcoListaContexto(_configuracion[$"DatabaseSettings:ConnectionSISLISTA"]);
        }
        public async Task<List<NotificacionEntity>> GetAll(string param)
        {
            return _db.Notificacion.Where(x => x.Estado==0 || x.Estado==1 || x.Estado==2
             && (x.Asunto.ToUpper().Trim().Contains(param.ToUpper().Trim()) || x.Descripcion.ToUpper().Trim().Contains(param.ToUpper().Trim())))
                .OrderByDescending(x=>x.FechaActualizacion.HasValue?x.FechaActualizacion:x.FechaRegistro).ToList();
        }
        public async Task<NotificacionEntity> GetNotificacionxId(long id)
        {
            return _db.Notificacion.Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task<long> CreateNotificacion(NotificacionModel model)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            if (model.Id > 0)
            {
                var objNotificacion = _db.Notificacion.Where(x => x.Id == model.Id).FirstOrDefault();
                objNotificacion.Asunto = model.Asunto;
                objNotificacion.IdFrecuencia = model.IdFrecuencia;
                objNotificacion.IdProgramacionRegistro = model.IdProgramacionRegistro;
                objNotificacion.IdEtapa = model.IdEtapa;
                objNotificacion.Descripcion = model.Descripcion;
                objNotificacion.IdPerfil = model.IdPerfil;
                objNotificacion.FechaActualizacion = DateTime.Now;
                objNotificacion.UsuarioActualizacion = usuario.Usuario;
                _db.Notificacion.Update(objNotificacion);
                _db.SaveChanges();
                return objNotificacion.Id;
            }
            else
            {
                var objNotificacion = new NotificacionEntity()
                {
                    Asunto = model.Asunto,
                    IdFrecuencia = model.IdFrecuencia,
                    IdProgramacionRegistro = model.IdProgramacionRegistro,
                    IdEtapa = model.IdEtapa,
                    Descripcion = model.Descripcion,
                    IdPerfil = model.IdPerfil,
                    EstadoNotificacion = 1,
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = usuario.Usuario
                };
                _db.Notificacion.Add(objNotificacion);
                _db.SaveChanges();
                return objNotificacion.Id;
            }


        }
        public async Task<long> DeleteNotificacionxId(long id)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objNotificacion = _db.Notificacion.Where(x => x.Id == id).FirstOrDefault();
            objNotificacion.Estado = 2;
            objNotificacion.EstadoNotificacion = 3;
            objNotificacion.FechaActualizacion = DateTime.Now;
            objNotificacion.UsuarioActualizacion = usuario.Usuario;
            _db.Notificacion.Update(objNotificacion);
            _db.SaveChanges();
            return objNotificacion.Id;
        }
        public async Task<long> NotificarNotificacionxId(long id)
        {
            var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
            var objNotificacion = _db.Notificacion.Where(x => x.Id == id).FirstOrDefault();      
            objNotificacion.EstadoNotificacion = 2;
            objNotificacion.FechaActualizacion = DateTime.Now;
            objNotificacion.FechaNotificacion= DateTime.Now;
            objNotificacion.UsuarioActualizacion = usuario.Usuario;
            _db.Notificacion.Update(objNotificacion);
            _db.SaveChanges();
            return objNotificacion.Id;
        }

    }
}
