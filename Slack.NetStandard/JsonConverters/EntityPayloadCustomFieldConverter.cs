using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Objects.WorkObjects;
using Slack.NetStandard.Objects.WorkObjects.EntityTypes;
using System;
using System.Collections.Generic;

namespace Slack.NetStandard.JsonConverters
{
    internal class EntityPayloadCustomFieldConverter : JsonConverter<EntityPayloadCustomField>
    {
        public override bool CanWrite => false;
        public override EntityPayloadCustomField ReadJson(JsonReader reader, Type objectType, EntityPayloadCustomField existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var val = jObject.Value<string>("type");
            if (EntityPayloadCustomFieldLookup.ContainsKey(val))
            {
                var known = Activator.CreateInstance(EntityPayloadCustomFieldLookup[val]);
                serializer.Populate(jObject.CreateReader(), known);
                return known as EntityPayloadCustomField;
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, EntityPayloadCustomField value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public static Dictionary<string, Type> EntityPayloadCustomFieldLookup = new()
        {
            {"slack#/entities/file", typeof(FileEntity) },
            {"slack#/entities/task", typeof(TaskEntity) },
            {"slack#/entities/incident", typeof(IncidentEntity) },
            {"slack#/entities/content_item", typeof(ContentItemEntity) }
        };
    }
}
