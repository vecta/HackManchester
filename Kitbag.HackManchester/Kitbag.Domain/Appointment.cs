using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kitbag.Domain
{
    public class Appointment
    {
        public string calendar_id { get; set; }
        public string description { get; set; }
        public string end { get; set; }
        public string event_uid { get; set; }
        public string start { get; set; }
        public string summary { get; set; }

    }
}
