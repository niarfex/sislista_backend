using Application.Input;
using Application.Service;
using Application.Service.Exportar;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Infra.MarcoLista.Input.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/gestionregistro")]
    [ApiController]
    public class GestionRegistroController : ControllerBase
    {
        private readonly IGestionRegistroService _gestionregistroService;
        private readonly IExcelExporterService _excelexporterService;
        private readonly IGeneralService _generalService;
        private readonly IMapper _mapper;

        public GestionRegistroController(IGestionRegistroService gestionregistroService,
            IExcelExporterService excelexporterService,
            IGeneralService generalService,
            IMapper mapper)
        {
            _gestionregistroService = gestionregistroService;
            _excelexporterService = excelexporterService;
            _generalService = generalService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ResponseModel> GetAll(string uuid,string param = "")
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var cuestionarios = await _gestionregistroService.GetAll(param,uuid);
                respuesta.success = true;
                if (cuestionarios != null)
                {
                    respuesta.data = _mapper.Map<List<GestionRegistroListDto>>(cuestionarios);
                }
                else
                {
                    respuesta.data = null;
                }
                respuesta.message = "Se listan los datos correctamente";
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al consultar el listado";
                return respuesta;
            }
        }
        [HttpGet]
        [Route("GetGestionRegistroxDatos")]
        public async Task<ResponseModel> GetGestionRegistroxDatos(string numDoc,long idPeriodo)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                GestionRegistroGetDto objGestionRegistro = new GestionRegistroGetDto();

                var objGestionRegistroML = await _gestionregistroService.GetUUIDCuestionario(numDoc, idPeriodo);
        
                var listDepartamentos = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetDepartamentos());
                var listCondicionJuridica = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetCondicionJuridicas());
                var listCondicionJuridicaOtros = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetCondicionJuridicaOtros());
                var listTipoDocumento = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetTipoDocumento());
                var listTipoExplotacion = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetTipoExplotacion());
                var listPeriodos = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetPeriodos());
                var listFundos = new List<FundoGetDto>();
                var listTenencia = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetTenencias());
                var listUsoTierra = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetUsoTierras());
                var listCultivo = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetCultivos());
                var listUsoNoAgricola = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetUsoNoAgricolas());
                var listEstadoEntrevista = new List<SelectTipoDto>();
                var listTipoInformacion = new List<SelectTipoDto>();

                if (objGestionRegistroML.CodigoUUID.IsNullOrEmpty())
                {
                    objGestionRegistro = _mapper.Map < GestionRegistroGetDto> (objGestionRegistroML);
                    objGestionRegistro.ListProvincia = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetProvincias(objGestionRegistro.IdUbigeo.Substring(0, 2)));
                    objGestionRegistro.ListDistrito = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetDistritos(objGestionRegistro.IdUbigeo.Substring(0, 4)));
                }
                else
                {
                    objGestionRegistro = _mapper.Map<GestionRegistroGetDto>(await _gestionregistroService.GetGestionRegistroxUUID(objGestionRegistroML.CodigoUUID));
                    objGestionRegistro.ListProvincia = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetProvincias(objGestionRegistro.IdUbigeo.Substring(0, 2)));
                    objGestionRegistro.ListDistrito = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetDistritos(objGestionRegistro.IdUbigeo.Substring(0, 4)));
                }
                objGestionRegistro.ListCondicionJuridica = listCondicionJuridica;
                objGestionRegistro.ListCondicionJuridicaOtros = listCondicionJuridicaOtros;
                objGestionRegistro.ListTipoDocumento = listTipoDocumento;
                objGestionRegistro.ListTipoExplotacion = listTipoExplotacion;
                objGestionRegistro.ListDepartamento = listDepartamentos;
                objGestionRegistro.ListFundos = listFundos;
                objGestionRegistro.ListTenencia = listTenencia;
                objGestionRegistro.ListUsoTierra = listUsoTierra;
                objGestionRegistro.ListCultivo = listCultivo;
                objGestionRegistro.ListUsoNoAgricola = listUsoNoAgricola;
                objGestionRegistro.ListEstadoEntrevista = listEstadoEntrevista;
                objGestionRegistro.ListTipoInformacion = listTipoInformacion;
                respuesta.success = true;
                respuesta.message = "Se listan los datos correctamente";
                respuesta.data = objGestionRegistro;
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al consultar el listado";
                return respuesta;
            }
        }
    }
}
