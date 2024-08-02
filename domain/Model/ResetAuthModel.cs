using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ResetAuthModel
    {
        [Description("NewPassword")]
        public string? NewPassword { get; set; }
        [Description("ReNewPassword")]
        public string? ReNewPassword { get; set; }
        [Description("Token")]
        public string? Token { get; set; }
    }
}
