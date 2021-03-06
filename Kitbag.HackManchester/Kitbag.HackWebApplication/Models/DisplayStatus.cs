﻿using System;
using System.Web;
using Kitbag.Domain.BusinessEntities;

namespace Kitbag.HackWebApplication.Models
{
    public class DisplayStatus
    {
        public DisplayStatus(IStatusUpdate status)
        {
            Type = status.Type;
            PersonId = GetPersonId(status);
            Name = GetDisplayName(status);
            Email = GetEmail(status);
            Message = GetMessage(status);
            TimeStamp = GetTimeStamp(status);
            PrettyDate = GetPrettyDate(status.CreatedDate);
        }

        public int? PersonId { get; private set; }
        public string Type { get; private set; }
        public string Message { get; private set; }
        public string TimeStamp { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string PrettyDate { get; private set; }

        private string GetMessage(IStatusUpdate status) { return HttpUtility.HtmlEncode(status.Message); }

        private string GetTimeStamp(IStatusUpdate status) { return status.CreatedDate.ToString(status.CreatedDate.Date != DateTime.Today ? "d MMM yyyy h:mmtt" : "h:mm tt"); }

        private int GetPersonId(IStatusUpdate status) { return status.Person != null ? status.Person.Id : 0; }

        private string GetEmail(IStatusUpdate status) { return status.Person != null ? status.Person.Email : string.Empty; }

        private string GetDisplayName(IStatusUpdate status)
        {
            if (status.Group != null)
                return status.Group.Name;

            if (status.Person == null)
                return string.Empty;

            var person = status.Person;
            return String.IsNullOrEmpty(person.FirstName) ? person.Email : string.Format("{0} {1}", person.FirstName, person.LastName);
        }

        private string GetPrettyDate(DateTime d)
        {
            var s = DateTime.Now.Subtract(d);

            var dayDiff = (int) s.TotalDays;

            var secDiff = (int) s.TotalSeconds;

            if (dayDiff < 0 || dayDiff >= 31)
            {
                return null;
            }

            if (dayDiff == 0)
            {
                if (secDiff < 60)
                {
                    return "just now";
                }
                if (secDiff < 120)
                {
                    return "1 minute ago";
                }
                if (secDiff < 3600)
                {
                    return string.Format("{0} minutes ago", Math.Floor((double) secDiff/60));
                }
                if (secDiff < 7200)
                {
                    return "1 hour ago";
                }
                if (secDiff < 86400)
                {
                    return string.Format("{0} hours ago", Math.Floor((double) secDiff/3600));
                }
            }
            if (dayDiff == 1)
            {
                return "yesterday";
            }
            if (dayDiff < 7)
            {
                return string.Format("{0} days ago", dayDiff);
            }
            if (dayDiff < 31)
            {
                return string.Format("{0} weeks ago", Math.Ceiling((double) dayDiff/7));
            }
            return null;
        }
    }
}