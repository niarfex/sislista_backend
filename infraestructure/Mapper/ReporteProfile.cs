using AutoMapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Domain.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Infra.MarcoLista.Mapper
{
    public class ReporteProfile : Profile
    {
        public ReporteProfile()
        {       
            CreateMap<ReporteModel, ReporteGetDto>();
            CreateMap<ReporteModel, ReporteUsuarioListDto>();
            CreateMap<ReporteModel, FlujoValidacionListDto>();
            CreateMap<ReporteModel, RankingRegCerradosListDto>();
            CreateMap<ReporteModel, MejorTiempoListDto>();           
        }
    }
}
