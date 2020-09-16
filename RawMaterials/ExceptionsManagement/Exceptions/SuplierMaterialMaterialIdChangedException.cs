using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RawMaterials.ExceptionsManagement
{
    public class SuplierMaterialMaterialIdChangedException : AppExceptionShape
    {
        public SuplierMaterialMaterialIdChangedException(string message = "you can't change material id",bool showExceptionInfo = false, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(message,showExceptionInfo, statusCode)
        {
        }
    }
}
