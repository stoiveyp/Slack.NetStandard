using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.WebApi.Admin
{
    public class AllowListRequest
    {
        [JsonProperty("trusted_cidr", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> TrustedCidr { get; set; } = new();

        [JsonProperty("trusted_asns", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> TrustedAsn { get; set; } = new();

        public bool ShouldSerializeTrustedCidr() => TrustedCidr?.Any() ?? false;
        public bool ShouldSerializeTrustedAsn() => TrustedAsn?.Any() ?? false;
    }
}
