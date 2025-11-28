using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class EmojiOptions : SlackListsSchemaOption
    {
        [JsonProperty("emoji", NullValueHandling = NullValueHandling.Ignore)]
        public string Emoji { get; set; }

        [JsonProperty("emoji_team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EmojiTeamId { get; set; }

        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
        public int? Max { get; set; }
    }
}