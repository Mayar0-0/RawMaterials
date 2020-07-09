using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.IO.ResponseModels.User
{
    public class LoginResponseModel
    {
        public bool Succeed { get; set; }
        public string Message { get; set; }

        public LoginResponseModel(bool _succeed, string _message)
        {
            Succeed = _succeed;
            Message = _message;
        }
    }
}
