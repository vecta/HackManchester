using System.Collections.Generic;
using Kitbag.Domain;

namespace Kitbag.HackWebApplication.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Status> Statuses { get; set; }
        public IEnumerable<Group> UserGroups { get; set; }
        public Person PersonProfile { get; set; }

        public Group Group { get; set; }
        public Group Organisation { get; set; }
    }
}