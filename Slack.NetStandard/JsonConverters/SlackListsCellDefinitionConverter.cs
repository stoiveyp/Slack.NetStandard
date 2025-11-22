using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.SlackLists;
using Slack.NetStandard.WebApi.SlackLists.CellDefinition;
using System;
using System.Collections.Generic;

namespace Slack.NetStandard.JsonConverters
{
    public class SlackListsCellDefinitionConverter:JsonConverter<SlackListsCellDefinition>
    {
        public override bool CanWrite => false;

        public override SlackListsCellDefinition ReadJson(JsonReader reader, Type objectType, SlackListsCellDefinition existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            foreach(var key in ISlackListsCellDefinitionLookup.Keys)
            {
                if (jObject.ContainsKey(key))
                {
                    var known = Activator.CreateInstance(ISlackListsCellDefinitionLookup[key]);
                    serializer.Populate(jObject.CreateReader(), known);
                    return known as SlackListsCellDefinition;
                }
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, SlackListsCellDefinition value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public static Dictionary<string, Type> ISlackListsCellDefinitionLookup = new()
        {
            {"rich_text", typeof(RichTextCellDefinition) },
            {"message", typeof(MessageCellDefinition) },
            {"number", typeof(NumberCellDefinition) },
            {"select", typeof(SelectCellDefinition) },
            {"date", typeof(DateCellDefinition) },
            {"user", typeof(UserCellDefinition) },
            {"channel", typeof(ChannelCellDefinition) },
            {"attachment", typeof(AttachmentCellDefinition) },
            {"checkbox", typeof(CheckboxCellDefinition) },
            {"email", typeof(EmailCellDefinition) },
            {"phone", typeof(PhoneCellDefinition) },
            {"rating", typeof(RatingCellDefinition) },
            {"timestamp", typeof(TimestampCellDefinition) },
            {"link", typeof(LinkCellDefinition) },
            {"reference", typeof(ReferenceCellDefinition) },
        };
    }
}
