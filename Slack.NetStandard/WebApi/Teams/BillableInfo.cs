using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Teams
{
    public class BillableInfo
    {
        [JsonProperty("billing_active")]
        public bool BillingActive { get; set; }
    }
}