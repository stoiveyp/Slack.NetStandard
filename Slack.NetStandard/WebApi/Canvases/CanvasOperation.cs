using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.WebApi.Canvases
{
    [JsonConverter(typeof(CanvasOperationConverter))]
    public class CanvasOperation
    {
        public CanvasOperation(string operation)
        { Operation = operation; }

        [JsonProperty("operation")]
        public string Operation { get; private set; }
    }
}
