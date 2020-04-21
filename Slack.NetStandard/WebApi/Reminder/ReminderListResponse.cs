using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Reminder
{
    public class ReminderListResponse : WebApiResponse
    {
        [JsonProperty("reminders", NullValueHandling = NullValueHandling.Ignore)]
        public Reminder[] Reminder { get; set; }
    }
}