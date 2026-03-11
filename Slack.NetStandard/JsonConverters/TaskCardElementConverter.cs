using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages.Blocks;
using Slack.NetStandard.Messages.Elements;

namespace Slack.NetStandard.JsonConverters
{
    public class TaskCardElementConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var componentType = jObject.Value<string>("type");
            object target = GetComponent(componentType);
            if (target == null)
            {
                throw new ArgumentOutOfRangeException($"TaskCard element type {componentType} not supported");
            }
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public static Dictionary<string, Type> ITaskCardElementLookup = new()
        {
            {"url", typeof(TaskCardSource)}
        };

        private ITaskCardElement GetComponent(string type)
        {
            return (ITaskCardElement)(
                ITaskCardElementLookup.ContainsKey(type)
                    ? Activator.CreateInstance(ITaskCardElementLookup[type])
                    : null);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ITaskCardElement).IsAssignableFrom(objectType);
        }
    }
}
