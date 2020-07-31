using System.Net;

namespace RawMaterials.ExceptionsManagement.Exceptions.EntityNotExisted
{
    public class EntityNotExistedException : AppExceptionShape
    {
        public EntityNotExistedException(string EntityName = "entity", bool showExceptionInfo = false, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base($"this {EntityName} is not existed", showExceptionInfo, statusCode) { }
    }
}
