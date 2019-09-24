using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace AuthorizationAPI.Handler
{
    public class CustomExceptionFilter:ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            string message = String.Empty;
            if (actionExecutedContext.Exception is UnauthorizedAccessException)
            {
                message = "Unauthorized Access";
                status = HttpStatusCode.Unauthorized;
            }
            else if(actionExecutedContext.Exception is DivideByZeroException){
                message = "Divide by zero exxception";
                status = HttpStatusCode.InternalServerError;
            }
            else
            {
                message = "Not found";
                status = HttpStatusCode.NotFound;
            }
            actionExecutedContext.Response = new HttpResponseMessage()
            {
                Content = new StringContent(message),
                StatusCode = status
            };
        }
    }
}