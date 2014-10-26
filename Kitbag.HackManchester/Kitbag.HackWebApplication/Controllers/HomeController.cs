using System.Web.Mvc;
using Kitbag.Database;
using Kitbag.Domain;
using Kitbag.HackWebApplication.Models;
using System.Collections;
using System.Collections.Generic;

namespace Kitbag.HackWebApplication.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var context = new CwonData();
            var model = new HomeViewModel();
            var statusRepository = new Repository<Status>(context);
            var personRepository = new PersonRepository(context);
            
            model.Statuses = statusRepository.GetAll();
            model.PersonProfile = personRepository.GetByEmail(User.Identity.Name);
            model.UserGroups = model.PersonProfile.Groups1;

            model.Group = new Group() { Name = "Development", Id = 4 };
            model.Organisation = new Group() { Name = "Kitbag", Id = 3 };


            //model.Group = model.UserGroups.FirstOrDefault();
            //model.Group = model.PersonProfile.Groups1..OfType<YourType>().FirstOrDefault();
            //model.Group = ((IList<Group>)model.PersonProfile.Groups1).

            return View(model);
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