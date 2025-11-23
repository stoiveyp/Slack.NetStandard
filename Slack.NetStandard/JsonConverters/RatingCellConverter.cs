using Newtonsoft.Json;

namespace Slack.NetStandard.JsonConverters
{
    public class RatingCellConverter : SingleAsArrayConverter<int>
    {
        public override JsonToken IdentityToken => JsonToken.Integer;

        public override int ReadSingle(JsonReader reader, JsonSerializer serializer)
        {
            return reader.ReadAsInt32().Value;
        }
    }
}
