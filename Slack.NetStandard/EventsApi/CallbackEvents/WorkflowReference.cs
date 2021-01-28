using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class WorkflowReference
    {
        [JsonProperty("version_id")]
        public string VersionId { get; set; }

        [JsonProperty("app_steps")]
        public WorkflowStepReference[] AppSteps { get; set; }
    }
}