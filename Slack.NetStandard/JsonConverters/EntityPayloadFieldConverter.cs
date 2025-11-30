using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Objects.WorkObjects;
using Slack.NetStandard.Objects.WorkObjects.EntityTypes;
using System;
using System.Collections.Generic;

namespace Slack.NetStandard.JsonConverters
{
    public class EntityPayloadFieldConverter : JsonConverter<EntityPayloadField>
    {
        public override bool CanWrite => false;

        public override EntityPayloadField ReadJson(JsonReader reader, Type objectType, EntityPayloadField existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var val = jObject.Value<string>("entity_type");
            if (EntityPayloadFieldLookup.ContainsKey(val))
            {
                var known = Activator.CreateInstance(EntityPayloadFieldLookup[val]);
                serializer.Populate(jObject.CreateReader(), known);
                return known as EntityPayloadField;
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, EntityPayloadField value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public static Dictionary<string, Type> EntityPayloadFieldLookup = new()
        {
            {"slack#/entities/file", typeof(FileEntity) },
            {"slack#/entities/task", typeof(TaskEntity) },
            {"slack#/entities/incident", typeof(IncidentEntity) },
            {"slack#/entities/content_item", typeof(ContentItemEntity) }
        };
    }
}
