using Liberry.Lib.BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Liberry.Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ValidateTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // If request is a standard browser request, we want to redirect to the Login page if
            // there isn't a valid token. But if it's an Ajax request, we want to send a JSON response
            // informing the client that the token is missing or invalid.
            var rejectionFunction = default(Action<ActionExecutingContext>);
            if (filterContext.HttpContext.Request.IsAjaxRequest()) rejectionFunction = SendRejectionJSON;
            else rejectionFunction = RedirectToLogin;

            var cookie = filterContext.HttpContext.Request.Cookies.Get("token");
            if (cookie == null)
            {
                rejectionFunction(filterContext);
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                return;
            }

            var tokenManager = new TokenManager();
            if (!tokenManager.ValidateToken(cookie.Value, filterContext.HttpContext.Request.UserHostAddress))
            {
                rejectionFunction(filterContext);
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
        }

        private void RedirectToLogin(ActionExecutingContext filterContext)
        {
            var encodedURL = filterContext.HttpContext.Server.UrlEncode(filterContext.HttpContext.Request.RawUrl);
            filterContext.HttpContext.Response.Redirect($"/Auth/Login?redirectURL={encodedURL}", true);
        }

        private void SendRejectionJSON(ActionExecutingContext filterContext)
        {
            // TODO: Unify this with the class that's currently an inner class of ControllerBase.
            var response = new
            {
                Success = false,
                Message = "Not logged in."
            };

            var rejectionString = JsonConvert.SerializeObject(response);

            filterContext.HttpContext.Response.Output.Write(rejectionString);
            filterContext.HttpContext.Response.Flush();
            filterContext.HttpContext.Response.Close();
        }
    }
}