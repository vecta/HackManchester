using System;
using System.Linq;
using System.Web;
using Kitbag.Domain;

namespace Kitbag.HackWebApplication.Models
{
    public class DisplayCurrentlyWorkingOn
    {
        public DisplayCurrentlyWorkingOn(CurrentlyWorkingOn status)
        {
            Name = GetDisplayName(status);
            Email = GetEmail(status);
            Message = GetMessage(status);
            TimeStamp = GetTimeStamp(status);
        }

        public string Message { get; set; }
        public string TimeStamp { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        private string GetMessage(CurrentlyWorkingOn status) { return HttpUtility.HtmlEncode(status.CurrentlyWorkingOn1); }

        private string GetTimeStamp(CurrentlyWorkingOn status)
        {
            return status.CreatedDate.ToString(status.CreatedDate.Date != DateTime.Today ? "d MMM yyyy h:mmtt" : "h:mm tt");
        }

        private string GetEmail(CurrentlyWorkingOn status) { return status.People.Any() ? status.People.First().Email : string.Empty; }

        private string GetDisplayName(CurrentlyWorkingOn status)
        {
            if (status.Groups.Any())
                return status.Groups.First().Name;

            if (!status.People.Any())
                return string.Empty;

            var person = status.People.First();
            return String.IsNullOrEmpty(person.FirstName) ? person.Email : string.Format("{0} {1}", person.FirstName, person.LastName);
        }
    }
}