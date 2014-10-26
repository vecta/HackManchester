using System.Collections.Generic;
using Kitbag.Domain;
using Kitbag.HackWebApplication.Controllers;

namespace Kitbag.HackWebApplication.Models
{
    public class HomeViewModel
    {
        public List<DisplayStatus> Statuses { get; set; }
    }
}