using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using Slack.NetStandard.Messages.TextEntities;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.Messages
{
    public static class TextParser
    {
        private static readonly Regex _regex;

        static TextParser()
        {
            _regex = new Regex("<(?<entity>.+?)>");
        }
        public static TextEntity[] FindEntities(string text)
        {
            return _regex.Matches(text).Cast<Match>().Select(ToEntity).ToArray();
        }

        private static TextEntity ToEntity(Match match)
        {
            string label = null;
            var textPieces = match.Groups["entity"].Value.Split(new[] { '|' }, 2);
            var value = textPieces[0];
            if (textPieces.Length > 1)
            {
                label = textPieces[1];
            }

            var entity = DetermineEntityType(value);
            entity.TextIndex = match.Index;
            entity.TextLength = match.Length;
            entity.Label = label;

            return entity;
        }

        private static TextEntity DetermineEntityType(string value)
        {
            if (value.Length < 2)
            {
                return new Unknown(value);
            }

            var start = value.Substring(0, 2);
            if (start == "#C")
            {
                return new ChannelMention(value.Substring(1));
            }

            if (start == "@W" || start == "@U")
            {
                return new UserMention(value.Substring(1));
            }

            if (value[0] == '!')
            {
                if (value.Length > 8 && value.StartsWith("!subteam^"))
                {
                    return new Subteam(value.Substring(9));
                }

                if (value.Length > 5 && value.StartsWith("!date^"))
                {
                    return new DateMention(value.Substring(6).Split('^'));
                }

                if (value == "!here" || value == "!everyone" || value == "!channel")
                {
                    return new SpecialMention(value.Substring(1));
                }

                return new Unknown(value);
            }

            return new Link(value);
        }
    }
}
