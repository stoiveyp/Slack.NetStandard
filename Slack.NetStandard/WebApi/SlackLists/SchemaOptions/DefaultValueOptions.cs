using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class DefaultValueOptions : SlackListsSchemaOption
    {
        [JsonProperty("default_value_typed")]
        public DefaultValueTypedOptions DefaultValueTyped {get;set;} = new();
    }
}