using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Canvases
{
    internal class CanvasesCreateRequest
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("document_content", NullValueHandling = NullValueHandling.Ignore)]
        public CanvasContent Content { get; set; }
    }
}
