using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleWebApp.Controllers
{
    using Models;

    public class HomeController : Controller
    {
        private VisitorModel model = new VisitorModel();

        // GET: Home
        public ActionResult Index()
        {
            return View(model.GetVisitors());
        }

        [HttpPost]
        public ActionResult Index(string nameToRegister)
        {
            model.RegisterVisit(nameToRegister);
            return Index();
        }
    }
}