using Kitbag.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Kitbag.Library
{
    public class OneDiaryWrapper
    {
        public static async Task<List<Appointment>> TodaysAppointments()
        {
            //var appointments = new List<string>();

            string requestUrl = "https://api.onediary.com/v1/events?from=2014-10-26&to=2014-10-27&tzid=Europe/London";

            var httpClient = new System.Net.Http.HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer k53bD74ezjb9tTwQrViMIjtNVavM07ma");
            var content = await httpClient.GetStringAsync(requestUrl);

            var appointments = new JavaScriptSerializer().Deserialize<Appointments>(content);

            return appointments.events;
        }
    }

    public class Appointments
    {
        public List<Appointment> events {get;set;}
    }
    
}
