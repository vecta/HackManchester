using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kitbag.Database;
using Kitbag.Domain;
using Kitbag.HackWebApplication.Models;
using System;

namespace Kitbag.HackWebApplication.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index() 
        {
            var context = new CwonData();
            
            var personRepository = new PersonRepository(context);
            var currentlyWorkingOnRepository = new CurrentlyWorkingOnRepository(context);

            var currentlyWorkingOn =currentlyWorkingOnRepository.GetLatestByPersonEmail(User.Identity.Name);

            var model = new HomeViewModel
            {
                Statuses = GetLatestStatuses(context),
                PersonProfile = personRepository.GetByEmail(User.Identity.Name),
                CurrentlyWorkingOn = currentlyWorkingOn ?? new CurrentlyWorkingOn()
            };
//
//            if(String.IsNullOrEmpty(model.CurrentlyWorkingOn.Message ))
//            {
//        //        model.CurrentlyWorkingOn.Message = "What exactly?";
//            }

            model.UserGroups = model.PersonProfile.Groups1;

            model.Group = new Group {Name = "Development", Id = 4};
            model.Organisation = new Group {Name = "Kitbag", Id = 3};

            return View(model);
        }

        private static List<DisplayStatus> GetLatestStatuses(CwonData context)
        {
            var statusRepository = new StatusRepository(context);
            var workingOnRepository = new CurrentlyWorkingOnRepository(context);
            var updates = statusRepository.GetLatest(20);
            updates = updates.Concat(workingOnRepository.GetLatest(20));
            return updates.OrderByDescending(update => update.CreatedDate).Select(statusUpdate => new DisplayStatus(statusUpdate)).ToList();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}