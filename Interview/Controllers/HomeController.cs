using Interview.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interview.Controllers {
    public class HomeController : Controller {
        [HttpGet]
        public ActionResult Index() {
            return RedirectToAction("Index", "Product");
        }
    }
}