using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class ResponseModel
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public ResponseModel(bool _success, string _message, object _data ) {
            success = _success;
            message = _message;
            data = _data;
        }
        public ResponseModel() {
            success = false;
            message = "";
            data = null;
        }
    }
}
