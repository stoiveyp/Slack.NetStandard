using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.WebApi.Apps.Manifest;

public class Settings
{
    [JsonProperty("allowed_ip_address_ranges", NullValueHandling = NullValueHandling.Ignore)]
    public IList<string> AllowedIpAddressRanges { get; set; } = new List<string>();

    [JsonProperty("event_subscriptions",NullValueHandling = NullValueHandling.Ignore)]
    public EventSubscriptions EventSubscriptions { get; set; }

    [JsonProperty("interactivity",NullValueHandling = NullValueHandling.Ignore)]
    public Interactivity Interactivity { get; set; }

    [JsonProperty("socket_mode_enabled",NullValueHandling = NullValueHandling.Ignore)]
    public bool? SocketModeEnabled { get; set; }

    [JsonProperty("org_deploy_enabled", NullValueHandling = NullValueHandling.Ignore)]
    public bool? OrgDeployEnabled { get; set; }

    [JsonExtensionData]
    public Dictionary<string,object> OtherFields { get; set; }

    public bool ShouldSerializeAllowedIpAddressRanges() => AllowedIpAddressRanges?.Any() ?? false;
}