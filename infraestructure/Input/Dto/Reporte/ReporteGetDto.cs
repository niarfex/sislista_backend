using Infra.MarcoLista.Input.Dto;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Infra.MarcoLista.Input.Dto
{
    public class ReporteGetDto
    {
        [JsonPropertyName("CantEmpadronadores")]
        public long? CantEmpadronadores { get; set; }
        [JsonPropertyName("CantSupervisores")]
        public long? CantSupervisores { get; set; }
        [JsonPropertyName("CantEspecialistas")]
        public long? CantEspecialistas { get; set; }
        [JsonPropertyName("CantCompletados")]
        public long? CantCompletados { get; set; }
        [JsonPropertyName("CantEnProgreso")]
        public long? CantEnProgreso { get; set; }
        [JsonPropertyName("CantNoIniciado")]
        public long? CantNoIniciado { get; set; }
        //Cantidades-Empadronador
        [JsonPropertyName("CantParaRevisar")]
        public long? CantParaRevisar { get; set; }
        [JsonPropertyName("CantTrabajoGabinete")]
        public long? CantTrabajoGabinete { get; set; }
        [JsonPropertyName("CantEnAlerta")]
        public long? CantEnAlerta { get; set; }
        //Cantidades-Supervisor
        [JsonPropertyName("CantParaValidar")]
        public long? CantParaValidar { get; set; }
        [JsonPropertyName("CantObservadoSupervisor")]
        public long? CantObservadoSupervisor { get; set; }
        [JsonPropertyName("CantParaRegistrar")]
        public long? CantParaRegistrar { get; set; }
        [JsonPropertyName("CantArbitraje")]
        public long? CantArbitraje { get; set; }
        //Cantidades-Especialista
        [JsonPropertyName("CantCerrado")]
        public long? CantCerrado { get; set; }
        [JsonPropertyName("CantObservadoEspecialista")]
        public long? CantObservadoEspecialista { get; set; }
        [JsonPropertyName("CantReemplazado")]
        public long? CantReemplazado { get; set; }
        [JsonPropertyName("CantEliminado")]
        public long? CantEliminado { get; set; }
        [JsonPropertyName("ListReporteUsuarios")]
        public List<ReporteUsuarioListDto> ListReporteUsuarios { get; set; }
        [JsonPropertyName("ListFlujoValidacion")]
        public List<FlujoValidacionListDto> ListFlujoValidacion { get; set; }
        [JsonPropertyName("ListRegCerrados")]
        public List<RankingRegCerradosListDto> ListRegCerrados { get; set; }
        [JsonPropertyName("ListMejorTiempo")]
        public List<MejorTiempoListDto> ListMejorTiempo { get; set; }
        [JsonPropertyName("ListPeriodos")]
        public List<SelectTipoDto> ListPeriodos { get; set; }
    }
}
