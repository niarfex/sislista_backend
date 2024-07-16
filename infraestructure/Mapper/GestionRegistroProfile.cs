using AutoMapper;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Domain.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Infra.MarcoLista.Mapper
{
    public class GestionRegistroProfile : Profile
    {
        public GestionRegistroProfile()
        {
            CreateMap<TenenciaEntity, TenenciaModel>();
            CreateMap<UsoTierraEntity, UsoTierraModel>();
            CreateMap<UsoNoAgricolaEntity, UsoNoAgricolaModel>();
            CreateMap<EstadoEntity, EstadoModel>();
            CreateMap<TipoInformacionEntity, TipoInformacionModel>();
            CreateMap<CultivoModel, CultivoListDto>();
            CreateMap<GestionRegistroModel, GestionRegistroListDto>();
            CreateMap<GestionRegistroModel, GestionRegistroGetDto>();
            CreateMap<FundoModel, FundoGetDto>();
            CreateMap<CampoModel, CampoGetDto>();
            CreateMap<InformanteModel, InformanteGetDto>();
            CreateMap<InformanteEntity, InformanteModel>();
            CreateMap<ArchivoModel, ArchivoGetDto>();
            CreateMap<ArchivoEntity, ArchivoModel>();
        }
    }
}
