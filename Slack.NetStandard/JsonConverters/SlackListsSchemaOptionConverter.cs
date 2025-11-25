using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.SlackLists;
using Slack.NetStandard.WebApi.SlackLists.SchemaOptions;
using System;
using System.Collections.Generic;

namespace Slack.NetStandard.JsonConverters
{
    public class SlackListsSchemaOptionConverter : JsonConverter<SlackListsSchemaOption>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, SlackListsSchemaOption value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override SlackListsSchemaOption ReadJson(JsonReader reader, Type objectType, SlackListsSchemaOption existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            foreach (var key in SlackListsSchemaOptionLookup.Keys)
            {
                if (jObject.ContainsKey(key))
                {
                    var known = Activator.CreateInstance(SlackListsSchemaOptionLookup[key]);
                    serializer.Populate(jObject.CreateReader(), known);
                    return known as SlackListsSchemaOption;
                }
            }

            var defaultCell = new SlackListsSchemaOption();
            serializer.Populate(jObject.CreateReader(), defaultCell);
            return defaultCell;
        }

        public static Dictionary<string, Type> SlackListsSchemaOptionLookup = new()
        {
            {"choices", typeof(ChoiceOptions) },
            {"date_format", typeof(DateFormatOptions) },
            {"emoji", typeof(EmojiOptions) },
            {"precision", typeof(NumberOptions) },
            {"default_value_typed", typeof(DefaultValueOptions) },
        };
    }
}
