using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Canvases
{
    internal class CanvasSectionLookup
    {
        [JsonProperty("canvas_id")]
        public string CanvasId { get; set; }

        [JsonProperty("criteria")]
        public LookupCriteria Criteria { get; set; }
    }
}
