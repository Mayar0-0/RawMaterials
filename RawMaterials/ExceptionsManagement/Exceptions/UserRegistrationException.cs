using System.Net;

namespace RawMaterials.ExceptionsManagement
{
    public class UserRegistrationException : AppExceptionShape
    {
        public UserRegistrationException(string message = "all fields are required in user Registration", bool showExceptionInfo = false, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(message, showExceptionInfo, statusCode)
        {
        }
    }
}
