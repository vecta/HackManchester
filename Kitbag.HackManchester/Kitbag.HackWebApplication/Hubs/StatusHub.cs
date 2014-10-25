using System;
using System.Web;
using System.Web.Security;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Kitbag.HackWebApplication.Hubs
{
    public class StatusHub : Hub
    {
        public void Send(string message)
        {
            // Convert emailID to lower-case
            var email = Context.User.Identity.Name;
            var emailId = email.ToLower();
            var hash = FormsAuthentication.HashPasswordForStoringInConfigFile(emailId, "MD5").ToLower();

            // build Gravatar Image URL
            var imageUrl = string.Format(@"http://www.gravatar.com/avatar/{0}?s={1}&d=mm&r=g", hash, 50);
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(message, email, imageUrl, DateTime.Now.ToShortTimeString());
        }
    }
}