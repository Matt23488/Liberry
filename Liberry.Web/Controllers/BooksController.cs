using Liberry.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Liberry.Web.Controllers
{
    [ValidateToken]
    public class BooksController : ControllerBase
    {
        public ActionResult Add()
        {
            return View();
        }
    }
}