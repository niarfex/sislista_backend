using Application.Common;
using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace Application.Service
{
    public class GestionRegistroService : IGestionRegistroService
    {
        private readonly IGestionRegistroPort _gestionregistroPort;
        private readonly IConfiguration _appConfiguration;
        public GestionRegistroService(IGestionRegistroPort gestionregistroPort
            , IConfiguration appConfiguration)
        {
            _gestionregistroPort = gestionregistroPort ?? throw new ArgumentNullException(nameof(gestionregistroPort));
            _appConfiguration = appConfiguration;
        }
        public async Task<List<GestionRegistroModel>> GetAll(string param, string uuid)
        {
            var gestionregistros = await _gestionregistroPort.GetAll(param, uuid);
            if (gestionregistros == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return gestionregistros;
        }
        public async Task<GestionRegistroModel> GetGestionRegistroxUUID(string uuid)
        {
            var gestionregistro = await _gestionregistroPort.GetGestionRegistroxUUID(uuid);

            if (gestionregistro == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return gestionregistro;
        }
        public async Task<GestionRegistroModel> GetUUIDCuestionario(string numDoc, long idPeriodo)
        {
            var gestionregistro = await _gestionregistroPort.GetUUIDCuestionario(numDoc, idPeriodo);

            if (gestionregistro == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return gestionregistro;
        }
        public async Task<List<ArchivoModel>> GetArchivosCuestionario(string uuid)
        {
            var gestionregistros = await _gestionregistroPort.GetArchivosCuestionario(uuid);
            if (gestionregistros == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return gestionregistros;
        }
        public async Task<List<FundoModel>> GetFundosCuestionario(string uuid)
        {
            var gestionregistros = await _gestionregistroPort.GetFundosCuestionario(uuid);
            if (gestionregistros == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return gestionregistros;
        }
        public async Task<List<InformanteModel>> GetInformantesCuestionario(string uuid)
        {
            var gestionregistros = await _gestionregistroPort.GetInformantesCuestionario(uuid);
            if (gestionregistros == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return gestionregistros;
        }
        public async Task<List<PecuarioModel>> GetPecuariosCuestionario(string uuid)
        {
            var gestionregistros = await _gestionregistroPort.GetPecuariosCuestionario(uuid);
            if (gestionregistros == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return gestionregistros;
        }
        public async Task<List<TrazabilidadModel>> GetObservacionesCuestionario(string uuid)
        {
            var gestionregistros = await _gestionregistroPort.GetObservacionesCuestionario(uuid);
            if (gestionregistros == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return gestionregistros;
        }
        public async Task<string> CreateCuestionario(GestionRegistroModel model)
        {

            var uuid = await _gestionregistroPort.CreateCuestionario(model);
            if (uuid == null)
            {
                throw new NotDataFoundException("No se registraron los datos");

            }
            var estados = await _gestionregistroPort.GetEstadosCuestionario(uuid);
            var empadronador = await _gestionregistroPort.GetDatosPersonaCuestionario(model.NumeroDocumento, (long)model.IdPeriodo, "PERFILEMP");
            var supervisor = await _gestionregistroPort.GetDatosPersonaCuestionario(model.NumeroDocumento, (long)model.IdPeriodo, "PERFILSUP");
            var asunto = "Registro de Cuestionario de Marco de Lista";
            var mensaje = "Estimado Supervisor " + supervisor.Nombre + ", se ha registrado el Cuestionario de la empresa " + model.RazonSocial + " con " +
                "número de documento " + model.NumeroDocumento + " cuyo empadronador es " + empadronador.Nombre + " " + empadronador.ApellidoPaterno + " " + empadronador.ApellidoMaterno + " " +
                "cuyo estado de Registro es: " + estados.NombreEstadoRegistro;

            if (supervisor!=null) {//Se verifica si el profesional esta asignado
                await EnviarCorreoCuestionario(asunto, mensaje, supervisor.CorreoElectronico);
            }

            return uuid;
        }
        public async Task<string> DesaprobarCuestionario(GestionRegistroModel model)
        {
            var uuid = await _gestionregistroPort.DesaprobarCuestionario(model);
            if (uuid == null)
            {
                throw new NotDataFoundException("No se registraron los datos");
            }
            var estados = await _gestionregistroPort.GetEstadosCuestionario(uuid);
            var empadronador = await _gestionregistroPort.GetDatosPersonaCuestionario(estados.NumeroDocumento, (long)estados.IdPeriodo, "PERFILEMP");
            var supervisor = await _gestionregistroPort.GetDatosPersonaCuestionario(estados.NumeroDocumento, (long)estados.IdPeriodo, "PERFILSUP");
            //var especialista = await _gestionregistroPort.GetDatosPersonaCuestionario(estados.NumeroDocumento, (long)estados.IdPeriodo, "PERFILESP");
            var asunto = "Supervisión de Cuestionario de Marco de Lista";
            var mensaje = "Estimado Empadronador " + empadronador.Nombre + ", se ha supervisado el Cuestionario de la empresa " + estados.NombreCompleto + " con " +
                "número de documento " + estados.NumeroDocumento + " cuyo supervisor es " + supervisor.Nombre + " " + supervisor.ApellidoPaterno + " " + supervisor.ApellidoMaterno + " " +
                "cuyo estado de Registro es: " + estados.CodigoEstadoRegistro+ "<br><br>";

            mensaje = mensaje + "Se han registrado las siguientes observaciones:<br><br>";

            mensaje = mensaje + "<table><tr><th>Sección</th><th>Observación</th></tr>";
            foreach (var obs in model.ListObservaciones) {
                mensaje = mensaje + "<tr><td>"+obs.Seccion+"</td><td>"+obs.Observacion+"</td></tr>";
            }
            mensaje = mensaje + "</table>";

            if (empadronador != null)
            {//Se verifica si el profesional esta asignado
                await EnviarCorreoCuestionario(asunto, mensaje, empadronador.CorreoElectronico);
            }

            return uuid;
        }
        public async Task<string> InvalidarCuestionario(GestionRegistroModel model)
        {
            var uuid = await _gestionregistroPort.InvalidarCuestionario(model);
            if (uuid == null)
            {
                throw new NotDataFoundException("No se registraron los datos");
            }
            var estados = await _gestionregistroPort.GetEstadosCuestionario(uuid);
            var empadronador = await _gestionregistroPort.GetDatosPersonaCuestionario(estados.NumeroDocumento, (long)estados.IdPeriodo, "PERFILEMP");
            //var supervisor = await _gestionregistroPort.GetDatosPersonaCuestionario(estados.NumeroDocumento, (long)estados.IdPeriodo, "PERFILSUP");
            var especialista = await _gestionregistroPort.GetDatosPersonaCuestionario(estados.NumeroDocumento, (long)estados.IdPeriodo, "PERFILESP");
            var asunto = "Validación de Cuestionario de Marco de Lista";
            var mensaje = "Estimado Empadronador " + empadronador.Nombre + ", se ha realizado el proceso de validación del Cuestionario de la empresa " + estados.NombreCompleto + " con " +
                "número de documento " + estados.NumeroDocumento + " cuyo especialista es " + especialista.Nombre + " " + especialista.ApellidoPaterno + " " + especialista.ApellidoMaterno + " " +
                "cuyo estado de Registro es: " + estados.CodigoEstadoValidacion + "<br><br>";

            mensaje = mensaje + "Se han registrado las siguientes observaciones:<br><br>";

            mensaje = mensaje + "<table><tr><th>Sección</th><th>Observación</th></tr>";
            foreach (var obs in model.ListObservaciones)
            {
                mensaje = mensaje + "<tr><td>" + obs.Seccion + "</td><td>" + obs.Observacion + "</td></tr>";
            }
            mensaje = mensaje + "</table>";

            if (especialista != null)
            {//Se verifica si el profesional esta asignado
                await EnviarCorreoCuestionario(asunto, mensaje, especialista.CorreoElectronico);
            }

            return uuid;
        }
        public async Task<string> AprobarCuestionarioxUUID(string uuid, DateTime fechaInicio)
        {
            var usuario = await _gestionregistroPort.AprobarCuestionarioxUUID(uuid, fechaInicio);

            if (usuario == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");
            }

            var estados = await _gestionregistroPort.GetEstadosCuestionario(uuid);
            //var empadronador = await _gestionregistroPort.GetDatosPersonaCuestionario(estados.NumeroDocumento, (long)estados.IdPeriodo, "PERFILEMP");
            var supervisor = await _gestionregistroPort.GetDatosPersonaCuestionario(estados.NumeroDocumento, (long)estados.IdPeriodo, "PERFILSUP");
            var especialista = await _gestionregistroPort.GetDatosPersonaCuestionario(estados.NumeroDocumento, (long)estados.IdPeriodo, "PERFILESP");
            var asunto = "Supervisión de Cuestionario de Marco de Lista";
            var mensaje = "Estimado Especialista " + especialista.Nombre + ", se ha supervisado el Cuestionario de la empresa " + estados.NombreCompleto + " con " +
                "número de documento " + estados.NumeroDocumento + " cuyo supervisor es " + supervisor.Nombre + " " + supervisor.ApellidoPaterno + " " + supervisor.ApellidoMaterno + " " +
                "cuyo estado de Supervisión es: " + estados.CodigoEstadoSupervision;

            if (especialista != null)
            {//Se verifica si el empadronador esta asignado
                await EnviarCorreoCuestionario(asunto, mensaje, especialista.CorreoElectronico);
            }

            return usuario;
        }
        public async Task<string> RatificarCuestionarioxUUID(string uuid, DateTime fechaInicio)
        {
            var usuario = await _gestionregistroPort.RatificarCuestionarioxUUID(uuid, fechaInicio);

            if (usuario == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");
            }
            var estados = await _gestionregistroPort.GetEstadosCuestionario(uuid);
            var empadronador = await _gestionregistroPort.GetDatosPersonaCuestionario(estados.NumeroDocumento, (long)estados.IdPeriodo, "PERFILEMP");
            var supervisor = await _gestionregistroPort.GetDatosPersonaCuestionario(estados.NumeroDocumento, (long)estados.IdPeriodo, "PERFILSUP");
            //var especialista = await _gestionregistroPort.GetDatosPersonaCuestionario(estados.NumeroDocumento, (long)estados.IdPeriodo, "PERFILESP");
            var asunto = "Supervisión de Cuestionario de Marco de Lista";
            var mensaje = "Estimado Empadronador " + empadronador.Nombre + ", se ha supervisado el Cuestionario de la empresa " + estados.NombreCompleto + " con " +
                "número de documento " + estados.NumeroDocumento + " cuyo supervisor es " + supervisor.Nombre + " " + supervisor.ApellidoPaterno + " " + supervisor.ApellidoMaterno + " " +
                "cuyo estado de Registro es: " + estados.CodigoEstadoRegistro;

            if (empadronador != null)
            {//Se verifica si el profesional esta asignado
                await EnviarCorreoCuestionario(asunto, mensaje, empadronador.CorreoElectronico);
            }

            return usuario;
        }
        public async Task<string> DerivarCuestionarioxUUID(string uuid, DateTime fechaInicio)
        {
            var usuario = await _gestionregistroPort.DerivarCuestionarioxUUID(uuid, fechaInicio);

            if (usuario == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");
            }
            var estados = await _gestionregistroPort.GetEstadosCuestionario(uuid);
            var empadronador = await _gestionregistroPort.GetDatosPersonaCuestionario(estados.NumeroDocumento, (long)estados.IdPeriodo, "PERFILEMP");
            var supervisor = await _gestionregistroPort.GetDatosPersonaCuestionario(estados.NumeroDocumento, (long)estados.IdPeriodo, "PERFILSUP");
            var especialista = await _gestionregistroPort.GetDatosPersonaCuestionario(estados.NumeroDocumento, (long)estados.IdPeriodo, "PERFILESP");
            var asunto = "Supervisión de Cuestionario de Marco de Lista";
            var mensaje = "Estimado Especialista " + especialista.Nombre + ", se ha supervisado el Cuestionario de la empresa " + estados.NombreCompleto + " con " +
                "número de documento " + estados.NumeroDocumento + " cuyo supervisor es " + supervisor.Nombre + " " + supervisor.ApellidoPaterno + " " + supervisor.ApellidoMaterno + " " +
                "y cuyo empadronador es " + empadronador.Nombre + " " + empadronador.ApellidoPaterno + " " + empadronador.ApellidoMaterno + " " +
                "cuyo estado de Registro es: " + estados.CodigoEstadoRegistro;

            if (especialista != null)
            {//Se verifica si el profesional esta asignado
                await EnviarCorreoCuestionario(asunto, mensaje, especialista.CorreoElectronico);
            }

            return usuario;
        }
        public async Task<string> ValidarCuestionarioxUUID(string uuid, DateTime fechaInicio)
        {
            var usuario = await _gestionregistroPort.ValidarCuestionarioxUUID(uuid, fechaInicio);

            if (usuario == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");
            }

            return usuario;
        }
        public async Task<string> DescartarCuestionarioxUUID(string uuid, DateTime fechaInicio)
        {
            var usuario = await _gestionregistroPort.DescartarCuestionarioxUUID(uuid, fechaInicio);

            if (usuario == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");
            }
            return usuario;
        }
        public async Task<bool> EnviarCorreoCuestionario(string asunto,string mensaje,string correoDestinatario)
        {
            string concopia = "";
            concopia = _appConfiguration[$"configCorreo:concopia"] == "" ? "" : "," + _appConfiguration[$"configCorreo:concopia"];
            try
            {                
                var url = $"{_appConfiguration[$"configCorreo:endpoint"]}";
                var request = (HttpWebRequest)WebRequest.Create(url);
                string json = $"{{\"from\":\"{_appConfiguration[$"configCorreo:remitente"]}\"," +
                    $"\"vto\":\"{correoDestinatario + concopia}\"," +
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
                        if (strReader == null) return false;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = await objReader.ReadToEndAsync();
                        }
                    }
                }
                Utils.registrarLog("Se remitió la notificación de manera exitosa", "SendCredenciales", "SUCCESSFUL");
                return true;
            }
            catch (WebException ex)
            {
                Utils.registrarLog(ex.Message, "SendCredenciales", "ERROR");
                throw ex;
            }
        }
    }
}
