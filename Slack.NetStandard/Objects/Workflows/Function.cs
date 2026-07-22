using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.Objects.Workflows
{
    public class Function
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("callback_id",NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackId { get; set; }

        [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("description",NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("type",NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("input_parameters", NullValueHandling = NullValueHandling.Ignore)]
        public List<InputParameter> InputParameters { get; set; } = new();

        [JsonProperty("output_parameters", NullValueHandling = NullValueHandling.Ignore)]
        public List<OutputParameter> OutputParameters { get; set; } = new();

        [JsonProperty("app_id",NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        [JsonProperty("date_created",NullValueHandling = NullValueHandling.Ignore)]
        public long? DateCreated { get; set; }

        [JsonProperty("date_updated",NullValueHandling = NullValueHandling.Ignore)]
        public long? DateUpdated { get; set; }

        [JsonProperty("date_deleted",NullValueHandling = NullValueHandling.Ignore)]
        public long? DateDeleted { get; set; }

        public bool ShouldSerializeInputParameters() => InputParameters?.Any() ?? false;
        public bool ShouldSerializeOutputParameters() => OutputParameters?.Any() ?? false;
    }
}
