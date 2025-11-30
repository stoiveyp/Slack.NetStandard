using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class UnfurlMetadata
    {
        [JsonProperty("entities")]
        public List<UnfurlMetadataEntity> Entities { get; set; } = [];

        public bool ShouldSerializeEntities() => Entities?.Any() ?? false;
    }
}