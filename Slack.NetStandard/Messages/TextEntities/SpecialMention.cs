namespace Slack.NetStandard.Messages.TextEntities
{
    public class SpecialMention : TextEntity
    {
        public SpecialMention(string mention)
        {
            Mention = mention;
        }

        public string Mention { get; }
    }
}