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
        GroupRepository groupRepository = new GroupRepository(new CwonData());

        // GET: Group
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View(int id)
        {
            var model = new GroupViewModel();
            model.Group = groupRepository.Get(id);
            model.Groups = groupRepository.GetByGroup(id).ToList();
            model.People = personRepository.GetByGroup(id).ToList();

            model.IsOrganisation = !model.Group.ParentId.HasValue;

            return View(model);
        }
    }
}