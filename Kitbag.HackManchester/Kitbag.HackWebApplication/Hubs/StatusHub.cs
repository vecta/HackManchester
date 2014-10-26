using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using Kitbag.Database;
using Kitbag.Domain;
using Kitbag.HackWebApplication.Models;
using Microsoft.AspNet.SignalR;

namespace Kitbag.HackWebApplication.Hubs
{
    public class StatusHub : Hub
    {
        public void Send(string message)
        {
            var email = Context.User.Identity.Name;

            var dbContext = new CwonData();
            var statusRepository = new Repository<Status>(dbContext);
            var personRepository = new PersonRepository(dbContext);
            var user = personRepository.GetByEmail(email);
            var status = new Status {CreatedDate = DateTime.Now, Status1 = message, People = new List<Person> {user}};
            statusRepository.Create(status);
            
            var displayStatus = new DisplayStatus(status);
            var hash = FormsAuthentication.HashPasswordForStoringInConfigFile(displayStatus.Email.ToLower(), "MD5").ToLower();

            var imageUrl = string.Format(@"http://www.gravatar.com/avatar/{0}?s={1}&d=mm&r=g", hash, 50);
            Clients.All.broadcastMessage(ParseMessage(displayStatus.Message), displayStatus.Name, imageUrl,displayStatus.TimeStamp, displayStatus.Type);
        }

        private static string ParseMessage(string message) { return HttpUtility.HtmlEncode(message).Replace("\n", "</br>"); }
    }
}