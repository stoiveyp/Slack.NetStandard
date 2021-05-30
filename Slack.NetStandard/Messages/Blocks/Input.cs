using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Input:IMessageBlock
    {
        public Input(){}

        public Input(PlainText label, IMessageElement element)
        {
            Label = label;
            Element = element;
        }

        [JsonProperty("type")]
        public string Type => nameof(Input).ToLower();

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("label",NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Label { get; set; }

        [JsonProperty("element",NullValueHandling = NullValueHandling.Ignore)]
        public IMessageElement Element { get; set; }

        [JsonProperty("hint",NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Hint { get; set; }

        [JsonProperty("optional",NullValueHandling = NullValueHandling.Ignore)]
        public bool? Optional { get; set; }

        [JsonProperty("dispatch_action",NullValueHandling = NullValueHandling.Ignore)]
        public bool? DispatchAction { get; set; }
    }
}
