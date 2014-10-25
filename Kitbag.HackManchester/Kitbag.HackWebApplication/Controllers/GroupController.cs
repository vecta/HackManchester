using Kitbag.HackWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kitbag.HackWebApplication.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View(int id)
        {
            var model = new GroupViewModel();
            model.IsOrganisation = Request.QueryString["org"] == "true";

            return View(model);
        }
    }
}