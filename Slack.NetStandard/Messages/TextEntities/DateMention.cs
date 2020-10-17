namespace Slack.NetStandard.Messages.TextEntities
{
    public class DateMention : TextEntity
    {
        public DateMention(string[] datePieces)
        {
            if (datePieces.Length > 0)
            {
                Timestamp = long.Parse(datePieces[0]);
            }

            if (datePieces.Length > 1)
            {
                Token = datePieces[1];
            }

            if (datePieces.Length > 2)
            {
                OptionalLink = datePieces[2];
            }
        }

        public long Timestamp { get; }

        public string Token { get; }

        public string OptionalLink { get; }

        public static string Text(long timestamp, string token, string fallbackText, string url = null)
        {
            if (!string.IsNullOrWhiteSpace(url))
            {
                return $"<!date^{timestamp}^{token}^{url}|{fallbackText}>";
            }

            return $"<!date^{timestamp}^{token}|{fallbackText}>";
        }
    }
}