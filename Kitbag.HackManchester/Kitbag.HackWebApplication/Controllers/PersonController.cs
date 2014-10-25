using Kitbag.HackWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kitbag.HackWebApplication.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View(int id)
        {
            var model = new PersonViewModel();
            model.Name = "Steve McLovin";

            return View(model);
        }
    }
}