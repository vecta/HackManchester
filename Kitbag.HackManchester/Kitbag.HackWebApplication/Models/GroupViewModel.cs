using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Kitbag.Domain;

namespace Kitbag.HackWebApplication.Models
{
    public class GroupViewModel
    {
        public bool IsOrganisation { get; set; }

        public List<Person> People { get; set; }
        public List<Group> Groups { get; set; }
        public Group Group { get; set; }
        public List<Status> GroupStatuses { get; set; }

        public GroupViewModel()
        {
            People = new List<Person>();
            Groups = new List<Group>();
            GroupStatuses = new List<Status>();
        }
    }
}