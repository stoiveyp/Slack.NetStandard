using Slack.NetStandard.Objects;

namespace Slack.NetStandard.Messages.TextEntities
{
    public class UserMention:TextEntity
    {
        public UserMention(string userId)
        {
            UserId = userId;
        }
        public string UserId { get; }

        public static string Text(string userId)
        {
            return $"<@{userId}>";
        }
    }
}
