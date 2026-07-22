using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.Objects.WorkObjects.Fields
{
    public class SelectEditOptions
    {
        [JsonProperty("current_value")]
        public string CurrentValue { get; set; }

        [JsonProperty("fetch_options_dynamically")]
        public bool? FetchOptionsDynamically { get; set; }

        [JsonProperty("current_values")]
        public List<string> CurrentValues { get; set; } = new();

        [JsonProperty("static_options")]
        public List<Option> StaticOptions { get; set; } = new();

        public bool ShouldSerializeCurrentValues() => CurrentValues?.Any() ?? false;
        public bool ShouldSerializeStaticOptions() => StaticOptions?.Any() ?? false;
    }
}