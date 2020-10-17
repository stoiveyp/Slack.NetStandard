using System.Security.Principal;

namespace Slack.NetStandard.Messages.TextEntities
{
    public class Subteam : TextEntity
    {
        public Subteam(string subteamId)
        {
            SubteamId = subteamId;
        }

        public string SubteamId { get; }

        public static string Text(string teamId)
        {
            return $"<!subteam^{teamId}>";
        }
    }
}