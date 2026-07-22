using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slack.NetStandard.Objects.WorkObjects;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.WebApi.Entity
{
    public class EntityError
    {
        [JsonProperty("custom_message", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomMessage { get; set; }

        [JsonProperty("custom_title", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomTitle { get; set; }

        [JsonProperty("message_format", NullValueHandling = NullValueHandling.Ignore)]
        public string MessageFormat { get; set; }

        [JsonProperty("actions", NullValueHandling = NullValueHandling.Ignore)]
        public List<EntityPayloadAction> Actions { get; set; } = new();

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public EntityErrorStatus? Status { get; set; }


        public bool ShouldSerializeActions() => Actions?.Any() ?? false;
    }
}