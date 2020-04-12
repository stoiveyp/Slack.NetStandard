namespace Slack.NetStandard
{
    public class PlainText : TextObject
    {
        public PlainText() { }

        public PlainText(string text):base(text)
        {
            
        }

        public override TextType Type => TextType.PlainText;
    }
}