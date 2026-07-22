using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.WebApi.Canvases
{
    internal class CanvasEditRequest
    {
        [JsonProperty("canvas_id")]
        public string CanvasId { get; set; }

        [JsonProperty("changes")]
        public List<CanvasOperation> Changes { get; set; } = new();

        public bool ShouldSerializeChanges() => true;
    }
}
