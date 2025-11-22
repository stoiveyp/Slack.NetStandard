using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.SlackLists;
using Slack.NetStandard.WebApi.SlackLists.Cells;
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

            foreach(var key in SlackListsCellLookup.Keys)
            {
                if (jObject.ContainsKey(key))
                {
                    return jObject.ToObject(SlackListsCellLookup[key], serializer) as SlackListsCell;
                }
            }

            return jObject.ToObject<SlackListsCell>(serializer);
        }

        public static Dictionary<string, Type> SlackListsCellLookup = new()
        {
            {"rich_text", typeof(RichTextCell) },
            {"message", typeof(MessageCell) },
            {"number", typeof(NumberCell) },
            {"select", typeof(SelectCell) },
            {"date", typeof(DateCell) },
            {"user", typeof(UserCell) },
            {"channel", typeof(ChannelCell) },
            {"attachment", typeof(AttachmentCell) },
            {"checkbox", typeof(CheckboxCell) },
            {"email", typeof(EmailCell) },
            {"phone", typeof(PhoneCell) },
            {"rating", typeof(RatingCell) },
            {"timestamp", typeof(TimestampCell) },
            {"link", typeof(LinkCell) },
            {"reference", typeof(ReferenceCell) },
        };
    }
}
