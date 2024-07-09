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

                var campo1 = new CampoGetDto { Campo = "Campo 1", Superficie = 1, SuperficieCultivada = 0.1, Observacion = "Campo 1x" };
                var campo2 = new CampoGetDto { Campo = "Campo 2", Superficie = 1, SuperficieCultivada = 0.2, Observacion = "Campo 2x" };
                var campo3 = new CampoGetDto { Campo = "Campo 3", Superficie = 2, SuperficieCultivada = 0.3, Observacion = "Campo 3x" };
                var campo4 = new CampoGetDto { Campo = "Campo 4", Superficie = 3, SuperficieCultivada = 0.4, Observacion = "Campo 4x" };
                var campo5 = new CampoGetDto { Campo = "Campo 5", Superficie = 4, SuperficieCultivada = 0.5, Observacion = "Campo 5x" };
                var campo6 = new CampoGetDto { Campo = "Campo 6", Superficie = 5, SuperficieCultivada = 0.6, Observacion = "Campo 6x" };
                var campo7 = new CampoGetDto { Campo = "Campo 7", Superficie = 6, SuperficieCultivada = 0.7, Observacion = "Campo 7x" };
                var campoFundo1 = new List<CampoGetDto>();
                var campoFundo2 = new List<CampoGetDto>();
                var campoFundo3 = new List<CampoGetDto>();
                campoFundo1.Add(campo1); campoFundo1.Add(campo2); campoFundo1.Add(campo3);
                campoFundo2.Add(campo4); campoFundo2.Add(campo5); 
                campoFundo3.Add(campo6); campoFundo3.Add(campo7); 

                var fundo1=new FundoGetDto{ 
                    Fundo="Fundo A",SuperficieAgricola=5.24,SuperficieTotal=6.24,
                    Observacion="Observación",IdUbigeo= "051008"
                    ,ListDepartamento=listDepartamentos
                    ,ListProvincia = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetProvincias("05".Substring(0, 2)))
                    ,ListDistrito = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetDistritos("0510".Substring(0, 4)))
                    ,ListCampos= campoFundo1
                };
                var fundo2 = new FundoGetDto
                {
                    Fundo = "Fundo B",SuperficieAgricola = 3.24,SuperficieTotal = 3.24,
                    Observacion = "Observación",IdUbigeo = "060301"
                    ,ListDepartamento = listDepartamentos
                    ,ListProvincia = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetProvincias("06".Substring(0, 2)))
                    ,ListDistrito = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetDistritos("0603".Substring(0, 4)))
                    ,ListCampos = campoFundo2
                };
                var fundo3 = new FundoGetDto
                {
                    Fundo = "Fundo C",SuperficieAgricola = 1.24,SuperficieTotal = 4.24,
                    Observacion = "Observación",IdUbigeo = "080306"
                    ,ListDepartamento = listDepartamentos
                    ,ListProvincia = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetProvincias("08".Substring(0, 2)))
                    ,ListDistrito = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetDistritos("0803".Substring(0, 4)))
                    ,ListCampos = campoFundo3
                };
                listFundos.Add(fundo1);
                listFundos.Add(fundo2);
                listFundos.Add(fundo3);

                var listTenencia = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetTenencias());
                var listUsoTierra = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetUsoTierras());
                var listCultivo = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetCultivos());
                var listUsoNoAgricola = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetUsoNoAgricolas());
                var listEstadoEntrevista = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetEstadoEntrevista());
                var listTipoInformacion = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetTipoInformacion());

                if (objGestionRegistroML.CodigoUUID.IsNullOrEmpty())
                {
                    objGestionRegistro = _mapper.Map < GestionRegistroGetDto> (objGestionRegistroML);                    
                }
                else
                {
                    objGestionRegistro = _mapper.Map<GestionRegistroGetDto>(await _gestionregistroService.GetGestionRegistroxUUID(objGestionRegistroML.CodigoUUID));
                    
                }
                objGestionRegistro.ListProvincia = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetProvincias(objGestionRegistro.IdUbigeo.Substring(0, 2)));
                objGestionRegistro.ListDistrito = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetDistritos(objGestionRegistro.IdUbigeo.Substring(0, 4)));
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
