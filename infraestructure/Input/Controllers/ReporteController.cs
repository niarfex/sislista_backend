using Application.Input;
using Application.Service;
using Application.Service.Exportar;
using AutoMapper;
using Domain.Exceptions;
using Domain.Model;
using Infra.Helpers;
using Infra.MarcoLista.Input.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/reporte")]
    [ApiController]
    [Authorize]
    public class ReporteController : ControllerBase
    {
        
        private readonly IReporteService _reporteService;
        private readonly IExcelExporterService _excelexporterService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public ReporteController(IReporteService reporteService,
            IExcelExporterService excelexporterService,

            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _reporteService = reporteService;
            _excelexporterService = excelexporterService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ResponseModel> GetAll()
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                ReporteGetDto reporte = new ReporteGetDto();
                var usuario = (LoginModel)_httpContextAccessor.HttpContext.Items["User"];
                reporte = _mapper.Map<ReporteGetDto>(await _reporteService.GetAll(usuario.CodigoPerfil));
                reporte.ListFlujoValidacion = _mapper.Map<List<FlujoValidacionListDto>>(await _reporteService.GetFlujoValidacionList(usuario.CodigoPerfil));
                reporte.ListReporteUsuarios = _mapper.Map<List<ReporteUsuarioListDto>>(await _reporteService.GetReporteUsuarioList(usuario.CodigoPerfil));
                reporte.ListRegCerrados = _mapper.Map<List<RankingRegCerradosListDto>>(await _reporteService.GetRankingRegCerradosList(usuario.CodigoPerfil));
                reporte.ListMejorTiempo = _mapper.Map<List<MejorTiempoListDto>>(await _reporteService.GetMejorTiempoList(usuario.CodigoPerfil));
                respuesta.success = true;
                if (reporte != null)
                {
                    respuesta.data = reporte;
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
    }
}
