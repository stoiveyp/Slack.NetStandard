namespace Slack.NetStandard.Messages.TextEntities
{
    public class ChannelMention : TextEntity
    {
        public ChannelMention(string channelId)
        {
            ChannelId = channelId;
        }

        public string ChannelId { get; }

        public static string Text(string channelId)
        {
            return $"<#{channelId}>";
        }
    }
}