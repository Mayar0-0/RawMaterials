using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RawMaterials.ExceptionsManagement
{
    public class AppExceptionShape: Exception
    {
        public HttpStatusCode _statusCode { get; set; }

        public bool _showExceptionInfo { get; set; }

        public AppExceptionShape(string message = "something went wrong",bool showExceptionInfo = false, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(message)
        {
            _statusCode = statusCode;
            _showExceptionInfo = showExceptionInfo;
        }
    }
}
