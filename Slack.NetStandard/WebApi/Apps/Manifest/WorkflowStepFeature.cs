using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps.Manifest;

public class WorkflowStepFeature
{
    [JsonProperty("name",NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("callback_id",NullValueHandling = NullValueHandling.Ignore)]
    public string CallbackId { get; set; }

    [JsonExtensionData]
    public Dictionary<string,object> OtherFields { get; set; }
}