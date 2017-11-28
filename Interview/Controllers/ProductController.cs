using Interview.Models;
using Interview.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interview.Controllers {
    public class ProductController : Controller {
        private readonly ProductRepository repository;

        public ProductController() {
            repository = new ProductRepository();
        }

        [HttpGet]
        public ActionResult Index() {
            IEnumerable<Product> products;

            products = repository.GetAll();

            return View(products);
        }

        [HttpGet]
        public ActionResult Details(int id) {
            var product = repository.Get(id);

            if (product == null) {
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpGet]
        public JsonResult Get(int id) {
            Product product = repository.Get(id);
            JsonRequestBehavior allowGet = JsonRequestBehavior.AllowGet;

            if (product == null) {
                return Json(null, allowGet);
            }

            return Json(product, allowGet);
        }

        [HttpGet]
        public JsonResult GetAll() {
            IEnumerable<Product> allProducts = repository.GetAll();
            JsonRequestBehavior allowGet = JsonRequestBehavior.AllowGet;

            if (allProducts == null) {
                return Json(null, allowGet);
            }

            return Json(allProducts, allowGet);
        }
    }
}