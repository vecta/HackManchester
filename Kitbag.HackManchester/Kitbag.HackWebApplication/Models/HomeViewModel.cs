using System.Collections.Generic;
using Kitbag.Domain;

namespace Kitbag.HackWebApplication.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Status> Statuses { get; set; }
    }
}