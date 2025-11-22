using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.SlackLists;
using Slack.NetStandard.WebApi.SlackLists.CellDefinition;
using System;
using System.Collections.Generic;

namespace Slack.NetStandard.JsonConverters
{
    public class SlackListsCellDefinitionConverter:JsonConverter<SlackListCellDefinition>
    {
        public override bool CanWrite => false;

        public override SlackListCellDefinition ReadJson(JsonReader reader, Type objectType, SlackListCellDefinition existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            foreach(var key in ISlackListsCellDefinitionLookup.Keys)
            {
                if (jObject.ContainsKey(key))
                {
                    return jObject.ToObject(ISlackListsCellDefinitionLookup[key], serializer) as SlackListCellDefinition;
                }
            }

            return jObject.ToObject<SlackListCellDefinition>(serializer);
        }

        public override void WriteJson(JsonWriter writer, SlackListCellDefinition value, JsonSerializer serializer)
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
