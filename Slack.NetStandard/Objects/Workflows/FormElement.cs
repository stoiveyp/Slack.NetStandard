using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Objects.Workflows
{
    [JsonConverter(typeof(FormElementConverter))]
    public class FormElement
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name",NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("description",NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("hint",NullValueHandling = NullValueHandling.Ignore)]
        public string Hint { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }

    public class StructFormElement<T> : FormElement where T:struct
    {
        [JsonProperty("default",NullValueHandling = NullValueHandling.Ignore)]
        public T? Default { get; set; }

        [JsonProperty("examples", NullValueHandling = NullValueHandling.Ignore)]
        public List<T> Examples { get; set; } = new();

        public bool ShouldSerializeExamples() => Examples?.Any() ?? false;
    }

    public class TypedFormElement<T> : FormElement where T : class
    {
        [JsonProperty("default", NullValueHandling = NullValueHandling.Ignore)]
        public T Default { get; set; }

        [JsonProperty("examples", NullValueHandling = NullValueHandling.Ignore)]
        public List<T> Examples { get; set; } = new();

        public bool ShouldSerializeExamples() => Examples?.Any() ?? false;
    }
}
