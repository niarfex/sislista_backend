﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Model
{
    public class PersonaModel
    {     
        public long? IdOrganizacion { get; set; }      
        public long? IdTipoDocumento { get; set; }    
        public long? IdCondicionJuridica { get; set; }     
        public long? IdCondicionJuridicaOtros { get; set; }       
        public string? IdUbigeo { get; set; }  
        public string? CodigoUUID { get; set; }        
        public string? NumeroDocumento { get; set; }
        public string? Cargo { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? RazonSocial { get; set; }
        public string? Celular { get; set; }
        public string? Telefono { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? OficinaArea { get; set; }
        public string? PaginaWeb { get; set; }
        public string? DireccionFiscalDomicilio { get; set; }
        public string? NombreRepLegal { get; set; }
        public string? CorreoRepLegal { get; set; }
        public string? CelularRepLegal { get; set; }
        public string? TieneRuc { get; set; }
    }
}
