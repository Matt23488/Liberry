using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Liberry.Web.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected JsonResult AjaxSuccess(object data = null)
        {
            return Json(new ResponseObject
            {
                Success = true,
                Data = data,
                Message = ""
            }, JsonRequestBehavior.AllowGet);
        }

        protected JsonResult AjaxFail(string message)
        {
            return Json(new ResponseObject
            {
                Success = false,
                Data = null,
                Message = message
            }, JsonRequestBehavior.AllowGet);
        }

        private class ResponseObject
        {
            public bool Success { get; set; }
            public object Data { get; set; }
            public string Message { get; set; }
        }
    }
}