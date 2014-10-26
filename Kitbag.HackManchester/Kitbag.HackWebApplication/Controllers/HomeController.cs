using System.Linq;
using System.Web.Mvc;
using Kitbag.Database;
using Kitbag.Domain;
using Kitbag.HackWebApplication.Models;

namespace Kitbag.HackWebApplication.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index() 
        {
            var context = new CwonData();
            var statusRepository = new Repository<Status>(context);
            var personRepository = new PersonRepository(context);

            var model = new HomeViewModel
            {
                Statuses = statusRepository.GetAll().Select(status => new DisplayStatus(status)).ToList(),
                PersonProfile = personRepository.GetByEmail(User.Identity.Name),
            };
            model.UserGroups = model.PersonProfile.Groups1;

            model.Group = new Group {Name = "Development", Id = 4};
            model.Organisation = new Group {Name = "Kitbag", Id = 3};

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