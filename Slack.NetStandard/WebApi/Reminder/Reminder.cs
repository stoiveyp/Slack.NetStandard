using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Reminder
{
    public class Reminder
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("creator",NullValueHandling = NullValueHandling.Ignore)]
        public string Creator { get; set; }

        [JsonProperty("user",NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("text",NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("recurring",NullValueHandling = NullValueHandling.Ignore)]
        public bool? Recurring { get; set; }

        [JsonProperty("time",NullValueHandling = NullValueHandling.Ignore)]
        public long? Time { get; set; }

        [JsonProperty("complete_ts",NullValueHandling = NullValueHandling.Ignore)]
        public long? Complete { get; set; }
    }
}
