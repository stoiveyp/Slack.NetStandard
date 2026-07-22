using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.WebApi.SlackLists.SchemaOptions
{
    public class ChoiceOptions: SlackListsSchemaOption
    {
        [JsonProperty("choices")]
        public List<ChoiceOptionSchema> Choices { get; set; } = [];

        public bool ShouldSerializeChoices() => Choices?.Any() ?? false;
    }
}
