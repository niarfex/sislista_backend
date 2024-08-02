using Application.Input;
using Application.Service;
using Application.Service.Exportar;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Domain.Model.ExportExcel;
using Infra.Helpers;
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
    [Authorize]
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
        [Route("GetAllToExcel")]
        public async Task<FileResult> GetAllToExcel(string param = "")
        {
            try
            {
                var output = _mapper.Map<List<GestionRegistroListDto>>(await _gestionregistroService.GetAll(param,""));
                if (output != null)
                {
                    var file = await _excelexporterService.ExportToExcel(_mapper.Map<List<GestionRegistroExcel>>(output));
                    return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "marcolista.xlsx");
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
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
                var listSecciones = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetSecciones());
                var listEstadosCuestionario = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetEstadosCuestionario());
               
                var listTenencia = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetTenencias());
                var listUsoTierra = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetUsoTierras());
                var listCultivo = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetCultivos());
                var listUsoNoAgricola = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetUsoNoAgricolas());
                var listEstadoEntrevista = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetEstadoEntrevista());
                var listTipoInformacion = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetTipoInformacion());
                var listLineaProduccion = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetLineaProduccion());
                var listEspecies = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetEspecies());

                objGestionRegistro = _mapper.Map<GestionRegistroGetDto>(objGestionRegistroML);
                if (objGestionRegistroML.CodigoUUID.IsNullOrEmpty())
                {
                    
                    objGestionRegistro.ListFundos = new List<FundoGetDto>();
                    objGestionRegistro.ListArchivos = new List<ArchivoGetDto>();
                    objGestionRegistro.ListInformantes = new List<InformanteGetDto>();
                    objGestionRegistro.ListPecuarios = new List<PecuarioGetDto>();
                    objGestionRegistro.ListObservaciones = new List<TrazabilidadGetDto>();
                }
                else
                {
                    objGestionRegistro.ListFundos = _mapper.Map<List<FundoGetDto>>(await _gestionregistroService.GetFundosCuestionario(objGestionRegistro.CodigoUUID));
                    objGestionRegistro.ListArchivos = _mapper.Map<List<ArchivoGetDto>>(await _gestionregistroService.GetArchivosCuestionario(objGestionRegistro.CodigoUUID));
                    objGestionRegistro.ListInformantes = _mapper.Map<List<InformanteGetDto>>(await _gestionregistroService.GetInformantesCuestionario(objGestionRegistro.CodigoUUID));
                    objGestionRegistro.ListPecuarios = _mapper.Map<List<PecuarioGetDto>>(await _gestionregistroService.GetPecuariosCuestionario(objGestionRegistro.CodigoUUID));
                    objGestionRegistro.ListObservaciones = _mapper.Map<List<TrazabilidadGetDto>>(await _gestionregistroService.GetObservacionesCuestionario(objGestionRegistro.CodigoUUID));
                    for (int i = 0; i < objGestionRegistro.ListFundos.Count(); i++) {
                        objGestionRegistro.ListFundos[i].Orden = i + 1;
                        objGestionRegistro.ListFundos[i].ListDepartamento = listDepartamentos;
                        objGestionRegistro.ListFundos[i].ListProvincia = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetProvincias(objGestionRegistro.ListFundos[i].IdUbigeo.Substring(0, 2)));
                        objGestionRegistro.ListFundos[i].ListDistrito = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetDistritos(objGestionRegistro.ListFundos[i].IdUbigeo.Substring(0, 4)));
                        for (int j = 0; j < objGestionRegistro.ListFundos[i].ListCampos.Count(); j++) {
                            objGestionRegistro.ListFundos[i].ListCampos[j].Orden = j + 1;
                            foreach (var pecu in objGestionRegistro.ListPecuarios.FindAll(x => x.IdFundo == objGestionRegistro.ListFundos[i].Id
                            && x.IdCampo == objGestionRegistro.ListFundos[i].ListCampos[j].Id))
                            {
                                pecu.OrdenFundo = i + 1;
                                pecu.OrdenCampo = j + 1;
                            }
                        }
                    }
                
                
                
                }
                objGestionRegistro.ListProvincia = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetProvincias(objGestionRegistro.IdUbigeo.Substring(0, 2)));
                objGestionRegistro.ListDistrito = _mapper.Map<List<SelectTipoDto>>(await _generalService.GetDistritos(objGestionRegistro.IdUbigeo.Substring(0, 4)));
                objGestionRegistro.ListCondicionJuridica = listCondicionJuridica;
                objGestionRegistro.ListCondicionJuridicaOtros = listCondicionJuridicaOtros;
                objGestionRegistro.ListTipoDocumento = listTipoDocumento;
                objGestionRegistro.ListTipoExplotacion = listTipoExplotacion;
                objGestionRegistro.ListDepartamento = listDepartamentos;
                objGestionRegistro.ListTenencia = listTenencia;
                objGestionRegistro.ListUsoTierra = listUsoTierra;
                objGestionRegistro.ListCultivo = listCultivo;
                objGestionRegistro.ListUsoNoAgricola = listUsoNoAgricola;
                objGestionRegistro.ListEstadoEntrevista = listEstadoEntrevista;
                objGestionRegistro.ListTipoInformacion = listTipoInformacion;
                objGestionRegistro.ListPeriodos = listPeriodos;
                objGestionRegistro.ListLineaProduccion = listLineaProduccion;
                objGestionRegistro.ListEspecies = listEspecies;
                objGestionRegistro.ListSecciones = listSecciones;
                objGestionRegistro.ListEstadosCuestionario = listEstadosCuestionario;
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
        [HttpPost]
        [Route("SubirArchivo")]
        public async Task<string> SubirArchivo(IFormFile file,[FromForm] string numdoc, [FromForm] string periodo)
        {
            try
            {
                Guid obj = Guid.NewGuid();
                string filename = "";
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                filename = obj.ToString() + extension;

                var filepathsrc = Path.Combine(Directory.GetCurrentDirectory(), "Temp",numdoc+"-"+periodo);
                if (!Directory.Exists(filepathsrc))
                {
                    Directory.CreateDirectory(filepathsrc);
                }
                var exactpathsrc = Path.Combine(filepathsrc, filename);
                using (var stream = new FileStream(exactpathsrc, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return filename;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("CreateCuestionario")]
        public async Task<ResponseModel> CreateCuestionario(GestionRegistroCreateUpdateDto dto)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var uuid = await _gestionregistroService.CreateCuestionario(_mapper.Map<GestionRegistroModel>(dto));
                respuesta.success = true;
                respuesta.message = "Se registraron los datos correctamente";
                respuesta.data = uuid;
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al registrar los datos";
                return respuesta;
            }
        }
        [HttpPost]
        [Route("DesaprobarCuestionario")]
        public async Task<ResponseModel> DesaprobarCuestionario(GestionRegistroCreateUpdateDto dto)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var uuid = await _gestionregistroService.DesaprobarCuestionario(_mapper.Map<GestionRegistroModel>(dto));
                respuesta.success = true;
                respuesta.message = "Se registraron los datos correctamente";
                respuesta.data = uuid;
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al registrar los datos";
                return respuesta;
            }
        }
        [HttpPost]
        [Route("InvalidarCuestionario")]
        public async Task<ResponseModel> InvalidarCuestionario(GestionRegistroCreateUpdateDto dto)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                var uuid = await _gestionregistroService.InvalidarCuestionario(_mapper.Map<GestionRegistroModel>(dto));
                respuesta.success = true;
                respuesta.message = "Se registraron los datos correctamente";
                respuesta.data = uuid;
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al registrar los datos";
                return respuesta;
            }
        }
        [HttpGet]
        [Route("AprobarCuestionarioxUUID")]
        public async Task<ResponseModel> AprobarCuestionarioxUUID(string uuid)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se aprobó el registro correctamente";
                respuesta.data = await _gestionregistroService.AprobarCuestionarioxUUID(uuid);
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al aprobar el registro";
                return respuesta;
            }
        }
        [HttpGet]
        [Route("RatificarCuestionarioxUUID")]
        public async Task<ResponseModel> RatificarCuestionarioxUUID(string uuid)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se ratificó el registro correctamente";
                respuesta.data = await _gestionregistroService.RatificarCuestionarioxUUID(uuid);
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al ratificar el registro";
                return respuesta;
            }
        }
        [HttpGet]
        [Route("DerivarCuestionarioxUUID")]
        public async Task<ResponseModel> DerivarCuestionarioxUUID(string uuid)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se derivó el registro correctamente";
                respuesta.data = await _gestionregistroService.DerivarCuestionarioxUUID(uuid);
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al derivar el registro";
                return respuesta;
            }
        }
        [HttpGet]
        [Route("ValidarCuestionarioxUUID")]
        public async Task<ResponseModel> ValidarCuestionarioxUUID(string uuid)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se validó el registro correctamente";
                respuesta.data = await _gestionregistroService.ValidarCuestionarioxUUID(uuid);
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al validar el registro";
                return respuesta;
            }
        }
        [HttpGet]
        [Route("DescartarCuestionarioxUUID")]
        public async Task<ResponseModel> DescartarCuestionarioxUUID(string uuid)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                respuesta.success = true;
                respuesta.message = "Se descartó el registro correctamente";
                respuesta.data = await _gestionregistroService.DescartarCuestionarioxUUID(uuid);
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.success = false;
                respuesta.message = "Ocurrió un error al descartar el registro";
                return respuesta;
            }
        }
    }
}
