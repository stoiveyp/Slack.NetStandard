using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.WebApi.Calls
{
    public class Call
    {
        public Call() { }

        public Call(string externalUniqueId, string joinUrl)
        {
            ExternalUniqueId = externalUniqueId;
            JoinUrl = joinUrl;
        }

        [JsonProperty("id",NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("external_unique_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalUniqueId { get; set; }

        [JsonProperty("join_url", NullValueHandling = NullValueHandling.Ignore)]
        public string JoinUrl { get; set; }

        [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [JsonProperty("date_start", NullValueHandling = NullValueHandling.Ignore)]
        public long? DateStart { get; set; }

        [JsonProperty("desktop_app_join_url", NullValueHandling = NullValueHandling.Ignore)]
        public string DesktopAppJoinUrl { get; set; }

        [JsonProperty("external_display_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalDisplayId { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("users", NullValueHandling = NullValueHandling.Ignore)]
        public List<CallUser> Users { get; set; } = new();

        public bool ShouldSerializeUsers() => Users?.Any() ?? false;
    }
}
