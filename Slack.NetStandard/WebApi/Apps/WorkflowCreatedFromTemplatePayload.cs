using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class WorkflowCreatedFromTemplatePayload
{
    [JsonProperty("template_id")]
    public string TemplateId { get; set; }

    [JsonProperty("date_created")]
    public long DateCreated { get; set; }
}