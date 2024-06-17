using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class GeneralService : IGeneralService
    {
        private readonly IGeneralPort _generalPort;

        public GeneralService(IGeneralPort generalPort)
        {
            _generalPort = generalPort ?? throw new ArgumentNullException(nameof(generalPort));
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
    }
}
