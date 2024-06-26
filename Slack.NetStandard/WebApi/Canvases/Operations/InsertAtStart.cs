using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Canvases.Operations;

public class InsertAtStart : CanvasOperation
{
    public InsertAtStart() : base(CanvasOperationType.InsertAtStart) { }

    [JsonProperty("document_content")]
    public CanvasContent DocumentContent { get; set; }
}
