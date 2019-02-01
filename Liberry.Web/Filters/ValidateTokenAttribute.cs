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
            var cookie = filterContext.HttpContext.Request.Cookies.Get("token");
            if (cookie == null)
            {
                RedirectToLogin(filterContext);
                return;
            }

            var tokenManager = new TokenManager();
            if (!tokenManager.ValidateToken(cookie.Value, filterContext.HttpContext.Request.UserHostAddress))
            {
                RedirectToLogin(filterContext);
            }
        }

        private void RedirectToLogin(ActionExecutingContext filterContext)
        {
            var encodedURL = filterContext.HttpContext.Server.UrlEncode(filterContext.HttpContext.Request.RawUrl);
            filterContext.HttpContext.Response.Redirect($"/Auth/Login?redirectURL={encodedURL}", true);
        }
    }
}