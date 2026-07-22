using Newtonsoft.Json;
using Slack.NetStandard.Objects.WorkObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.WebApi.Entity
{
    public class PresentDetailsRequest
    {
        [JsonProperty("trigger_id")]
        public string TriggerId { get; set; }

        [JsonProperty("user_auth_required", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UserAuthRequired { get; set; }

        [JsonProperty("user_auth_url", NullValueHandling = NullValueHandling.Ignore)]
        public string UserAuthUrl { get; set; }

        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public MetadataEntity Metadata { get; set; }

        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public EntityError Error { get; set; }
    }
}
