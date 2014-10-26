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
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View(int id)
        {
            var personRepository = new Repository<Person>(new CwonData());
            var person = personRepository.Get(id);
            var model = new PersonViewModel();

            if (person != null)
            {
                model.Name = string.Format("{0} {1}", person.FirstName, person.LastName);
                model.Group = "Marketing";
                model.Email = person.Email;
                model.Telephone = "0000-000-0000";
                model.Skype = "MyAmazingSkypeName";
                model.Groups = person.Groups1.ToList();
                model.Status = person.Status.ToList();

                var currentlyWorkingOn = person.CurrentlyWorkingOns.OrderByDescending(m => m.Id).FirstOrDefault();
                
                if (currentlyWorkingOn != null)
                    model.CurrentlyWorkingOn = currentlyWorkingOn.CurrentlyWorkingOn1;
            }
            
            return View(model);
        }
    }
}