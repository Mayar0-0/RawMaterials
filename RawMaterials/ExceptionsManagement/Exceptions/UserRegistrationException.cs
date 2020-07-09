using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RawMaterials.ExceptionsManagement
{
    public class UserRegistrationException : AppExceptionShape
    {
        public UserRegistrationException(string message = "all fields are required in user Registration",bool showExceptionInfo = false, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(message,showExceptionInfo, statusCode)
        {
        }
    }
}
