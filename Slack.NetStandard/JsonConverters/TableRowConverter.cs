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
                var type = jObject.Value<string>("type");
                switch (type)
                {
                    case "raw_number":
                    {
                        var valueToken = jObject["value"];
                        var text = jObject.Value<string>("text");
                        if (valueToken != null)
                        {
                            switch (valueToken.Type)
                            {
                            case JTokenType.Integer:
                            {
                                var intVal = valueToken.Value<int>();
                                if (text != null)
                                    tableRow.Cells.Add(new RawNumberCell(intVal, text));
                                else
                                    tableRow.Cells.Add(new RawNumberCell(intVal));
                                break;
                            }
                            case JTokenType.Float:
                            {
                                var decVal = valueToken.Value<decimal>();
                                if (text != null)
                                    tableRow.Cells.Add(new RawNumberCell(decVal, text));
                                else
                                    tableRow.Cells.Add(new RawNumberCell(decVal));
                                break;
                            }
                            default:
                            {
                                // value must be numeric; attempt a decimal conversion for other numeric-like tokens
                                var decVal = valueToken.Value<decimal>();
                                if (text != null) tableRow.Cells.Add(new RawNumberCell(decVal, text));
                                else tableRow.Cells.Add(new RawNumberCell(decVal));
                                break;
                            }
                            }
                        }

                        break;
                    }
                    case "raw_text":
                    {
                        tableRow.Cells.Add(new RawTextCell(jObject.Value<string>("text")));
                        break;
                    }
                    case "rich_text":
                    {
                        var richItem = new RichText();
                        serializer.Populate(jObject.CreateReader(), richItem);
                        tableRow.Cells.Add(new RichTextCell(richItem));
                        break;
                    }
                }

                reader.Read();
            }

            return tableRow;
        }

        public override void WriteJson(JsonWriter writer, TableRow value, JsonSerializer serializer)
        {
            writer.WriteStartArray();

            foreach(var item in value.Cells)
            {
                serializer.Serialize(writer, item.GenerateCell());
            }

            writer.WriteEndArray();
        }
    }
}
