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
    }

    public class DateMention : TextEntity
    {
        public DateMention(string[] datePieces)
        {
            if (datePieces.Length > 1)
            {
                Timestamp = long.Parse(datePieces[0]);
            }

            if (datePieces.Length > 2)
            {
                Token = datePieces[1];
            }

            if (datePieces.Length > 3)
            {
                OptionalLink = datePieces[2];
            }
        }

        public long Timestamp { get; }

        public string Token { get; }

        public string OptionalLink { get; }
    }
}