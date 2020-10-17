namespace Slack.NetStandard.Messages.TextEntities
{
    public class SpecialMention : TextEntity
    {
        public SpecialMention(string mention)
        {
            Mention = mention;
        }

        public string Mention { get; }

        public const string Here = "<!here>";
        public const string Channel = "<!channel>";
        public const string Everyone = "<!everyone>";
    }
}