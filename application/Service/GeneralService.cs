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
        public async Task<List<CultivoModel>> GetAllCultivos(string param)
        {
            var cultivos = (await _generalPort.GetAllCultivos()).Where(x => x.Cultivo.ToUpper().Contains(param.ToUpper())).ToList();
            if (cultivos == null)
            {
                throw new NotDataFoundException("No se encontraron datos registrados");

            }
            return cultivos;
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
        public async Task<List<SelectTipoModel>> GetDepartamentosMarcoLista(long idPerfil)
        {
            List<SelectTipoModel> listaUbigeos = new List<SelectTipoModel>();
            var ubigeos = await _generalPort.GetDepartamentos(1,"");
            var marcolista = await _marcolistaPort.GetMarcoListasinAginarxPerfil(idPerfil);

            var query = from u in ubigeos
                        join m in marcolista on u.Id equals m.IdDepartamento
                        where m.Estado==1 || m.Estado==0
                        orderby u.Departamento
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
            foreach (var dep in query.DistinctBy(x=> x.Id).ToList())
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
                list.label = dep.Frecuencia;
                list.codigo = dep.Frecuencia;
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
        public async Task<List<SelectTipoModel>> GetTenencias()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetTenencias();
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
                list.label = dep.Tenencia;
                list.codigo = dep.Tenencia;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetUsoTierras()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetUsoTierras();
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
                list.label = dep.UsoTierra;
                list.codigo = dep.UsoTierra;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetCultivos()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetCultivos();
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
                list.label = dep.Cultivo;
                list.codigo = dep.Cultivo;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetUsoNoAgricolas()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetUsoNoAgricolas();
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
                list.label = dep.UsoNoAgricola;
                list.codigo = dep.UsoNoAgricola;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetEstadoEntrevista()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetEstadoEntrevista();
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
                list.label = dep.TipoEstado;
                list.codigo = dep.CodigoEstado;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetTipoInformacion()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetTipoInformacion();
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
                list.label = dep.TipoInformacion;
                list.codigo = dep.CodigoTipoInformacion;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetLineaProduccion()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetLineaProduccion();
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
                list.label = dep.LineaProduccion;
                list.codigo = dep.CodigoLineaProduccion;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetEspecies()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetEspecies();
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
                list.label = dep.Especie;
                list.codigo = dep.CodigoEspecie;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetSecciones()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetSecciones();
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
                list.label = dep.Seccion;
                list.codigo = dep.CodigoSeccion;
                listaTipos.Add(list);
            }
            return listaTipos;
        }
        public async Task<List<SelectTipoModel>> GetEstadosCuestionario()
        {
            List<SelectTipoModel> listaTipos = new List<SelectTipoModel>();
            var tipos = await _generalPort.GetEstadosCuestionario();
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
                list.label = dep.TipoEstado;
                list.codigo = dep.CodigoEstado;
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
