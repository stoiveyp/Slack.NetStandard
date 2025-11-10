using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages.Blocks;
using System;

namespace Slack.NetStandard.JsonConverters
{
    internal class TableRowConverter : JsonConverter<TableRow>
    {
        public override TableRow ReadJson(JsonReader reader, Type objectType, TableRow existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var tableRow = new TableRow();
            reader.Read();
            while(reader.TokenType != JsonToken.EndArray)
            {
                var jObject = JObject.Load(reader);
                if(jObject.Value<string>("type") == "raw_text")
                {
                    tableRow.Items.Add(new TableRowRawText(jObject.Value<string>("text")));
                }
                else if(jObject.Value<string>("type") == "rich_text")
                {
                    var richItem = new RichText();
                    serializer.Populate(jObject.CreateReader(), richItem);
                    tableRow.Items.Add(new TableRowRichText(richItem));
                }

                reader.Read();
            }

            return tableRow;
        }

        public override void WriteJson(JsonWriter writer, TableRow value, JsonSerializer serializer)
        {
            writer.WriteStartArray();

            foreach(var item in value.Items)
            {
                serializer.Serialize(writer, item.GenerateRowItem());
            }

            writer.WriteEndArray();
        }
    }
}
