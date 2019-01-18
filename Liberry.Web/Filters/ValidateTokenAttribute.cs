using Liberry.Lib.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Liberry.Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ValidateTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.ActionParameters.ContainsKey("token")) throw new InvalidOperationException("You are not authorized to do this. A valid token value must be supplied to access this functionality.");

            var tokenValue = filterContext.ActionParameters["token"] as string;
            if (string.IsNullOrWhiteSpace(tokenValue)) throw new InvalidOperationException("You are not authorized to do this. A valid token value must be supplied to access this functionality.");

            var tokenManager = new TokenManager();
            // Maybe just store the token as a cookie and access it through the cookies, rather than needing special parameters
            //if (!tokenManager.ValidateToken(tokenValue, filterContext.HttpContext.Request.Cookies))
            //filterContext.HttpContext.Request.UserHostAddress // This is the IP
            if (!tokenManager.ValidateToken(tokenValue, filterContext.HttpContext.Request.UserHostAddress)) throw new InvalidOperationException("You are not authorized to do this. The token value supplied is not valid.");
        }
    }
}