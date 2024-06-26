using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Canvases.Operations;

public class InsertBefore : CanvasOperation
{
    public InsertBefore() : base(CanvasOperationType.InsertBefore) { }

    [JsonProperty("document_content")]
    public CanvasContent DocumentContent { get; set; }

    [JsonProperty("section_id")]
    public string SectionId { get; set; }
}
