using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class DateFormatOptions : SlackListsSchemaOption
    {
        [JsonProperty("date_format")]
        public string DateFormat { get; set; }
    }
}