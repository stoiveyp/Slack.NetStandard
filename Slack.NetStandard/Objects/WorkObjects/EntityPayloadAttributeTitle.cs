namespace Slack.NetStandard.Objects.WorkObjects
{
    public class EntityPayloadAttributeTitle
    {
        public EntityPayloadAttributeTitle() { }
        public EntityPayloadAttributeTitle(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
    }
}