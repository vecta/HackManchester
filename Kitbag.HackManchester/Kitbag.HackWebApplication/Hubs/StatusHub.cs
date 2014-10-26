using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;
using Clockwork;
using Kitbag.Database;
using Kitbag.Domain;
using Kitbag.HackWebApplication.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Messaging;

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

            // send copy of status message using sms.
            ShareStatusMsgAsTextToGroup(message, user, ref personRepository);

            var displayStatus = new DisplayStatus(status);
            var hash = FormsAuthentication.HashPasswordForStoringInConfigFile(displayStatus.Email.ToLower(), "MD5").ToLower();

            // display gravatar profile pics
            var imageUrl = string.Format(@"http://www.gravatar.com/avatar/{0}?s={1}&d=mm&r=g", hash, 50);
            Clients.All.broadcastMessage(ParseMessage(displayStatus.Message), displayStatus.Name, imageUrl,displayStatus.TimeStamp, displayStatus.Type);
        }

        private static string ParseMessage(string message) { return HttpUtility.HtmlEncode(message).Replace("\n", "</br>"); }

        private static void ShareStatusMsgAsTextToGroup(string message, Person user, ref PersonRepository personRepository)
        {

            // reverse actual status message
            var reversedUserName = GetReversedMessage(user.FirstName);  // GetUserNameInBinary(user.FirstName); - get username in binary
            var reversedMessage = GetReversedMessage(message);
            // build sms text - binary + normal + reversed
            var newMessage = reversedUserName + " added new status " + reversedMessage;

            // truncate message if exceeds max sms length
            const int maxTotalSmsLength = 912;
            if (newMessage.Length >= maxTotalSmsLength)
            {
                newMessage = newMessage.Substring(0, maxTotalSmsLength);
            }

            // get list of other users in group
            var allUsersInGroup = personRepository.GetByOrgansation(3);

            // get their phone numbers                
            //var phoneNumbersToSendItTo =
            //    allUsersInGroup.Where(p => p.PhoneNumber != null && p.PhoneNumber != user.PhoneNumber)
            //        .Select(groupUser => groupUser.PhoneNumber)
            //        .ToList();

            foreach (var groupUser in allUsersInGroup)
            {
                if (groupUser.PhoneNumber != null && user.PhoneNumber != null)
                {
                    if (groupUser.PhoneNumber != user.PhoneNumber)
                    {
                        // send the sms using ClockWorkSMS API
                        SendSmsMessage(groupUser.PhoneNumber, newMessage);
                    }
                }
            }

        }

        private static string GetUserNameInBinary(string userName)
        {
            if (userName == null) return userName;
            return userName.Aggregate(string.Empty, (current, ch) => current + Convert.ToString((int) ch, 2));
        }

        private static string GetReversedMessage(string message)
        {
            if (message == null) return "";
            var reversedMessage = "";
            var array = message.ToCharArray();
            Array.Reverse(array);
            reversedMessage = new String(array);
            return reversedMessage;
        }

        public static string SendSmsMessage(string recipient, string message)
        {
            const string apiKey = "9538a858a40ce2cb59cdc4429de702625f73af4f";

            try
            {
                var api = new Clockwork.API(apiKey);
                var mobileNumber = CleanupInvalidTelephoneChars(recipient);
                var result = api.Send(new SMS { To = mobileNumber, Message = message });

                if (result.Success)
                {
                    return string.Format("SMS sent to {0}, Clockword ID: {1}", result.SMS.To, result.ID);
                }
                else
                {
                    return string.Format("SMS to {0},  failed, Clockwork Error: {1} {2}", result.ErrorCode,
                                          result.ErrorMessage, result.SMS.To);
                }
            }
            catch (APIException apiEx)
            {
                // Wrong user credentials
                return string.Format("API Exception - Incorrect Credentials:  {0}", apiEx.Message);
            }
            catch (WebException webEx)
            {
                // Clockwork api - Server time-out
                return string.Format("Web Exception - Server Timeout: {0}", webEx.Message);
            }
            catch (ArgumentException argEx)
            {
                // Arguments invalid - username etc not supplied
                return string.Format("Argument Exception - Server Timeout: {0}", argEx.Message);
            }
            catch (Exception ex)
            {
                // Unknown error - inspect error message
                return string.Format("Unknown Exception: {0}", ex.Message);
            }
        }

        private static string CleanupInvalidTelephoneChars(string telephoneNumber)
        {
            var cleanedUpTelephoneNumber = new StringBuilder();
            cleanedUpTelephoneNumber.Append(telephoneNumber);
            cleanedUpTelephoneNumber.Replace("+", "");
            cleanedUpTelephoneNumber.Replace("-", "");
            cleanedUpTelephoneNumber.Replace(" ", "");
            cleanedUpTelephoneNumber.Replace("_", "");
            cleanedUpTelephoneNumber.Replace("@", "");
            return cleanedUpTelephoneNumber.ToString();
        }
    
    }

}