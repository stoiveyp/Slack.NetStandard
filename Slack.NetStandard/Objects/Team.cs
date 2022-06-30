using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Objects
{
    public class Team : SlackId
    {
        [JsonProperty("domain", NullValueHandling = NullValueHandling.Ignore)]
        public string Domain { get; set; }

        [JsonProperty("email_domain", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailDomain { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Icon { get; set; }

        [JsonProperty("enterprise_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EnterpriseId { get; set; }

        [JsonProperty("enterprise_name", NullValueHandling = NullValueHandling.Ignore)]
        public string EnterpriseName { get; set; }

        [JsonProperty("default_channels", NullValueHandling = NullValueHandling.Ignore),AcceptedArray]
        public string[] DefaultChannels { get; set; }

        [JsonProperty("date_created", NullValueHandling = NullValueHandling.Ignore)]
        public long? DateCreated { get; set; }
    }
}
