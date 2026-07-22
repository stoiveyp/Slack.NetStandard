using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.SlackLists;
using Slack.NetStandard.WebApi.SlackLists.References;
using System;
using System.Collections.Generic;

namespace Slack.NetStandard.JsonConverters
{
    public class SlackListsReferenceConverter : JsonConverter<SlackListsReference>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, SlackListsReference value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override SlackListsReference ReadJson(JsonReader reader, Type objectType, SlackListsReference existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            foreach (var key in SlackListsReferenceLookup.Keys)
            {
                if (jObject.ContainsKey(key))
                {
                    var known = Activator.CreateInstance(SlackListsReferenceLookup[key]);
                    serializer.Populate(jObject.CreateReader(), known);
                    return known as SlackListsReference;
                }
            }

            var defaultReference = new SlackListsReference();
            serializer.Populate(jObject.CreateReader(), defaultReference);
            return defaultReference;
        }

        public static Dictionary<string, Type> SlackListsReferenceLookup = new()
        {
            {"list_record", typeof(ListReference) },
            {"message", typeof(MessageReference) },
            {"file", typeof(FileReference) },
            {"canvas_section", typeof(CanvasReference) }
        };
    }
}
