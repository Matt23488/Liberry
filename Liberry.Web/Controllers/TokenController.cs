using Liberry.Lib.BLL;
using Liberry.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Liberry.Web.Controllers
{
    public class TokenController : ControllerBase
    {
        private TokenManager _tokenManager;

        public TokenController()
        {
            _tokenManager = new TokenManager();
        }

        [AjaxOnly]
        public ActionResult GetToken(string password)
        {
            try
            {
                var tokenResponse = _tokenManager.GetToken(password, HttpContext.Request.UserHostAddress);
                if (tokenResponse.Valid)
                {
                    return AjaxSuccess(tokenResponse.Token);
                }
                else
                {
                    return AjaxFail("Incorrect Password.");
                }
            }
            catch (Exception ex)
            {
                return AjaxFail(ex.Message);
            }
        }
    }
}