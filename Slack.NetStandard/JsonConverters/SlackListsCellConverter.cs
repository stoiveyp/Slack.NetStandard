using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.SlackLists;
using System;
using System.Collections.Generic;

namespace Slack.NetStandard.JsonConverters
{
    public class SlackListsCellConverter:JsonConverter<SlackListsCell>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, SlackListsCell value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override SlackListsCell ReadJson(JsonReader reader, Type objectType, SlackListsCell existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var componentType = jObject.Value<string>("type");
            if (string.IsNullOrWhiteSpace(componentType))
            {
                return null;
            }
            var target = GetComponent(componentType);
            if (target == null)
            {
                throw new ArgumentOutOfRangeException($"MessageBlock type {componentType} not supported");
            }
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public static Dictionary<string, Type> SlackListsCellLookup = new()
        {
            
        };

        private SlackListsCell GetComponent(string type)
        {
            return (SlackListsCell)(
                SlackListsCellLookup.ContainsKey(type)
                    ? Activator.CreateInstance(SlackListsCellLookup[type])
                    : new SlackListsCell());
        }
    }
}
