using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Canvases.Operations;

public class InsertAfter : CanvasOperation
{
    public InsertAfter() : base(CanvasOperationType.InsertAfter) { }

    [JsonProperty("document_content")]
    public CanvasContent DocumentContent { get; set; }

    [JsonProperty("section_id")]
    public string SectionId { get; set; }
}