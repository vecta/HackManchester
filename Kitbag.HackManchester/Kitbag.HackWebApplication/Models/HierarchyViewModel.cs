using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Kitbag.Domain;

namespace Kitbag.HackWebApplication.Models
{
    public class HierarchyViewModel
    {
        public List<Person> People { get; set; }

        public HierarchyViewModel()
        {
            People = new List<Person>();
        }
    }
}