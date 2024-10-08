﻿using Domain.Model;

namespace Application.Input
{
    public interface IGeneralService
    {
        Task<List<CultivoModel>> GetAllCultivos(string param);
        Task<List<UbigeoModel>> GetAllUbigeo(string param);
        Task<List<SelectTipoModel>> GetDepartamentos();
        Task<List<SelectTipoModel>> GetDepartamentosMarcoLista(long idPerfil);
        Task<List<SelectTipoModel>> GetProvincias(string idUbigeo);
        Task<List<SelectTipoModel>> GetDistritos(string idUbigeo);
        Task<List<SelectTipoModel>> GetTipoOrganizacion();
        Task<List<SelectTipoModel>> GetCondicionJuridicas();
        Task<List<SelectTipoModel>> GetCondicionJuridicaOtros();
        Task<List<SelectTipoModel>> GetTipoExplotacion();
        Task<List<SelectTipoModel>> GetTipoDocumento();
        Task<List<SelectTipoModel>> GetTipoDocumentoPN();
        Task<List<SelectTipoModel>> GetOrganizaciones();
        Task<List<SelectTipoModel>> GetPerfiles();
        Task<List<SelectTipoModel>> GetPerfilesTodos();
        Task<List<SelectTipoModel>> GetPeriodos();
        Task<List<SelectTipoModel>> GetPlantillasActivas();
        Task<List<SelectTipoModel>> GetFrecuencias();
        Task<List<SelectTipoModel>> GetProgramacionesVigentes();
        Task<List<SelectTipoModel>> GetEtapas();
        Task<List<SelectTipoModel>> GetTenencias();
        Task<List<SelectTipoModel>> GetUsoTierras();
        Task<List<SelectTipoModel>> GetCultivos();
        Task<List<SelectTipoModel>> GetUsoAgricolas();
        Task<List<SelectTipoModel>> GetUsoNoAgricolas();
        Task<List<SelectTipoModel>> GetEstadoEntrevista();
        Task<List<SelectTipoModel>> GetTipoInformacion();
        Task<List<SelectTipoModel>> GetLineaProduccion();
        Task<List<SelectTipoModel>> GetEspecies();
        Task<List<SelectTipoModel>> GetSecciones();
        Task<List<SelectTipoModel>> GetEstadosCuestionario(long idCuestionario, string estadoRegistro, string estadoSupervision, string estadoValidacion);
        Task<object> GetDatosRENIEC(string dni);
        Task<object> GetDatosSUNAT(string ruc);
    }
}
