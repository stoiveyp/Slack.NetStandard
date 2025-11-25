using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists
{
    [JsonConverter(typeof(SlackListsSchemaOptionConverter))]
    public class SlackListsSchemaOption
    {
        [JsonProperty("show_member_name", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowMemberName { get; set; }

        [JsonProperty("notify_users", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NotifyUsers { get; set; }

        [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields{ get; set; } = new();
    }
}