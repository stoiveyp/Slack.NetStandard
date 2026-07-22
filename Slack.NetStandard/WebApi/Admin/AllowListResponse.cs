using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class AllowListResponse : WebApiResponse
{
    [JsonProperty("trusted_cidr",NullValueHandling = NullValueHandling.Ignore)]
    public string[] TrustedCidr { get; set; }

    [JsonProperty("trusted_asns",NullValueHandling = NullValueHandling.Ignore)]
    public int[] TrustedAsn { get; set; }
}