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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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