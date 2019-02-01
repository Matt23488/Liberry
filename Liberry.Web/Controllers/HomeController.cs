using Liberry.Lib.BLL;
using Liberry.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Liberry.Web.Controllers
{
    //[ValidateToken]
    public class HomeController : ControllerBase
    {
        private TokenManager _tokenManager;

        public HomeController()
        {
            _tokenManager = new TokenManager();
        }

        public ActionResult Index()
        {
            return View();
        }

        [ValidateToken]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Tokens()
        {
            var model = _tokenManager.GetAllTokens();

            return View(model);
        }

        [AjaxOnly]
        [HttpGet]
        [ValidateToken]
        public ActionResult TestValidate()
        {
            return AjaxSuccess();
        }

        [AjaxOnly]
        [HttpGet]
        public ActionResult TestNoValidate()
        {
            return AjaxSuccess();
        }
    }
}