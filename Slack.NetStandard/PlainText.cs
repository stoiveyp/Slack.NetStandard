using Newtonsoft.Json;

namespace Slack.NetStandard
{
    public class PlainText : TextObject
    {
        public static implicit operator PlainText(string text)
        {
            return new PlainText(text);
        }

        public PlainText() { }

        public PlainText(string text):base(text)
        {
            
        }

        [JsonIgnore]
        internal bool WasConvertedFromString { get; set; }

        public override TextType Type => TextType.PlainText;
    }
}