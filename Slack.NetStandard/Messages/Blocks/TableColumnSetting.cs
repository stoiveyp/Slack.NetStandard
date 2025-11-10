using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks
{
    public class TableColumnSetting
    {
        [JsonProperty("is_wrapped", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsWrapped { get; set; }

        [JsonProperty("align", NullValueHandling = NullValueHandling.Ignore)]
        public string Align { get; set; }
    }
}