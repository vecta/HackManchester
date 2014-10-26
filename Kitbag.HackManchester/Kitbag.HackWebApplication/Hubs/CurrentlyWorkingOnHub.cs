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
    public class CurrentlyWorkingOnHub : Hub
    {
        public void Send(string message)
        {
            var email = Context.User.Identity.Name;

            var dbContext = new CwonData();
            var currentlyWorkingOnRepository = new Repository<CurrentlyWorkingOn>(dbContext);
            
            var personRepository = new PersonRepository(dbContext);
            var user = personRepository.GetByEmail(email);
            
            var currentlyWorkingOn = new CurrentlyWorkingOn {CreatedDate = DateTime.Now,  CurrentlyWorkingOn1 = "is currently working on " + message, People = new List<Person> {user}};
            currentlyWorkingOnRepository.Create(currentlyWorkingOn);

            var displayStatus = new DisplayCurrentlyWorkingOn(currentlyWorkingOn);
            var hash = FormsAuthentication.HashPasswordForStoringInConfigFile(displayStatus.Email.ToLower(), "MD5").ToLower();

            var imageUrl = string.Format(@"http://www.gravatar.com/avatar/{0}?s={1}&d=mm&r=g", hash, 50);
            Clients.All.broadcastMessage(ParseMessage(displayStatus.Message), displayStatus.Name, imageUrl,displayStatus.TimeStamp);
        }

        private static string ParseMessage(string message) { return HttpUtility.HtmlEncode(message).Replace("\n", "</br>"); }
    }
}