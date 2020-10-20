using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.JsonConverters
{
    public abstract class SingleOrArrayConverter<TValue> : Newtonsoft.Json.JsonConverter
    {
        public bool AlwaysOutputArray { get; }

        protected SingleOrArrayConverter() : base() { }

        protected SingleOrArrayConverter(bool alwaysOutputArray)
        {
            AlwaysOutputArray = alwaysOutputArray;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            TValue[] list = null;
            if (value is TValue[] templist)
            {
                list = templist;
            }

            if (!AlwaysOutputArray)
            {
                if (list == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }

                if (list.Length == 1)
                {
                    serializer.Serialize(writer, list.First());
                    return;
                }
            }

            writer.WriteStartArray();

            if (list != null)
            {
                foreach (var listitem in list)
                {
                    serializer.Serialize(writer, OutputArrayItem(listitem));
                }
            }

            writer.WriteEndArray();

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var valueList = new List<TValue>();

            if (reader.TokenType == SingleToken)
            {
                ReadSingle(reader, serializer, valueList);
            }
            else
            {
                serializer.Populate(reader, valueList);
            }

            return valueList.ToArray();
        }

        protected abstract JsonToken SingleToken { get; }
        protected abstract void ReadSingle(JsonReader reader, JsonSerializer serializer, List<TValue> list);

        protected virtual object OutputArrayItem(TValue value)
        {
            return value;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TValue[]);
        }
    }
}
