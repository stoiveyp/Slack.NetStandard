using Newtonsoft.Json;

namespace Slack.NetStandard.Objects;

public class EnterpriseUser
{
    [JsonProperty("id")]
    public string ID { get; set; }

    [JsonProperty("enterprise_id", NullValueHandling = NullValueHandling.Ignore)]
    public string EnterpriseId { get; set; }

    [JsonProperty("enterprise_name", NullValueHandling = NullValueHandling.Ignore)]
    public string EnterpriseName { get; set; }

    [JsonProperty("is_admin", NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsAdmin { get; set; }

    [JsonProperty("is_owner", NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsOwner { get; set; }

    [JsonProperty("is_primary_owner", NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsPrimaryOwner { get; set; }

    [JsonProperty("teams", NullValueHandling = NullValueHandling.Ignore), AcceptedArray]
    public string[] Teams { get; set; }
}