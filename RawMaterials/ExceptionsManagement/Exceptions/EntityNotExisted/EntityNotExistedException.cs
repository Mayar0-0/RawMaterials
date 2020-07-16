using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RawMaterials.ExceptionsManagement.Exceptions.EntityNotExisted
{
    public class EntityNotExistedException: AppExceptionShape
    {
        public EntityNotExistedException(string EntityName = "entity", bool showExceptionInfo = false, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base($"this {EntityName} is not existed", showExceptionInfo, statusCode) { }
    }
}
