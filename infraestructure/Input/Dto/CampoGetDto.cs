﻿using Infra.MarcoLista.Input.Dto;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Infra.MarcoLista.Input.Dto
{
    public class CampoGetDto
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("IdFundo")]
        public long? IdFundo { get; set; }
        [JsonPropertyName("Campo")]
        public string? Campo { get; set; }
        [JsonPropertyName("IdTenencia")]
        public long? IdTenencia { get; set; }
        [JsonPropertyName("IdUsoTierra")]
        public long? IdUsoTierra { get; set; }
        [JsonPropertyName("IdCultivo")]
        public long? IdCultivo { get; set; }
        [JsonPropertyName("IdUsoNoAgricola")]
        public string? IdUsoNoAgricola { get; set; }
        [JsonPropertyName("Observacion")]
        public string? Observacion { get; set; }
        [JsonPropertyName("Superficie")]
        public double? Superficie { get; set; }
        [JsonPropertyName("SuperficieCultivada")]
        public double? SuperficieCultivada { get; set; }
        [JsonPropertyName("Orden")]
        public int? Orden { get; set; }
        [JsonPropertyName("ListTipoUso")]
        public List<SelectTipoDto>? ListTipoUso { get; set; }
    }
}
