using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace RawMaterials.ExceptionsManagement.ExceptionHandlers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]

    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {

            context.HttpContext.Response.ContentType = "application/json";
            if (context.Exception is AppExceptionShape)
                context.HttpContext.Response.StatusCode = (int)((AppExceptionShape)context.Exception)._statusCode;
            if (context.Exception is AppExceptionShape)
                if (!((AppExceptionShape)context.Exception)._showExceptionInfo)
                    context.Result = new JsonResult(context.Exception.Message);
        }
    }
}
