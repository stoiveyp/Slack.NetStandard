using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi
{
    public class Team:SlackId
    {
        [JsonProperty("domain",NullValueHandling = NullValueHandling.Ignore)]
        public string Domain { get; set; }

        [JsonProperty("email_domain",NullValueHandling = NullValueHandling.Ignore)]
        public string EmailDomain { get; set; }

        [JsonProperty("icon",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,string> Icon { get; set; }

        [JsonProperty("enterprise_id",NullValueHandling = NullValueHandling.Ignore)]
        public string EnterpriseId { get; set; }

        [JsonProperty("enterprise_name",NullValueHandling = NullValueHandling.Ignore)]
        public string EnterpriseName { get; set; }

        [JsonProperty("default_channels",NullValueHandling = NullValueHandling.Ignore)]
        public string[] DefaultChannels { get; set; }
    }
}