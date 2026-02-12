using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.Objects.WorkObjects.Fields;

public class ArrayField : EntityPayloadField
{
    public const string TypeName = "array";
    public override string Type => TypeName; 
    public ArrayField(IEnumerable<EntityPayloadField> value) { Value = value.ToList(); }
    public List<EntityPayloadField> Value { get; set; }

    [JsonProperty("item_type", NullValueHandling = NullValueHandling.Ignore)]
    public string ItemType { get; set; }
}