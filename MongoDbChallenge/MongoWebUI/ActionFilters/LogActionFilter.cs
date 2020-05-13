using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MongoWebUI.ActionFilters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        private void Log(string LogText, RouteData RouteDataIn)
        {
            var _controllerName = RouteDataIn.Values["controller"];
            var _actionName = RouteDataIn.Values["action"];
            var _msg = $"{LogText}; controller: {_controllerName}; actionName: {_actionName}";
            Debug.WriteLine(_msg, "Action Filter Log");
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting", filterContext.RouteData);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("OnResultExecuting", filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("OnResultExecuted", filterContext.RouteData);
        }
    }
}