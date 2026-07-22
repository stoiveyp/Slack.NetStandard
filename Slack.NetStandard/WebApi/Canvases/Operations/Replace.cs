using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Canvases.Operations;

public class Replace : CanvasOperation
{
    public Replace(): base(CanvasOperationType.Replace) { }

    [JsonProperty("document_content")]
    public CanvasContent DocumentContent { get; set; }

    [JsonProperty("section_id", NullValueHandling = NullValueHandling.Ignore)]
    public string SectionId { get; set; }
}
