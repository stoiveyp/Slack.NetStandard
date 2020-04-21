using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Reminder
{
    internal class AddReminderRequest
    {
        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
}