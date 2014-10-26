using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kitbag.Database;
using Kitbag.Domain;
using Kitbag.HackWebApplication.Models;

namespace Kitbag.HackWebApplication.Controllers
{
    public class GroupController : Controller
    {
        private readonly PersonRepository personRepository = new PersonRepository(new CwonData());
        private readonly GroupRepository groupRepository = new GroupRepository(new CwonData());

        // GET: Group
        public ActionResult Index() { return View(); }

        public ActionResult View(int id)
        {
            var model = new GroupViewModel();
            var people = personRepository.GetByGroup(id).ToList();
            
            model.Group = groupRepository.Get(id);
            model.Groups = groupRepository.GetByGroup(id).ToList();
            model.People = people;
            model.IsOrganisation = !model.Group.ParentId.HasValue;

            if (model.Group.ParentId.HasValue)
            {
                var personStatus = new List<DisplayStatus>();

                foreach (var person in people)
                {
                    foreach (var individualStatus in person.Status)
                    {
                        personStatus.Add(new DisplayStatus(individualStatus));
                    }
                }

                model.PersonStatus = personStatus;
            }
            else
            {
                var personStatus = new List<DisplayStatus>();

                foreach (var person in personRepository.GetByOrgansation(id))
                {
                    foreach (var individualStatus in person.Status)
                    {
                        personStatus.Add(new DisplayStatus(individualStatus));
                    }
                }

                model.PersonStatus = personStatus;
            }
            
            return View(model);
        }

        public ActionResult Hierarchy(int id)
        {
            var model = new HierarchyViewModel();
            model.People = personRepository.GetByGroup(id).OrderBy(x => x.HierarchyLevel).ToList();

            foreach (var person in model.People)
            {
                //person.Reports = personRepository.GetByManagerId(person.Id);
            }

            return View(model);
        }
    }
}