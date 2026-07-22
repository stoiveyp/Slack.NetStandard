using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Canvases.Operations;

public class InsertAtEnd : CanvasOperation
{
    public InsertAtEnd() : base(CanvasOperationType.InsertAtEnd) { }

    [JsonProperty("document_content")]
    public CanvasContent DocumentContent { get; set; }
}