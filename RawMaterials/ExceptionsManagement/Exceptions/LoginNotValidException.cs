using System.Net;

namespace RawMaterials.ExceptionsManagement.Exceptions
{
    public class LoginNotValidException : AppExceptionShape
    {
        public LoginNotValidException(string message = "login data isn't valid", bool showExceptionInfo = false, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(message, showExceptionInfo, statusCode) { }
    }
}
