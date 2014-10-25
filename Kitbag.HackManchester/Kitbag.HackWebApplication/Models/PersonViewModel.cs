using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kitbag.HackWebApplication.Models
{
    public class PersonViewModel
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Skype { get; set; }
        public string CurrentlyWorkingOn { get; set; }
    }
}