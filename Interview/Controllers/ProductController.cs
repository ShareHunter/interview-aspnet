using Interview.Models;
using Interview.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Interview.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository repository;

        public ProductController()
        {
            repository = new ProductRepository();
        }

        public JsonResult GetAll()
        {
            var movies = new List<object>();

            foreach (Product entry in repository.GetAll())
            {
                movies.Add(new { Id = entry.Id, Name = entry.Name, Price = entry.Price, Category = entry.Category, Supplier = entry.Supplier });
            }

            JsonResult result = Json(movies, JsonRequestBehavior.AllowGet);
            return result;
        }

        public JsonResult Get(int id)
        {
            var movies = new List<object>();
            movies.Add(repository.Get(id));
            JsonResult result = Json(movies, JsonRequestBehavior.AllowGet);
            return result;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Product p = repository.Get(id);
            ViewData["Id"] = p.Id;
            ViewData["Name"] = p.Name;
            ViewData["Category"] = p.Category;
            ViewData["Price"] = p.Price;
            ViewData["Supplier"] = p.Supplier;
            return View();
        }
    }
}