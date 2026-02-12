using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Objects.WorkObjects.Fields;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.JsonConverters
{
    public class BooleanOptionConverter : JsonConverter<BooleanOptions>
    {
        public override bool CanWrite => false;

        public override BooleanOptions ReadJson(JsonReader reader, Type objectType, BooleanOptions existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var componentType = jObject.Value<string>("type");
            var booleanOptions = componentType switch
            {
                CheckboxBooleanOptions.TypeName => new CheckboxBooleanOptions(),
                TextBooleanOptions.TypeName => new TextBooleanOptions(),
                _ => new BooleanOptions()
            };

            serializer.Populate(jObject.CreateReader(), booleanOptions);
            return booleanOptions;
        }

        public override void WriteJson(JsonWriter writer, BooleanOptions value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
