using System.Net;

namespace RawMaterials.ExceptionsManagement.Exceptions.EntityPropExisted
{
    public class EntityPropExistedException : AppExceptionShape
    {
        public EntityPropExistedException(string EntityName, string PropertyType, string PropertyValue, bool showExceptionInfo = false, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base($"a {EntityName} with {PropertyType}: {PropertyValue} is existed", showExceptionInfo, statusCode) { }

    }
}
