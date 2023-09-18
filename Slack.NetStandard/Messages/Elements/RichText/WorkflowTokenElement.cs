using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements.RichText;

public class WorkflowTokenElement : RichTextElement
{
    public const string ElementName = "workflowtoken";

    [JsonProperty("id",NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("property",NullValueHandling = NullValueHandling.Ignore)]
    public string Property { get; set; }

    [JsonProperty("data_type",NullValueHandling = NullValueHandling.Ignore)]
    public string DataType { get; set; }
}