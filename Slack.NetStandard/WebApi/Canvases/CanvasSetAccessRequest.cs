using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.WebApi.Canvases
{
    public class CanvasSetAccessRequest:CanvasAccessRequest
    {
        public CanvasSetAccessRequest() { }
        public CanvasSetAccessRequest(string canvasId, CanvasAccessLevel accessLevel)
        {
            CanvasId = canvasId;
            AccessLevel = accessLevel;
        }

        [JsonProperty("access_level")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CanvasAccessLevel AccessLevel { get; set; }
    }
}
