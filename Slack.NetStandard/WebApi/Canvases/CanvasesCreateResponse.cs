using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Canvases
{
    public class CanvasesCreateResponse:WebApiResponse
    {
        [JsonProperty("canvas_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CanvasId { get; set; }
    }
}
