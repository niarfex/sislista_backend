using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class GeneralService : IGeneralService
    {
        private readonly IGeneralPort _generalPort;
        private readonly ICondicionJuridicaPort _condicionjuridicaPort;
        private readonly ITipoExplotacionPort _tipoexplotacionPort;
        private readonly IOrganizacionPort _organizacionPort;

        public GeneralService(IGeneralPort generalPort, 
            ICondicionJuridicaPort condicionjuridicaPort,
            ITipoExplotacionPort tipoexplotacionPort,
            IOrganizacionPort organizacionPort)
        {
            _generalPort = generalPort ?? throw new ArgumentNullException(nameof(generalPort));
            _condicionjuridicaPort = condicionjuridicaPort ?? throw new ArgumentNullException(nameof(condicionjuridicaPort));
            _tipoexplotacionPort = tipoexplotacionPort ?? throw new ArgumentNullException(nameof(tipoexplotacionPort));
            _organizacionPort = organizacionPort ?? throw new ArgumentNullException(nameof(organizacionPort));
        }
        public async Task<List<SelectTipoModel>> GetDepartamentos()
        {
            List<SelectTipoModel> listaUbigeos = new List<SelectTipoModel>();
            var ubigeos = await _generalPort.GetDepartamentos(1,"");
            if (ubigeos == null)
            {
                throw new NotDataFoundException("Listado no encontrado");

            }
            SelectTipoModel list;
            //listaUbigeos.Add(new SelectTipoModel("-- Seleccionar --", null, ""));
            foreach (var dep in ubigeos) {
                list = new SelectTipoModel();
                list.value = dep.Id;
                list.label = dep.Departamento;
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
            var tipos = (await _condicionjuridicaPort.GetAll("")).Where(x => x.Otros==0);
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
            foreach (var dep in tipos.Where(x => x.TipoDocumento!="RUC"))
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
    }
}
