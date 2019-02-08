using Liberry.Lib.BLL;
using Liberry.Lib.DTO;
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
        private LiberryService _service = new LiberryService();

        [HttpGet]
        public ActionResult Add()
        {
            var sections = _service.GetAllSections();
            ViewBag.Sections = new SelectList(sections, nameof(SectionDTO.SectionId), nameof(SectionDTO.Name));

            var model = new BookDTO();
            return View(model);
        }

        [HttpGet]
        public ActionResult Search(string searchText)
        {
            return View(model: searchText);
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult SearchAsync(string searchText)
        {
            return null;
        }
    }
}