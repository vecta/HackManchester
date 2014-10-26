using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kitbag.Domain;

namespace Kitbag.HackWebApplication.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Skype { get; set; }
        public string CurrentlyWorkingOn { get; set; }

        public List<Group> Groups { get; set; }
        public List<DisplayStatus> Status { get; set; } 

        public PersonViewModel()
        {
            Groups = new List<Group>();
            Status = new List<DisplayStatus>();
        }
    }
}