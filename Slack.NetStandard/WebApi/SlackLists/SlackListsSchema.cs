using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListsSchema
    {
        public SlackListsSchema() { }

        public SlackListsSchema(string key, string name, string type)
        {
            Key = key;
            Name = name;
            Type = type;
        }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("is_primary_column", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPrimaryColumn { get; set; }

        [JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
        public SlackListsSchemaOption Options { get; set; }
    }
}
