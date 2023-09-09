using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class WorkflowBillingResultPayload
{
    [JsonProperty("is_billing_excluded")]
    public bool? IsBillingExcluded { get; set; }

    [JsonProperty("billing_reason")]
    public string BillingReason { get; set; }
}