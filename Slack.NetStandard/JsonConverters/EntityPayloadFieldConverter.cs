using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Objects.WorkObjects;
using Slack.NetStandard.Objects.WorkObjects.Fields;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.JsonConverters
{
    public class EntityPayloadFieldConverter : JsonConverter<EntityPayloadField>
    {
        public override bool CanWrite => false;

        public override EntityPayloadField ReadJson(JsonReader reader, Type objectType, EntityPayloadField existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            if (TryHandleObject(jObject, serializer, out var field))
            {
                return field;
            }
            else if (jObject.ContainsKey("value") && jObject["value"] is JArray)
            {
                var arr = jObject.Value<JArray>("value");
                var resultOutput = arr.Select(a => (a is JObject j && TryHandleObject(j, serializer, out var arrField)) ? arrField : null).Where(a => a != null);
                return new ArrayField(resultOutput);
            }

            var unknownType = new CustomField();
            serializer.Populate(jObject.CreateReader(), unknownType);
            return unknownType;
        }

        public static bool TryHandleObject(JObject jObject, JsonSerializer serializer, out EntityPayloadField field)
        {
            if (jObject.TryGetValue("type", out var typeToken) && !string.IsNullOrEmpty(typeToken.Value<string>()))
            {
                if (EntityPayloadFieldLookup.TryGetValue(typeToken.Value<string>(), out var targetType))
                {
                    var targetObject = (EntityPayloadField)Activator.CreateInstance(targetType);
                    serializer.Populate(jObject.CreateReader(), targetObject);
                    field = targetObject;
                    return true;
                }

                var unknownType = new CustomField();
                serializer.Populate(jObject.CreateReader(), unknownType);
                field = unknownType;
                return true;
            }
            else if (jObject.ContainsKey("value"))
            {
                field = jObject["value"].Type switch
                {
                    JTokenType.Boolean => new BooleanField(jObject.Value<bool>("value")),
                    JTokenType.Integer => new IntegerField(jObject.Value<int>("value")),
                    _ => new StringField(jObject.Value<string>("value"))
                };
                return true;
            }

            field = null;
            return false;
        }

        public override void WriteJson(JsonWriter writer, EntityPayloadField value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public static Dictionary<string, Type> EntityPayloadFieldLookup = new()
        {
            {StringField.TypeName, typeof(StringField) },
            {IntegerField.TypeName, typeof(IntegerField) },
            {BooleanField.TypeName, typeof(BooleanField) },
            {ArrayField.TypeName, typeof(ArrayField) },
            {UserField.TypeName, typeof(UserField) },
            {ChannelField.TypeName, typeof(ChannelField) },
            {TimestampField.TypeName, typeof(TimestampField) },
            {DateField.TypeName, typeof(DateField) },
            {ImageField.TypeName, typeof(ImageField) },
            {EntityRefField.TypeName, typeof(EntityRefField) },
            {LinkField.TypeName, typeof(LinkField) },
            {EmailField.TypeName, typeof(EmailField) }
        };
    }
}
