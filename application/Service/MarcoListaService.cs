using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace Application.Service
{
    public class MarcoListaService : IMarcoListaService
    {
        private readonly IMarcoListaPort _marcolistaPort;
        private readonly ICondicionJuridicaPort _condicionjuridicaPort;
        private readonly IUsuarioPort _usuarioPort;
        private readonly IGeneralPort _generalPort;
        private readonly IConfiguration _appConfiguration;
        public MarcoListaService(IMarcoListaPort marcolistaPort
            , ICondicionJuridicaPort condicionjuridicaPort
            , IUsuarioPort usuarioPort
            , IGeneralPort generalPort
            , IConfiguration appConfiguration)
        {
            _marcolistaPort = marcolistaPort ?? throw new ArgumentNullException(nameof(marcolistaPort));
            _condicionjuridicaPort = condicionjuridicaPort ?? throw new ArgumentNullException(nameof(condicionjuridicaPort));
            _usuarioPort = usuarioPort ?? throw new ArgumentNullException(nameof(usuarioPort));
            _generalPort = generalPort ?? throw new ArgumentNullException(nameof(generalPort));
            _appConfiguration = appConfiguration;
        }
        public async Task<List<MarcoListaModel>> GetAll(string param)
        {
            var marcolistas = await _marcolistaPort.GetAll(param);
            var departamentos = await _generalPort.GetDepartamentos(1,"");
            if (marcolistas == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            var query = from m in marcolistas
                        from d in departamentos.Where(x => x.Id == m.IdDepartamento).DefaultIfEmpty()
                        select new MarcoListaModel
                        {
                            Id = m.Id,
                            NumeroDocumento = m.NumeroDocumento,
                            NombreCompleto = m.NombreCompleto,
                            CondicionJuridica = m.CondicionJuridica,
                            NombreRepLegal = m.NombreRepLegal,
                            IdDepartamento = d != null ? m.IdDepartamento : null,                            
                            Departamento = d != null ? d.Departamento: null,
                            Estado = m.Estado,
                            IdAnio=m.IdAnio,
                            IdUbigeo=m.IdUbigeo
                        };

            return query.ToList();
        }
        public async Task<List<MarcoListaModel>> GetMarcoListasinAginarxPerfil(long idPerfil)
        {
            var marcolistas = await _marcolistaPort.GetMarcoListasinAginarxPerfil(idPerfil);
            var departamentos = await _generalPort.GetDepartamentos(1, "");
            if (marcolistas == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            var query = from m in marcolistas
                        from d in departamentos.Where(x => x.Id == m.IdDepartamento).DefaultIfEmpty()
                        orderby m.NombreCompleto
                        select new MarcoListaModel
                        {
                            Id = m.Id,
                            NumeroDocumento = m.NumeroDocumento,
                            NombreCompleto = m.NombreCompleto,
                            CondicionJuridica = m.CondicionJuridica,
                            NombreRepLegal = m.NombreRepLegal,
                            IdDepartamento = d != null ? m.IdDepartamento : null,
                            Departamento = d != null ? d.Departamento : null,
                            Estado = m.Estado,
                            IdAnio = m.IdAnio,
                            IdUbigeo = m.IdUbigeo
                        };

            return query.ToList();
        }
        public async Task<MarcoListaModel> GetMarcoListaxId(long id)
        {
            var marcolista = await _marcolistaPort.GetMarcoListaxId(id);           

            if (marcolista == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return marcolista;
        }
        public async Task<long> CreateMarcoLista(MarcoListaModel model)
        {
            var id = await _marcolistaPort.CreateMarcoLista(model);
            if (id == null)
            {
                throw new NotDataFoundException("No se registraron los datos");

            }
            return id;
        }
        public async Task<long> DeleteMarcoListaxId(long id)
        {
            var marcolista = await _marcolistaPort.DeleteMarcoListaxId(id);

            if (marcolista == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return marcolista;
        }
        public async Task<long> ActivarMarcoListaxId(long id)
        {
            var marcolista = await _marcolistaPort.ActivarMarcoListaxId(id);

            if (marcolista == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            /****** Envio de correo ******/
            var concopia = _appConfiguration[$"configCorreo:concopia"] == "" ? "" : "," + _appConfiguration[$"configCorreo:concopia"];

            var usuariosDestinatarios = await _usuarioPort.GetCorreosUsuariosxMarcoLista(id);
            string correosDest = "";
            foreach (var correo in usuariosDestinatarios)
            {
                correosDest = correosDest == "" ? correo.CorreoElectronico : correosDest + "," + correo.CorreoElectronico;
            }
            var asunto = "Deshabilitación de usuario";
            var mensaje = $"Estimados(as) usuarios, se le notifica que el elemento de Marco de Lista asociado a su usuario ha sido habilitado, " +
                $"en caso requiera asistencia por favor contactarse con el administrador del sistema" + "<br><br>";
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
            /****** Envio de correo ******/
            return marcolista;
        }
        public async Task<long> DesactivarMarcoListaxId(long id)
        {
            var marcolista = await _marcolistaPort.DesactivarMarcoListaxId(id);

            if (marcolista == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            /****** Envio de correo ******/
            var concopia = _appConfiguration[$"configCorreo:concopia"] == "" ? "" : "," + _appConfiguration[$"configCorreo:concopia"];

            var usuariosDestinatarios = await _usuarioPort.GetCorreosUsuariosxMarcoLista(id);
            string correosDest = "";
            foreach (var correo in usuariosDestinatarios)
            {
                correosDest = correosDest == "" ? correo.CorreoElectronico : correosDest + "," + correo.CorreoElectronico;
            }
            var asunto = "Deshabilitación de usuario";
            var mensaje = $"Estimados(as) usuarios, se le notifica que el elemento de Marco de Lista asociado a su usuario ha sido deshabilitado, " +
                $"en caso requiera asistencia por favor contactarse con el administrador del sistema" + "<br><br>";
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
            /****** Envio de correo ******/
            return marcolista;
        }
    }
}
