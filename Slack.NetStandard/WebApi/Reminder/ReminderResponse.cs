using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Reminder
{
    public class ReminderResponse : WebApiResponse
    {
        [JsonProperty("reminder",NullValueHandling = NullValueHandling.Ignore)]
        public Reminder Reminder { get; set; }
    }
}