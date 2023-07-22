using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class ActiveSessionDeviceInformation
{
    [JsonProperty("device_hardware",NullValueHandling = NullValueHandling.Ignore)]
    public string DeviceHardware { get; set; }

    [JsonProperty("os",NullValueHandling = NullValueHandling.Ignore)]
    public string OS { get; set; }

    [JsonProperty("os_version",NullValueHandling = NullValueHandling.Ignore)]
    public string OsVersion { get; set; }

    [JsonProperty("slack_client_version",NullValueHandling = NullValueHandling.Ignore)]
    public string SlackClientVersion { get; set; }

    [JsonProperty("ip",NullValueHandling = NullValueHandling.Ignore)]
    public string IP { get; set; }


}