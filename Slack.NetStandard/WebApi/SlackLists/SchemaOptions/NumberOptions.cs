using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class NumberOptions : SlackListsSchemaOption
    {
        [JsonProperty("precision", NullValueHandling = NullValueHandling.Ignore)]
        public int? Precision { get; set; }
    }
}