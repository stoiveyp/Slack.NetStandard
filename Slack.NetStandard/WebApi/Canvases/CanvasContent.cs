using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Canvases
{
    public abstract class CanvasContent
    {
        [JsonProperty("type")]
        public abstract string Type { get; }
    }
}
