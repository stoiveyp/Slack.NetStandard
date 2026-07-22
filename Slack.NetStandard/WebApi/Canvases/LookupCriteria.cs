using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.WebApi.Canvases
{
    public class LookupCriteria
    {
        [JsonProperty("section_types")]
        public List<string> SectionTypes { get; set; } = new();

        [JsonProperty("contains_text")]
        public string ContainsText { get; set; }

        public bool ShouldSerializeSectionTypes() => true;
    }
}