using Application.Common;
using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace Application.Service
{
    public class NotificacionService : INotificacionService
    {
        private readonly INotificacionPort _notificacionPort;
        private readonly IGeneralPort _generalPort;
        private readonly IUsuarioPort _usuarioPort;
        private readonly IConfiguration _appConfiguration;
        public NotificacionService(INotificacionPort notificacionPort
            , IGeneralPort generalPort    
            , IUsuarioPort usuarioPort
            , IConfiguration appConfiguration)
        {
            _notificacionPort = notificacionPort ?? throw new ArgumentNullException(nameof(notificacionPort));
            _generalPort = generalPort ?? throw new ArgumentNullException(nameof(generalPort));         
            _usuarioPort = usuarioPort ?? throw new ArgumentNullException(nameof(usuarioPort));
            _appConfiguration = appConfiguration;
        }
        public async Task<List<NotificacionModel>> GetAll(string param)
        {
            var notificacions = await _notificacionPort.GetAll(param);
            var frecuencia = await _generalPort.GetFrecuencias();
            var perfiles = await _generalPort.GetPerfilesTodos();
            if (notificacions == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            var query = from o in notificacions
                        join t in frecuencia on o.IdFrecuencia equals t.Id
                        join p in perfiles on o.IdPerfil equals p.Id
                        where o.Estado == 0 || o.Estado == 1 || o.Estado == 2
                        select new NotificacionModel
                        {
                            Id = o.Id,
                            Asunto = o.Asunto,
                            Frecuencia = t.Frecuencia,
                            UsuariosNotificados = p.Perfil,
                            FechaRegistro = o.FechaRegistro,
                            FechaNotificacion = o.FechaNotificacion,
                            EstadoNotificacion = o.EstadoNotificacion
                        };
            return query.ToList();
        }
        public async Task<NotificacionModel> GetNotificacionxId(long id)
        {
            var notificacion = await _notificacionPort.GetNotificacionxId(id);

            if (notificacion == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return notificacion;
        }
        public async Task<long> CreateNotificacion(NotificacionModel model)
        {
            var id = await _notificacionPort.CreateNotificacion(model);
            if (id == null)
            {
                throw new NotDataFoundException("No se registraron los datos");

            }
            return id;
        }
        public async Task<long> DeleteNotificacionxId(long id)
        {
            var notificacion = await _notificacionPort.DeleteNotificacionxId(id);

            if (notificacion == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return notificacion;
        }
        public async Task<long> NotificarNotificacionxId(long id)
        {
            string asunto = "";
            string mensaje = "";
            string concopia = "";
            concopia = _appConfiguration[$"configCorreo:concopia"] == "" ? "" : "," + _appConfiguration[$"configCorreo:concopia"];
            try
            {
                var objNotificacion = await GetNotificacionxId(id);

                var listaPerfiles = await _generalPort.GetPerfilesTodos();
                var listaFrecuencias = await _generalPort.GetFrecuencias();
                var listaRegistros = await _generalPort.GetProgramacionesVigentes();
                var listaEtapas = await _generalPort.GetEtapas();
                var codPerfil = listaPerfiles.Find(x => x.Id == objNotificacion.IdPerfil).CodigoPerfil;
                var nomFrecuencia = listaFrecuencias.Find(x => x.Id == objNotificacion.IdFrecuencia).Frecuencia;
                var nomRegistro = listaRegistros.Find(x => x.Id == objNotificacion.IdProgramacionRegistro).ProgramacionRegistro;
                var nomEtapa = listaEtapas.Find(x => x.Id == objNotificacion.IdEtapa).Etapa;

                long idPerfil = 0;
                if (codPerfil != "PERFILTODOS") { idPerfil = (long)objNotificacion.IdPerfil; }

                var usuariosDestinatarios = await _usuarioPort.GetCorreosUsuariosxPerfil(idPerfil);
                string correosDest = "";
                foreach (var correo in usuariosDestinatarios)
                {
                    correosDest = correosDest == "" ? correo.CorreoElectronico : correosDest + "," + correo.CorreoElectronico;
                }

                asunto = objNotificacion.Asunto;
                mensaje = $"Estimados(as) usuarios, se ha registrado la programación con los siguientes datos:" + "<br><br>" +
                    $"Frecuencia: " + nomFrecuencia + "<br>" +
                    $"Registro: " + nomRegistro + "<br>" +
                    $"Etapa: " + nomEtapa + "<br>" +
                    $"Descripción: " + objNotificacion.Descripcion + "<br><br>";


                var url = $"{_appConfiguration[$"configCorreo:endpoint"]}";
                var request = (HttpWebRequest)WebRequest.Create(url);
                string json = $"{{\"from\":\"{_appConfiguration[$"configCorreo:remitente"]}\"," +
                    $"\"vto\":\"{correosDest + concopia}\"," +
                    $"\"vasunto\":\"{asunto}\"," +
                    $"\"vmensaje\":\"{mensaje}\"}}";

                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return 0;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = await objReader.ReadToEndAsync();
                        }
                    }
                }
                var notificacion = await _notificacionPort.NotificarNotificacionxId(id);

                if (notificacion == null)
                {
                    throw new NotDataFoundException("No se encontraron datos registrados");

                }
                return notificacion;
            }
            catch (WebException ex)
            {
                Utils.registrarLog(ex.Message, "NotificarNotificacionxId", "ERROR");
                throw ex;
            }
        }
    }
}
