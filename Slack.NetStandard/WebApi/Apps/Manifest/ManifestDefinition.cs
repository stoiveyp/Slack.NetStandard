using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps.Manifest
{
    public class ManifestDefinition
    {
        [JsonProperty("_metadata", NullValueHandling = NullValueHandling.Ignore)]
        public Metadata Metadata { get; set; }

        [JsonProperty("display_information")]
        public DisplayInformation DisplayInformation { get; set; }

        [JsonProperty("features",NullValueHandling = NullValueHandling.Ignore)]
        public Features Features { get; set; }

        [JsonProperty("oauth_config",NullValueHandling = NullValueHandling.Ignore)]
        public OAuthConfig OAuthConfig { get; set; }

        [JsonProperty("settings",NullValueHandling = NullValueHandling.Ignore)]
        public Settings Settings { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}