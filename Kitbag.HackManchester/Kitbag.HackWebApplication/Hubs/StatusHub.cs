using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using Kitbag.Database;
using Kitbag.Domain;
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
            statusRepository.Create(new Status {CreatedDate = DateTime.Now, Status1 = message, People = new List<Person> {user}});

            var hash = FormsAuthentication.HashPasswordForStoringInConfigFile(email.ToLower(), "MD5").ToLower();

            var imageUrl = string.Format(@"http://www.gravatar.com/avatar/{0}?s={1}&d=mm&r=g", hash, 50);
            Clients.All.broadcastMessage(ParseMessage(message), email, imageUrl, DateTime.Now.ToShortTimeString());
        }

        private static string ParseMessage(string message) { return HttpUtility.HtmlEncode(message).Replace("\n", "</br>"); }
    }
}