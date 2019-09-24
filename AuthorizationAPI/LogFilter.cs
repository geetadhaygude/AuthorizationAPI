using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Routing;

namespace AuthorizationAPI
{
    public class LogFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            log("Action executed");
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            log("Action executing");
            //var modelState = actionContext.ModelState;
            //var errors = "";
            //if (!modelState.IsValid)
            //{
            //    foreach (var m1 in modelState) {
            //        foreach (var e1 in m1.Value.Errors)
            //        {
            //            errors=errors+" "+e1.ErrorMessage;
            //        }
            //    }
            //    actionContext.Response = new HttpResponseMessage()
            //    {
            //        StatusCode = System.Net.HttpStatusCode.Forbidden,
            //        Content = new StringContent(errors)
                    
            //    };
            //}
        }
        private void log(string methodName)
        {
            Debug.WriteLine(methodName, "Action Filter Log");
        }
    }
}