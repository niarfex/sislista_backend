using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ReporteModel
    {
        //Cantidades-Administrador
        public long? CantEmpadronadores { get; set; }
        public long? CantSupervisores { get; set; }
        public long? CantEspecialistas { get; set; }
        public long? CantCompletados { get; set; }
        public long? CantEnProgreso { get; set; }
        public long? CantNoIniciado { get; set; }
        //Cantidades-Empadronador
        public long? CantParaRevisar { get; set; }
        public long? CantTrabajoGabinete { get; set; }
        public long? CantEnAlerta { get; set; }
        //Cantidades-Supervisor
        public long? CantParaValidar { get; set; }
        public long? CantObservadoSupervisor { get; set; }
        public long? CantParaRegistrar { get; set; }
        public long? CantArbitraje { get; set; }
        //Cantidades-Especialista
        public long? CantCerrado { get; set; }
        public long? CantObservadoEspecialista { get; set; }
        public long? CantReemplazado { get; set; }
        public long? CantEliminado { get; set; }
        //Lista-Usuarios
        public string? Usuario { get; set; }
        public double? Avance { get; set; }
        public double? Cambio { get; set; }
        public long? CantMarcoLista { get; set; }
        public string? Perfil { get; set; }
        public long? RegCerrados { get; set; }
        //Lista-Flujo-Validacion
        public string? Empresa { get; set; }
        public long? NumTiempo { get; set; }
        public string? Tiempo { get; set; }
        //Auxiliares
        public string? CodigoEstadoRegistro { get; set; }
        public long? IdMarcoLista { get; set; }
        public DateTime FechaInicioRegistro { get; set; }
        public DateTime FechaFinValidacion { get; set; }
        //Lista-Empadronador-Registros-Cerrados
        //Lista-Mejores-Tiempos-Registro
        //Lista-Supervisor-Registros-Cerrados
        //Lista-Mejores-Tiempos-Supervision
        //Lista-Especialista-Registros-Cerrados
        //Lista-Mejores-Tiempos-Validacion
    }
}
