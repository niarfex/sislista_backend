using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace Application.Service
{
    public class GeneralService : IGeneralService
    {
        private readonly IGeneralPort _generalPort;
        private readonly ICondicionJuridicaPort _condicionjuridicaPort;
        private readonly ITipoExplotacionPort _tipoexplotacionPort;
        private readonly IOrganizacionPort _organizacionPort;
        private readonly IMarcoListaPort _marcolistaPort;
        private readonly IConfiguration _appConfiguration;

        public GeneralService(IGeneralPort generalPort,
            ICondicionJuridicaPort condicionjuridicaPort,
            ITipoExplotacionPort tipoexplotacionPort,
            IOrganizacionPort organizacionPort,
            IMarcoListaPort marcolistaPort,
            IConfiguration appConfiguration)
        {
            _generalPort = generalPort ?? throw new ArgumentNullException(nameof(generalPort));
            _condicionjuridicaPort = condicionjuridicaPort ?? throw new ArgumentNullException(nameof(condicionjuridicaPort));
            _tipoexplotacionPort = tipoexplotacionPort ?? throw new ArgumentNullException(nameof(tipoexplotacionPort));
            _organizacionPort = organizacionPort ?? throw new ArgumentNullException(nameof(organizacionPort));
            _marcolistaPort = marcolistaPort ?? throw new ArgumentNullException(nameof(marcolistaPort));
            _appConfiguration = appConfiguration;
        }
        public async Task<List<UbigeoModel>> GetAllUbigeo(string param)
        {            
            var ubigeos = await _generalPort.GetAllUbigeo(4, param);
            if (ubigeos == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return ubigeos;
        }
        public async Task<List<SelectTipoModel>> GetDepartamentos()
        {
            List<SelectTipoModel> listaUbigeos = new List<SelectTipoModel>();
            var ubigeos = await _generalPort.GetDepartamentos(1, "");
            if (ubigeos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaUbigeos.Add(new SelectTipoModel("-- Seleccionar --", null, ""));
            foreach (var dep in ubigeos)
            {
                list = new SelectTipoModel();
                list.value = dep.Id;
                list.label = dep.Departamento;
                list.codigo = dep.Id;
                listaUbigeos.Add(list);
            }
            return listaUbigeos;
        }
        public async Task<List<SelectTipoModel>> GetDepartamentosMarcoLista()
        {
            List<SelectTipoModel> listaUbigeos = new List<SelectTipoModel>();
            var ubigeos = await _generalPort.GetDepartamentos(1,"");
            var marcolista = await _marcolistaPort.GetAll("");

            var query = from u in ubigeos
                        join m in marcolista on u.Id equals m.IdDepartamento
                        where m.Estado==1 || m.Estado==0
                        select new UbigeoModel
                        {
                            Id=u.Id,
                            Departamento=u.Departamento
                        };

            if (ubigeos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaUbigeos.Add(new SelectTipoModel("-- Seleccionar --", null, ""));
            foreach (var dep in query.ToList())
            {
                list = new SelectTipoModel();
                list.value = dep.Id;
                list.label = dep.Departamento;
                list.codigo = dep.Id;
                listaUbigeos.Add(list);
            }
            return listaUbigeos;
        }
        public async Task<List<SelectTipoModel>> GetProvincias(string idUbigeo)
        {
            List<SelectTipoModel> listaUbigeos = new List<SelectTipoModel>();
            var ubigeos = await _generalPort.GetProvincias(2, idUbigeo);
            if (ubigeos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaUbigeos.Add(new SelectTipoModel("-- Seleccionar --", null, ""));
            foreach (var dep in ubigeos)
            {
                list = new SelectTipoModel();
                list.value = dep.Id;
                list.label = dep.Provincia;
                list.codigo = dep.Id;
                listaUbigeos.Add(list);
            }
            return listaUbigeos;
        }
        public async Task<List<SelectTipoModel>> GetDistritos(string idUbigeo)
        {
            List<SelectTipoModel> listaUbigeos = new List<SelectTipoModel>();
            var ubigeos = await _generalPort.GetDistritos(3, idUbigeo);
            if (ubigeos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaUbigeos.Add(new SelectTipoModel("-- Seleccionar --", null, ""));
            foreach (var dep in ubigeos)
            {
                list = new SelectTipoModel();
                list.value = dep.Id;
                list.label = dep.Distrito;
                list.codigo = dep.Id;
                listaUbigeos.Add(list);
            }
            return listaUbigeos;
        }

        public async Task<List<SelectTipoModel>> GetTipoOrganizacion()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetTipoOrganizacion();
            if (tipos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaTipos.Add(new SelectTipoModel("-- Seleccionar --", null,""));
            foreach (var dep in tipos)
            {
                list = new SelectTipoModel();
                list.value = dep.Id.ToString();
                list.label = dep.TipOrganizacion;
                list.codigo = dep.CodigoTipoOrganizacion;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetCondicionJuridicas()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = (await _condicionjuridicaPort.GetAll("")).Where(x => x.Otros == 0);
            if (tipos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaTipos.Add(new SelectTipoModel("-- Seleccionar --", null,""));
            foreach (var dep in tipos)
            {
                list = new SelectTipoModel();
                list.value = dep.Id.ToString();
                list.label = dep.CondicionJuridica;
                list.codigo = dep.CodigoCondicionJuridica;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetCondicionJuridicaOtros()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = (await _condicionjuridicaPort.GetAll("")).Where(x => x.Otros == 1);
            if (tipos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaTipos.Add(new SelectTipoModel("-- Seleccionar --", null,""));
            foreach (var dep in tipos)
            {
                list = new SelectTipoModel();
                list.value = dep.Id.ToString();
                list.label = dep.CondicionJuridica;
                list.codigo = dep.CodigoCondicionJuridica;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetTipoExplotacion()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _tipoexplotacionPort.GetAll("");
            if (tipos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaTipos.Add(new SelectTipoModel("-- Seleccionar --", null,""));
            foreach (var dep in tipos)
            {
                list = new SelectTipoModel();
                list.value = dep.Id.ToString();
                list.label = dep.TipoExplotacion;
                list.codigo = dep.CodigoTipoExplotacion;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetTipoDocumento()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetTipoDocumento();
            if (tipos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaTipos.Add(new SelectTipoModel("-- Seleccionar --", null,""));
            foreach (var dep in tipos)
            {
                list = new SelectTipoModel();
                list.value = dep.Id.ToString();
                list.label = dep.TipoDocumento;
                list.codigo = dep.TipoDocumento;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetTipoDocumentoPN()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetTipoDocumento();
            if (tipos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaTipos.Add(new SelectTipoModel("-- Seleccionar --", null,""));
            foreach (var dep in tipos.Where(x => x.TipoDocumento != "RUC"))
            {
                list = new SelectTipoModel();
                list.value = dep.Id.ToString();
                list.label = dep.TipoDocumento;
                list.codigo = dep.TipoDocumento;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetOrganizaciones()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _organizacionPort.GetAll("");
            if (tipos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaTipos.Add(new SelectTipoModel("-- Seleccionar --", null,""));
            foreach (var dep in tipos)
            {
                list = new SelectTipoModel();
                list.value = dep.Id.ToString();
                list.label = dep.Organizacion;
                list.codigo = "";
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetPerfiles()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetPerfiles();
            if (tipos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaTipos.Add(new SelectTipoModel("-- Seleccionar --", null,""));
            foreach (var dep in tipos)
            {
                list = new SelectTipoModel();
                list.value = dep.Id.ToString();
                list.label = dep.Perfil;
                list.codigo = dep.CodigoPerfil;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetPerfilesTodos()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetPerfilesTodos();
            if (tipos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaTipos.Add(new SelectTipoModel("-- Seleccionar --", null,""));
            foreach (var dep in tipos)
            {
                list = new SelectTipoModel();
                list.value = dep.Id.ToString();
                list.label = dep.Perfil;
                list.codigo = dep.CodigoPerfil;
                listaTipos.Add(list);
            }
            return listaTipos;
        }

        public async Task<List<SelectTipoModel>> GetPeriodos()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetPeriodos();
            if (tipos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaTipos.Add(new SelectTipoModel("-- Seleccionar --", null,""));
            foreach (var dep in tipos)
            {
                list = new SelectTipoModel();
                list.value = dep.Id.ToString();
                list.label = dep.Anio;
                list.codigo = dep.Anio;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetPlantillasActivas()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetPlantillasActivas();
            if (tipos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaTipos.Add(new SelectTipoModel("-- Seleccionar --", null,""));
            foreach (var dep in tipos)
            {
                list = new SelectTipoModel();
                list.value = dep.Id.ToString();
                list.label = dep.Plantilla;
                list.codigo = dep.NumCuestionario.ToString();
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetFrecuencias()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetFrecuencias();
            if (tipos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaTipos.Add(new SelectTipoModel("-- Seleccionar --", null,""));
            foreach (var dep in tipos)
            {
                list = new SelectTipoModel();
                list.value = dep.Id.ToString();
                list.label = dep.Anio;
                list.codigo = dep.Anio;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetProgramacionesVigentes()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetProgramacionesVigentes();
            if (tipos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaTipos.Add(new SelectTipoModel("-- Seleccionar --", null,""));
            foreach (var dep in tipos)
            {
                list = new SelectTipoModel();
                list.value = dep.Id.ToString();
                list.label = dep.ProgramacionRegistro;
                list.codigo = dep.ProgramacionRegistro;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetEtapas()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetEtapas();
            if (tipos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaTipos.Add(new SelectTipoModel("-- Seleccionar --", null,""));
            foreach (var dep in tipos)
            {
                list = new SelectTipoModel();
                list.value = dep.Id.ToString();
                list.label = dep.Etapa;
                list.codigo = dep.Etapa;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<object> GetDatosRENIEC(string dni)
        {         
            var url = $"{_appConfiguration[$"enlacesSISLISTA:dniReniec"]}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            string json = $"{{\"dni\":\"{dni}\"}}";

            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            return await objReader.ReadToEndAsync();
                        }
                    }
                }
                return null;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }
        public async Task<object> GetDatosSUNAT(string ruc)
        {
            var url = $"{_appConfiguration[$"enlacesSISLISTA:rucSUNAT"]}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            string json = $"{{\"ruc\":\"{ruc}\"}}";

            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            return await objReader.ReadToEndAsync();
                        }
                    }
                }
                return null;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }
    }
}
