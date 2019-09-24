using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;

namespace AuthorizationAPI.Handler
{
    public class CustomErrorHandler:ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            Exception exception = context.Exception;
            Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
        }
    }
}