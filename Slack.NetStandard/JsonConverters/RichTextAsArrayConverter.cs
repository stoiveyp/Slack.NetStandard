using Newtonsoft.Json;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.JsonConverters
{
    public class RichTextAsArrayConverter: SingleAsArrayConverter<RichText>
    {
        public override RichText ReadSingle(JsonReader reader, JsonSerializer serializer)
        {
            reader.Read();
            var rt = new RichText();
            serializer.Populate(reader, rt);
            return rt;
        }
    }
}
