using Liberry.Lib.BLL;
using Liberry.Web.Filters;
using Liberry.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Liberry.Web.Controllers
{
    public class AuthController : ControllerBase
    {
        private TokenManager _tokenManager;

        public AuthController()
        {
            _tokenManager = new TokenManager();
        }

        [HttpGet]
        public ActionResult Login(string redirectURL)
        {
            var model = new LoginModel
            {
                RedirectURL = redirectURL ?? "/"
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                var tokenResponse = _tokenManager.GetToken(model.Password, HttpContext.Request.UserHostAddress);
                if (tokenResponse.Valid)
                {
                    var cookie = new HttpCookie("token", tokenResponse.Token);
                    cookie.Expires = tokenResponse.Expires;
                    Response.SetCookie(cookie);

                    return Redirect(model.RedirectURL);
                }
                else
                {
                    ModelState.AddModelError(nameof(model.Password), "Incorrect Password.");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
                return View(model);
            }
        }
    }
}