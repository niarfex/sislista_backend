using Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace Infra.MarcoLista.Input.Dto
{
    public class MenuItemGetDto
    {
        [JsonPropertyName("id")]
        public long? id { get; set; }
        [JsonPropertyName("label")]
        public string? label { get; set; }
        [JsonPropertyName("icon")]
        public string? icon { get; set; }
        [JsonPropertyName("link")]
        public string? link { get; set; }
        [JsonPropertyName("isTitle")]
        public bool isTitle { get; set; }
        [JsonPropertyName("parentId")]
        public long? parentId { get; set; }
        [JsonPropertyName("subItems")]
        public List<MenuItemModel> subItems { get; set; }
    }
}
