using Kitbag.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            string requestUrl = "https://api.onediary.com/v1/events?from=2014-10-26&to=2014-10-27&tzid=Europe/London";

            var httpClient = new System.Net.Http.HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer k53bD74ezjb9tTwQrViMIjtNVavM07ma");
            var content = await httpClient.GetStringAsync(requestUrl);

            var appointments = new JavaScriptSerializer().Deserialize<Appointments>(content);

            foreach (var @event in appointments.events)
            {
                if (@event.start.Length >= 20)
                {
                    //2014-10-26T09:00:00Z
                    var newDate = DateTime.ParseExact(@event.start,
                                  "yyyy-MM-ddTHH:mm:ssZ",
                                  CultureInfo.InvariantCulture);

                    @event.start = newDate.ToString("dd/MM/yyyy HH:mm:ss");
                }
            }

            return appointments.events;
        }
    }

    public class Appointments
    {
        public List<Appointment> events { get; set; }
    }

}
