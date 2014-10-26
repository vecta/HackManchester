using System.Collections.Generic;
using Kitbag.Domain;
using Kitbag.HackWebApplication.Controllers;

namespace Kitbag.HackWebApplication.Models
{
    public class HomeViewModel
    {
        public List<DisplayStatus> Statuses { get; set; }
        public IEnumerable<Group> UserGroups { get; set; }
        public Person PersonProfile { get; set; }

        public Group Group { get; set; }
        public Group Organisation { get; set; }

        public List<Appointment> Appointments { get; set; }

        public CurrentlyWorkingOn CurrentlyWorkingOn { get; set; }
    }
}