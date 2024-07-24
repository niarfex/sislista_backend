using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class MenuItemModel
    {
        public long? id { get; set; }
        public string? label { get; set; }
        public string? icon { get; set; }
        public string link { get; set; }        
        public bool isTitle { get; set; }
        public long? parentId { get; set; }
        public List<MenuItemModel> subItems { get; set; }

    }
}
