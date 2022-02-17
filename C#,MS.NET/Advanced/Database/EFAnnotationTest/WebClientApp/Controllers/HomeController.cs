using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClientApp.Controllers
{
    using Models;

    public class HomeController : Controller
    {
        ShopEntities model = new ShopEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View(model.Products.ToList());
        }

        public ActionResult Details(int? id)
        {
            Product product = model.Products.Find(id ?? 101);
            model.Entry(product).Collection(p => p.Orders).Load(); // explicit loading of child entities

            ViewBag.SelectedProduct = product.Id;

            return View(product.Orders);
        }

        public ActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if(ModelState.IsValid)
            {
                Counter ctr = model.Counters.Find("product");
                product.Id = ++ctr.CurrentValue + 100;

                model.Products.Add(product);
                model.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}