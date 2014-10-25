using Kitbag.Database;
using Kitbag.Domain;
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
        PersonRepository personRepository = new PersonRepository(new CwonData());
        Repository<Group> groupRepository = new Repository<Group>(new CwonData());

        // GET: Group
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View(int id)
        {
            var model = new GroupViewModel();
            //model.Group = 
            model.People = personRepository.GetByGroup(id).ToList();

            model.IsOrganisation = Request.QueryString["org"] == "true";

            return View(model);
        }
    }
}